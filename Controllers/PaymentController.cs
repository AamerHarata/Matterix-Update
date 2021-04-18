using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Models.Vipps;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe;
using Address = Matterix.Models.Address;

namespace Matterix.Controllers
{
    public class PaymentController: Controller
    {
        
        public class ConfirmPaymentRequest
        {
            [JsonProperty("payment_method_id")]
            public string PaymentMethodId { get; set; }

            [JsonProperty("payment_intent_id")]
            public string PaymentIntentId { get; set; }
            
            [JsonProperty("courseId")]
            public string CourseId { get; set; }
            
            [JsonProperty("invoiceNumber")]
            public int InvoiceNumber { get; set; }
            
            [JsonProperty("reason")]
            public EnumList.PaymentReason Reason { get; set; }
            
            
            [JsonProperty("ip")]
            public string Ip { get; set; }
            
            [JsonProperty("deviceType")]
            public EnumList.DeviceType DeviceType { get; set; }
            
            [JsonProperty("operatingSystem")]
            public EnumList.OperatingSystem OperatingSystem { get; set; }
            
            [JsonProperty("authCookies")]
            public string AuthCookies { get; set; }
            
            [JsonProperty("payAllNow")]
            public bool PayAllNow { get; set; }
        }
        
        private readonly ApplicationDbContext _context;
        private readonly AccessService _access;
        private readonly CourseService _courseService;
        private readonly PaymentService _paymentService;
        private readonly HttpClient Client = new HttpClient();
        private readonly HttpClient Client_Check = new HttpClient();
        private readonly EmailService _email;
        private readonly InformationService _info;
        
        // ToDo :: Test Values
        //        private readonly Dictionary<string, string> VippsParameter = new Dictionary<string, string>()
        //{
        //{ "client_id", "ab6357c1-2337-4c84-bdd6-40c580507a2e" }, { "client_secret", "RHZ1dDZ0UWtDMFJZN051WldHZ08=" }, {"Ocp-Apim-Subscription-Key", "c518e2f133234c26b295fc36be493c16"},{"vippsBaseUrl", "https://apitest.vipps.no"}};


        //ToDo :: Live Values
        private readonly Dictionary<string, string> VippsParameter = new Dictionary<string, string>()
        {
            { "client_id", "ab6357c1-2337-4c84-bdd6-40c580507a2e" }, { "client_secret", "RHZ1dDZ0UWtDMFJZN051WldHZ08=" }, {"Ocp-Apim-Subscription-Key", "c518e2f133234c26b295fc36be493c16"},{"vippsBaseUrl", "https://apitest.vipps.no"}};
        
        

        public PaymentController(ApplicationDbContext context, AccessService access, CourseService courseService, PaymentService paymentService, EmailService email, InformationService info)
        {
            _context = context;
            _access = access;
            _courseService = courseService;
            _paymentService = paymentService;
            _email = email;
            _info = info;
        }
        
        
        //Take the user into payment process page
        [Authorize]
        [HttpGet]
        [Route("/Payment/{reason}")]
        public IActionResult Index(EnumList.PaymentReason reason, string courseId, int invoiceNumber)
        {
            //Shared variable
            var vm = new PaymentViewModel
            {
                Reason = reason, Course = new Course(), Address = new Address(), Student = new ApplicationUser(),
                Invoices = new List<MatterixInvoice>()
            };
            var course = _courseService.GetCourse(courseId);
            
            var student = _context.Users.Find(_access.GetUserId(User));
            var address = _context.Addresses.SingleOrDefault(x => x.UserId == student.Id);

            if (student == null || address == null)
                return RedirectToAction("Error", "Home");
            
            vm.Student = student;
            vm.Address = address;
            
            //Determine payment reason
            switch (reason)
            {
                case EnumList.PaymentReason.Register:
                    if (course == null || !course.IsAvailable())
                        return RedirectToAction("Error", "Home");
                    
                    //User already has access to the course
                    if(_access.CourseViewAccess(User, courseId))
                        return RedirectToAction("CourseArea", "Course", new {courseId});

                    ViewBag.AltCourse = "";
                    if (course.Ended)
                    {
                        var altCourse = _context.Courses.ToList().Where(x =>
                            !x.Ended && x.IsAvailable()).SingleOrDefault(x => string.Equals(x.Subject.Replace(" ", ""), course.Subject.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase));
                        
                        if(altCourse!=null)
                            ViewBag.AltCourse = altCourse.Id;
                            
                    }
                    
                    //ToDo :: Check Max Student - If not, return

                    if (!student.SignedStudentAgreement)
                        return RedirectToAction("StudentAgreement", "Instructions", new {returnUrl = courseId});
                    
                    //ToDo :: Check Student Agreement - if not, return
                    //ToDo :: Check Installment Available -- If not, continue with preventing installment
                    

                    vm.Course = course;
                    
                    var registerInvoices = _paymentService.CreateOnRegisterInvoices(courseId, student);

                    vm.InvoiceToPay = registerInvoices.SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
                    vm.Invoices = registerInvoices.Where(x=>x.Reason != EnumList.InvoiceReason.Registration).OrderBy(x=>x.OriginalDueDate).ToList();
                    return View(vm);
                    
                
                
                
                
                
                case EnumList.PaymentReason.Invoice:
                    var invoice = _paymentService.GetInvoice(invoiceNumber);
                    if(invoice == null || !invoice.ActiveInvoice())
                        return RedirectToAction("Error", "Home");

                    vm.Course = _courseService.GetCourse(invoice.CourseId) ?? new Course();
                    //ToDo :: Check any increment for the invoice here _PaymentService.InvoiceFullAmount
                    vm.InvoiceToPay = invoice;
                    return View(vm);
                    
                
                case EnumList.PaymentReason.Empty:
                case EnumList.PaymentReason.Donate:
                case EnumList.PaymentReason.Other:
                default:
                    return RedirectToAction("Error", "Home");
            }
            
        }





        //Create Stripe payment
        [Route("/Payment/Stripe/")]
        [Authorize]
        public async Task<IActionResult> Stripe([FromBody] ConfirmPaymentRequest request)
        {
            
            
            
            var paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent = null;
            
            try
            {
                if (request.PaymentMethodId != null)
                {
                    
                    //Needed objects
            var course = _courseService.GetCourse(request.CourseId);
            var invoice = _paymentService.GetInvoice(request.InvoiceNumber);
            var user = await _context.Users.FindAsync(_access.GetUserId(User));
            var description = "";

//            if (user == null)
//                return BadRequest(new {result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
            //ToDo :: Handle the return of bad request

            
            decimal amountToPay = 0;
            
            switch (request.Reason)
            {
                case EnumList.PaymentReason.Register:
                    //Check if course null
                    if(course == null) // ToDo :: Handle bad request return
                        return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", request.CourseId, request.InvoiceNumber,reason = request.Reason.ToString()});
                    
                    //Get on register invoice
                    var registerInvoice = _paymentService.CreateOnRegisterInvoices(request.CourseId, user)
                        .SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
                    
                    //Determine the amount user wants to pay now
                    if (request.PayAllNow)
                        amountToPay = course.Price;
                    else
                        amountToPay = registerInvoice?.Amount ?? 0;

                    description = $"Charge for {user.FirstName} {user.LastName} - {user.Email} For Course {course.Subject}-{course.Code} Payment: {amountToPay} kr";
                    break;
                
                
                
                
                
                
                case EnumList.PaymentReason.Invoice:
                    //Check if invoice is null
                    if(invoice == null || !invoice.ActiveInvoice())
                        return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", request.CourseId, request.InvoiceNumber,reason = request.Reason.ToString()});
                    
                    amountToPay = invoice.CurrentAmount;
                    description = $"Betaling av {user.FirstName} {user.LastName} - Fakturanummer: {invoice.Number} - KID-nummer: {invoice.CIDNumber}";
                    
                    break;


                case EnumList.PaymentReason.Empty:
                case EnumList.PaymentReason.Donate:
                case EnumList.PaymentReason.Other:
                default: 
                    return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", request.CourseId, request.InvoiceNumber,reason = request.Reason.ToString()});
            }
            
            
            //ToDo :: If amount to pay is 0 return Bad Request
                    
                    
                    
                    
                    
                    var customerOptions = new CustomerCreateOptions
                    {
                        Description = $"{user.FirstName +" "+ user.LastName}",
                        Name = $"{user.FirstName +" "+ user.LastName}",
                        PaymentMethod = request.PaymentMethodId,
                        Email = $"{user.Email}",
                        Metadata = new Dictionary<string, string>
                        {
                            {"UniqueId", $"USERID-{user.Id}-COURSE-{course.Id}-{Format.NorwayDateTimeNow().Year}"}
                        }
                    };
                    
                    var customerService = new CustomerService();
                    var customer = customerService.Create(customerOptions);
                    
                    // Create the PaymentIntent
                    var createOptions = new PaymentIntentCreateOptions
                    {
                        Amount = (int) amountToPay * 100,
                        Currency = "nok",
                        Description = description,
                        Customer = customer.Id,
                        ReceiptEmail = $"{user.Email}",
                        PaymentMethod = request.PaymentMethodId,
                        ConfirmationMethod = "manual",
                        Confirm = true, 
                    };
                    paymentIntent = paymentIntentService.Create(createOptions);

                    var initiatedOrder = new InitiatedOrder
                    {
                        Id = paymentIntent.Id, User = user, CourseId = request.CourseId, InvoiceNumber = request.InvoiceNumber,
                        Amount = amountToPay, PaymentMethod = EnumList.PaymentMethod.Stripe, Reason = request.Reason, Status = EnumList.OrderStatus.Initiated,
                        Ip = request.Ip, OperatingSystem = request.OperatingSystem, DeviceType = request.DeviceType, AuthCookies = request.AuthCookies, PayAllNow = request.PayAllNow
                    };
                    await _context.AddAsync(initiatedOrder);
                    await _context.SaveChangesAsync();
                }
                if (request.PaymentIntentId != null)
                {
                    var confirmOptions = new PaymentIntentConfirmOptions{};
                    paymentIntent = paymentIntentService.Confirm(
                        request.PaymentIntentId,
                        confirmOptions
                    );
                }
            }
            catch (StripeException e)
            {
                return Json(new { error = e.StripeError.Message });
            }
            return GeneratePaymentResponse(paymentIntent);
            
            
            
            
            
            
            
            
            
            
            
            


        }
        
        
        //Stripe Response --> Move from here to result
        private IActionResult GeneratePaymentResponse(PaymentIntent intent)
        {
            // Note that if your API version is before 2019-02-11, 'requires_action'
            // appears as 'requires_source_action'.
            if (intent.Status == "requires_action" &&
                intent.NextAction.Type == "use_stripe_sdk")
            {
                // Tell the client to handle the action
                return Json(new
                {
                    requires_action = true,
                    payment_intent_client_secret = intent.ClientSecret
                });
            }
            else if (intent.Status == "succeeded")
            {
                var order = _context.InitiatedOrders.Find(intent.Id);
                if(order == null)
                    return StatusCode(500, new {error = "Error"});
                
                switch (order.Reason)
                {
//                    case EnumList.PaymentReason.Register when CompleteRegistration(order.UserId, order.CourseId, order.Reason, EnumList.PaymentMethod.Stripe, order.Id,
//                        order.PayAllNow, new UserDevice()).Result:
                    case EnumList.PaymentReason.Register when CompleteRegistration(order.Id).Result:
//                        return Ok(new {result = EnumList.PaymentResult.Success.ToString(), message = "success", order.CourseId, order.InvoiceNumber,reason = order.Reason.ToString()});
                        return Ok(new { orderId = order.Id });
                    case EnumList.PaymentReason.Invoice when CompleteInvoicePayment(order.Id).Result:
                        return Ok(new { orderId = order.Id });
                    case EnumList.PaymentReason.Empty:
                    case EnumList.PaymentReason.Donate:
                    case EnumList.PaymentReason.Other:
                    default:
                        // The payment didn’t need any additional actions and completed!
                        // Handle post-payment fulfillment
                        return StatusCode(500, new {error = "Error"});
                }
            }
            else
            {
                // Invalid status
                return StatusCode(500, new {error = "Invalid PaymentIntent status"});
            }

        }



        
        
        
        //Create Vipps Payment
        [Route("/Payment/CreateVipps/")]
        [Authorize]
        public async Task<IActionResult> CreateVipps(string courseId, EnumList.PaymentReason reason, [Bind("AuthCookies,Ip,DeviceType,OperatingSystem")]UserDevice device, bool payAllNow, int invoiceNumber)
        {
            
            var invoice = _paymentService.GetInvoice(invoiceNumber);
            var user = _context.Users.Find(_access.GetUserId(User));

            
            if(user == null)
                return BadRequest(new{result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});
            
            
            var orderId = "";
            var transactionText = "";
            decimal amountToPay = 0;





            //Determine amount and description
            switch (reason)
            {
                
                case EnumList.PaymentReason.Register:
                    //Check if course null
                    var course = _courseService.GetCourse(courseId);
                    if(course == null)
                        return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});
                    
                    //Get on register invoice
                    var registerInvoice = _paymentService.CreateOnRegisterInvoices(courseId, user)
                        .SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
                    
                    //Determine the amount user wants to pay now
                    if (payAllNow)
                        amountToPay = course.Price;
                    else
                        amountToPay = registerInvoice?.Amount ?? 0;

                    transactionText = $"{course.Subject}--{course.Code}";

                    orderId = $"{course.Id.Split("-")[0]}-{user.Id.Split("-")[0]}-{Guid.NewGuid().ToString().Split("-")[0]}";
                    break;
                
                
                
                
                
                
                
                
                case EnumList.PaymentReason.Invoice:
                    //Check if invoice is null
                    if(invoice == null)
                        return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});

                    if (string.IsNullOrEmpty(courseId))
                        courseId = invoice.CourseId;
                    amountToPay = invoice.CurrentAmount;
                    transactionText = $"Faktura{invoiceNumber}-KID{invoice.CIDNumber}";
                    orderId =
                        $"{invoiceNumber}-{invoice.CIDNumber}-{Guid.NewGuid().ToString().Split("-")[0]}";
                    break;
                
                
                
                
                
                
                
                case EnumList.PaymentReason.Donate:
                case EnumList.PaymentReason.Empty:
                case EnumList.PaymentReason.Other:
                default:
                    return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", courseId = courseId, invoiceNumber = invoice.Number, reason = reason, url = Url.Action("PaymentResult", "Payment")});
            }





            if (amountToPay <= 0)
                return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", courseId = courseId, invoiceNumber = invoice.Number, reason = reason, url = Url.Action("PaymentResult", "Payment")});

            var order = new InitiatedOrder()
            {
                User = user, Reason = reason, CourseId = courseId, InvoiceNumber = invoiceNumber, Ip = device.Ip,
                Amount = amountToPay, PayAllNow = payAllNow, Id = orderId, DeviceType = device.DeviceType,
                AuthCookies = device.AuthCookies, OperatingSystem = device.OperatingSystem, Status = EnumList.OrderStatus.Initiated, PaymentMethod = EnumList.PaymentMethod.Vipps
            };
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            

            var accessToken = VippsAccessToken().Result;
            
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments?" + queryString;           
            
            HttpResponseMessage response;
            
            
            
            
            var vippsPayment = new VippsPayment()
            {
                transaction = new transaction()
                {
                    amount = (int) amountToPay*100,
                    orderId = orderId,
                    transactionText = transactionText
                },
                customerInfo = new customerInfo()
                {
                    mobileNumber = $"48059521", // ToDo :: Change this number to user.PhoneNumber on Production
                }
            };
            
//            _config.GetSection("liveWebsite").Value
            vippsPayment.merchantInfo.fallBack =
                StaticInformation.FullWebsite + "/VippsCallBack?" +
                "orderId="+orderId+
                "&token=" + accessToken;

//            vippsPayment.merchantInfo.callbackPrefix = vippsPayment.merchantInfo.fallBack;
//            if (device.DeviceType == EnumList.DeviceType.Mobile)
//            {
//                vippsPayment.merchantInfo.isApp = true;
//            }
            
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));


            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Client.PostAsync(uri, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                JObject parseResponse = JObject.Parse(responseString);
                var url = parseResponse["url"];
                
                
                //Run Task to give the payment 5 minutes to cancel if not completed, then return
//                Task.Factory.StartNew(CheckVippsPayment(orderId));
//                Task.Factory.StartNew( () => CheckVippsPayment(orderId, "Bearer "+accessToken), CancellationToken.None,
//                    TaskCreationOptions.LongRunning, 
//                    TaskScheduler.Default);
                
                
                return Ok(url);
                
            }

            
        }
        
        
        
        [Route("/VippsRefund")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> VippsRefund(string paymentId, string orderId, decimal amount)
        {

            var payment = _context.Payments.Find(paymentId);
            if (payment == null)
                return NotFound("Payment id not found");
            
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var accessToken = VippsAccessToken().Result;

            Client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ accessToken);
            Client.DefaultRequestHeaders.Add("X-Request-Id", orderId);
            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
            
            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/refund?" + queryString;
            HttpResponseMessage response;
            
            var vippsPayment = new VippsPayment()
            {
                merchantInfo = new merchantInfo(),
                transaction = new transaction()
                {
                    amount = (int) amount*100,
                    transactionText = "Refund payment: "+paymentId+" - amount: "+ amount
                    
                },
                customerInfo = null,
            };
            
            
            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));
            var processStatus = 0;

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await Client.PostAsync(uri, content);
                var responseString = response.Content.ReadAsStringAsync().Result;
                processStatus = (int) response.StatusCode;
            }

            if (processStatus != 200) return BadRequest("The process failed!");
            
            payment.ExtraDescription = "Refunded: " + amount;
            payment.RefundedAt = Format.NorwayDateTimeNow();
            payment.Refunded = true;
            

            _context.Update(payment);
            _context.SaveChanges();


            var relatedInvoice = _context.Invoices.SingleOrDefault(x => x.PaymentId == paymentId);

            if (relatedInvoice == null) return Ok();
            relatedInvoice.Paid = false;
            relatedInvoice.Canceled = true;
            _context.Update(relatedInvoice);
            _context.SaveChanges();


            return Ok();


        }
        
        
        [Route("/StripeRefund")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> StripeRefund(string paymentRef)
        {

            var payment = _context.Payments.SingleOrDefault(x => x.PaymentServiceRef == paymentRef);
            if (payment == null)
                return NotFound("Payment id not found");


            try
            {
                
                var refunds = new RefundService();
            
            
                var refundOptions = new RefundCreateOptions {
                    PaymentIntent = paymentRef
                };
                var refund = refunds.Create(refundOptions);

            }
            catch (Exception e)
            {
                return BadRequest("Error refunding stripe");
            }
 

            
            
            payment.ExtraDescription = "Refunded: " + payment.Amount;
            payment.RefundedAt = Format.NorwayDateTimeNow();
            payment.Refunded = true;
            

            _context.Update(payment);
            _context.SaveChanges();


            var relatedInvoice = _context.Invoices.SingleOrDefault(x => x.PaymentId == payment.Id);

            if (relatedInvoice == null) return Ok();
            relatedInvoice.Paid = false;
            relatedInvoice.Canceled = true;
            _context.Update(relatedInvoice);
            _context.SaveChanges();


            return Ok();


        }


        public async Task<IActionResult> CheckVippsNotCompleted(string userId)
        {
            
            //This function will return TRUE if the money paid and registration not completed. Will return FALSE otherwise (no action required)
            
            var orders = _context.InitiatedOrders.Where(x => x.UserId == userId)
                .Where(x => x.PaymentMethod == EnumList.PaymentMethod.Vipps)
                .Where(x => x.Status == EnumList.OrderStatus.Initiated || x.Status == EnumList.OrderStatus.ActionRequired);
            
            var token = VippsAccessToken().Result;
            var accessToken = "Bearer " + token;


            foreach (var order in orders)
            {
                Client_Check.DefaultRequestHeaders.Add("Authorization", accessToken);
                Client_Check.DefaultRequestHeaders.Add("X-Request-Id", order.Id);
                Client_Check.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
                Client_Check.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);

                var uri = VippsParameter["vippsBaseUrl"] + "/ecomm/v2/payments/" + order.Id + "/details";
                HttpResponseMessage response;

                var vippsPayment = new VippsPayment()
                {
                    merchantInfo = new merchantInfo(),
                    transaction = new transaction()
                    {
                        transactionText = ""
                    },

                    customerInfo = null,
                };

                byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));

                var fullResult = "NONE";
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = Client_Check.GetAsync(uri).Result;
                    fullResult = await response.Content.ReadAsStringAsync();
                }



                try
                {
                    var history = JObject.Parse(fullResult).SelectToken("transactionLogHistory");
                    var finalOperation = history.First["operation"].ToString();


                    Enum.TryParse(finalOperation, out EnumList.VippsPaymentStatus operation);


                    switch (operation)
                    {
                        case EnumList.VippsPaymentStatus.INITIATE:
                        case EnumList.VippsPaymentStatus.REGISTER:
                            continue;

                        case EnumList.VippsPaymentStatus.RESERVE:
                            //Important :: The payment is done but the process not completed --> Return true to show it to the user
                            order.Status = EnumList.OrderStatus.ActionRequired;
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            continue;

                        case EnumList.VippsPaymentStatus.CAPTURE:
                        case EnumList.VippsPaymentStatus.SALE:
                            //The money is paid and the order is completed in this case --> Set the order to be done the return false to remove it from view
                            order.Status = EnumList.OrderStatus.Completed;
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            continue;
                        case EnumList.VippsPaymentStatus.REJECTED:
                        case EnumList.VippsPaymentStatus.VOID:
                        case EnumList.VippsPaymentStatus.FAILED:
                        case EnumList.VippsPaymentStatus.CANCEL:
                        case EnumList.VippsPaymentStatus.INVALID: //The order is not exist (STRIPE Case)
                            //All those cases the money has not paid or returned so no action required, no need to hold the order in records
                            order.Status = EnumList.OrderStatus.Failed;
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            continue;

                        case EnumList.VippsPaymentStatus.REFUND:
                            order.Status = EnumList.OrderStatus.Canceled;
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            continue;


                        default:
                            order.Status = EnumList.OrderStatus.Failed;
                            _context.Update(order);
                            await _context.SaveChangesAsync();
                            continue;
                    }



                }
                catch (Exception e)
                {
                    //ToDo :: Order exists in my website but not in Vipps (This case can be stripe for example)
                    order.Status = EnumList.OrderStatus.Failed;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                
                
            }


            return Ok();
        }
        
        
        
        [Route("/Payment/CompletePayment")]

        public IActionResult CompletePayment(string orderId)
        {


            var order = _context.InitiatedOrders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return RedirectToAction("Error", "Home");


            var token = VippsAccessToken().Result;
            

            return RedirectToAction("VippsCallBack", new {orderId, token});





        }




        //Vipps payment will return here
        [Route("/VippsCallBack")]
        public async Task<IActionResult>VippsCallBack(string orderId, string token)
        {
            var order = await _context.InitiatedOrders.FindAsync(orderId);

            if (order == null)
                return RedirectToAction("Error", "Home");
            
            var paymentResponse = await VippsCapturePayment("Bearer " + token, orderId);

            if (paymentResponse != 200 || order.Amount == 0)
            {
                order.Status = EnumList.OrderStatus.Failed;
                _context.Update(order);
                await _context.SaveChangesAsync();
                
                //The Money didn't paid
                return RedirectToAction("PaymentResult", new {orderId = order.Id});
            }



            //ToDo :: Redirect to success with reason etc ...
            if(order.Reason == EnumList.PaymentReason.Register)
                if (await CompleteRegistration(orderId))
                    return RedirectToAction("PaymentResult",new {orderId = order.Id});
            if(order.Reason == EnumList.PaymentReason.Invoice)
                if (await CompleteInvoicePayment(orderId))
                    return RedirectToAction("PaymentResult",new {orderId = order.Id});

            //ToDo :: payment done but something wrong
            return RedirectToAction("PaymentResult",new {orderId = order.Id});
            
            
            
        }
        
        
        //Use This to get the actual values from the server
        [Route("/VippsTestCallBack")]
        public async Task<IActionResult>VippsTestCallBack(string orderId, string token)
        {
            return Ok(new {orderId, token});

        }
        
        



        //Handler Free Registrations
        [Route("/Payment/CreateFreeRegistration")]
        public async Task<IActionResult> CreateFreeRegistration(string courseId, EnumList.DeviceType deviceType, string ip, EnumList.OperatingSystem operatingSystem, string authCookies)
        {
            var user = _context.Users.Find(_access.GetUserId(User));
            var course = _courseService.GetCourse(courseId);

            if (user == null || course == null || course.Price > 0)
                return BadRequest(new {result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId,reason = EnumList.PaymentReason.Register.ToString()});


            var registration = new Registration
            {
                Course = course, Student = user, Price = 0, IpAddress = ip, AuthCookies = authCookies,
                ExpireDate = Format.NorwayDateTimeNow().AddYears(1)
            };

            var isNew = _info.IsDeviceNew(user.Id, authCookies, ip);
            var groupNumber = _info.GetDeviceGroupNumber(user.Id, authCookies, ip);
            
            var device = new UserDevice
            {
                Activity = EnumList.Activity.CourseRegister, Ip = ip, User = user,
                DeviceType = deviceType, AuthCookies = authCookies, OperatingSystem = operatingSystem,
                New = isNew, GroupNumber = groupNumber
            };

            var orderId = $"Free-{courseId.Split("-")?[0]}-{Guid.NewGuid().ToString().Split("-")?[0]}";
            
            var order = new InitiatedOrder
            {
                Id= orderId, User = user, Ip = device.Ip, AuthCookies = device.AuthCookies, Amount = 0, Reason = EnumList.PaymentReason.Register, Status = EnumList.OrderStatus.Completed, CourseId = courseId, PaymentMethod = EnumList.PaymentMethod.Other,
                DeviceType = deviceType, OperatingSystem = operatingSystem, PayAllNow = true,
            };

            _context.Add(order);
            _context.Add(registration);
            _context.SaveChanges();
            _context.Add(device);
            _context.SaveChanges();
                        
            
            await _email.CourseRegisterCompletedEmail(user.Id, courseId,Format.NorwayDateTimeNow().AddYears(1));
            
            
            return Ok(new {orderId= order.Id});
        }
        
        
        
        
        //Get Vipps access token
        private async Task<string> VippsAccessToken()
        {
            
            Client.DefaultRequestHeaders.Add("X-Version","1");
            Client.DefaultRequestHeaders.Add("client_id", VippsParameter["client_id"]);
            Client.DefaultRequestHeaders.Add("client_secret", VippsParameter["client_secret"]);
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);


            var response = await Client.PostAsync(VippsParameter["vippsBaseUrl"]+"/accessToken/get", null);

            var responseString = await response.Content.ReadAsStringAsync();
            
             
            JObject parseResponse = JObject.Parse(responseString);

            var accessToken = parseResponse["access_token"];

            return accessToken.ToString();
        }

        
        //Done the Vipps payment
        private async Task<int> VippsCapturePayment(string token, string orderId)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            Client.DefaultRequestHeaders.Add("Authorization", token);
            Client.DefaultRequestHeaders.Add("X-Request-Id", orderId);
            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);

            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/capture?" + queryString;
            HttpResponseMessage response;

            var vippsPayment = new VippsPayment()
            {
                merchantInfo = new merchantInfo(),
                transaction = new transaction()
                {
                    transactionText = "transaction test" // ToDo :: Change the text to be description
                },

                customerInfo = null,
            };

            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Client.PostAsync(uri, content).Result;
                var responseString = await response.Content.ReadAsStringAsync();
                return (int) response.StatusCode;
            }
        }


        //Complete an invoice payment
        private async Task<bool> CompleteInvoicePayment(string orderId)
        {
            var order = await _context.InitiatedOrders.FindAsync(orderId);
            if (order == null)
                return false;
            
            var invoice = _paymentService.GetInvoice(order.InvoiceNumber);
            var user = await _context.Users.FindAsync(order.UserId);
            if (invoice == null || user == null)
                return false;
            
            var course = _courseService.GetCourse(invoice.CourseId) ?? new Course();

            var payment = new MatterixPayment
            {
                User = user, Course = course, Amount = invoice.CurrentAmount, Reason = EnumList.PaymentReason.Invoice,
                Invoice = invoice, PaymentServiceRef = orderId, Method = order.PaymentMethod
            };


            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            
            invoice.Paid = true;
            invoice.PaymentId = payment.Id;
            invoice.NextNotification = DateTime.MaxValue;

            _context.Update(invoice);
            await _context.SaveChangesAsync();
            
            var isNew = _info.IsDeviceNew(user.Id, order.AuthCookies, order.Ip);
            var groupNumber = _info.GetDeviceGroupNumber(user.Id, order.AuthCookies, order.Ip);
            
            var device = new UserDevice
            {
                User = user, Activity = EnumList.Activity.Payment, Ip = order.Ip, DeviceType = order.DeviceType, AuthCookies = order.AuthCookies,
                New = isNew, GroupNumber = groupNumber, OperatingSystem = order.OperatingSystem
            };
            await _context.AddAsync(device);
            _context.SaveChanges();
            
            //Here the invoice and payments are done -- send the email
            await _email.InvoicePaidEmail(order.InvoiceNumber);

            order.Status = EnumList.OrderStatus.Completed;
            _context.Update(order);
            await  _context.SaveChangesAsync();
            
            return true;
        }
        
        //Complete the registration
        private async Task<bool> CompleteRegistration(string orderId)
        {
            var order = await _context.InitiatedOrders.FindAsync(orderId);
            if (order == null)
                return false;
            
            var course = _courseService.GetCourse(order.CourseId);
            var user = await _context.Users.FindAsync(order.UserId);
            
            //Check if user or course is null
            if (user == null || order.Reason != EnumList.PaymentReason.Register || course == null)
                return false;
            
            
            //Add the device made the registration
                    
            var isNew = _info.IsDeviceNew(user.Id, order.AuthCookies, order.Ip);
            var groupNumber = _info.GetDeviceGroupNumber(user.Id, order.AuthCookies, order.Ip);
            var device = new UserDevice
            {
                User = user, Activity = EnumList.Activity.CourseRegister, Ip = order.Ip, DeviceType = order.DeviceType, AuthCookies = order.AuthCookies,
                New = isNew, GroupNumber = groupNumber, OperatingSystem = order.OperatingSystem
            };
            await _context.AddAsync(device);
            await _context.SaveChangesAsync();
                    
            //Add payment activity
            var device2 = new UserDevice
            {
                User = user, Activity = EnumList.Activity.Payment, Ip = order.Ip, DeviceType = order.DeviceType, AuthCookies = order.AuthCookies,
                New = isNew, GroupNumber = groupNumber, OperatingSystem = order.OperatingSystem
            };
            
            _context.Add(device2);
            await _context.SaveChangesAsync();

            //Determine registration expire date
            var expireDate = _courseService.EstimateRegExpireDate(order.CourseId);
                    
            //Add registration
            await _courseService.AddOrRenewRegistration(order.CourseId, order.UserId, device);        
            
            
            
                    
                    
            //Add invoices

            var paidInvoice = new MatterixInvoice();
                    
            if (order.PayAllNow)
            {
                paidInvoice = new MatterixInvoice
                {
                    Course = course, User = user, Amount = course.Price, CurrentAmount = course.Price, Paid = true, Reason = EnumList.InvoiceReason.Registration, OriginalDeadline = Format.NorwayDateTimeNow().AddDays(15), CurrentDeadline = Format.NorwayDateTimeNow().AddDays(15), OriginalDueDate = Format.NorwayDateTimeNow().Date, CurrentDueDate = Format.NorwayDateTimeNow().Date, InvoiceType = EnumList.InvoiceType.Invoice, 
                };
//                paidInvoice = paidInvoice;
                        
                //This invoice is paid now
                await _context.AddAsync(paidInvoice);
                await _context.SaveChangesAsync();

            }
            else
            {
                var invoices = _paymentService.CreateOnRegisterInvoices(order.CourseId, user);

                foreach (var inv in invoices)
                {
                    if (inv.Reason == EnumList.InvoiceReason.Registration)
                    {
                        paidInvoice = inv;
                        await _context.AddAsync(paidInvoice);
                        await _context.SaveChangesAsync();
                                
                    }else if (inv.Reason == EnumList.InvoiceReason.MonthlyPayment)
                    {
                        await _context.AddAsync(inv);
                        await _context.SaveChangesAsync();
                    }
                }

            }
                    
            //Add Payment
            var payment = new MatterixPayment
            {
                Course = course, User = user, Reason = EnumList.PaymentReason.Register, Invoice = paidInvoice,
                Amount = paidInvoice.Amount, Method = order.PaymentMethod, PaymentServiceRef = orderId
            };

            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

            paidInvoice.Paid = true;
            paidInvoice.PaymentId = payment.Id;
            paidInvoice.NextNotification = DateTime.MaxValue;
            
            _context.Update(paidInvoice);
            await _context.SaveChangesAsync();
            
            
            //Here the invoice and payments are done -- send the email
            await _email.InvoicePaidEmail(paidInvoice.Number);
                    

            //Here the registration is done -- send email

            await _email.CourseRegisterCompletedEmail(order.UserId, order.CourseId, expireDate);

            order.Status = EnumList.OrderStatus.Completed;
            _context.Update(order);
            await _context.SaveChangesAsync();
            
            return true;
            
        }
        
        
        //Check Vipps payment after 5 minutes
//        private async void CheckVippsPayment(string orderId, string token)
//        {
//            await Task.Delay(new TimeSpan(0, 0, 30));
//            
//            var accessToken = VippsAccessToken().Result;
//
//            Client_Check.DefaultRequestHeaders.Add("Authorization", "Bearer "+ accessToken);
//            Client_Check.DefaultRequestHeaders.Add("X-Request-Id", orderId);
//            Client_Check.DefaultRequestHeaders.Add("X-TimeStamp", DateTime.Now.ToString());
//            Client_Check.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//            
//            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/details?" + string.Empty;
//            HttpResponseMessage response;
//            
//            
//            var processStatus = 0;
//            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new VippsPayment()));
//
//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = await Client_Check.GetAsync(uri);
//                var responseString = JObject.Parse(response.Content.ReadAsStringAsync().Result);
//                processStatus = (int) response.StatusCode;
//
//                var transactionResult = responseString["transactionLogHistory"].First["operation"];
//
//                if (processStatus != 200 || !string.Equals(transactionResult.ToString(), "INITIATE",
//                        StringComparison.CurrentCultureIgnoreCase)) return;
//                
//                var uri1 = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/cancel?" + string.Empty;
//                response = await Client_Check.PutAsync(uri1, content);
//                responseString = JObject.Parse(response.Content.ReadAsStringAsync().Result);
//            }            
//            
//
//            
//
//
//            
//        }
        



        [Route("/Payment/Result/{orderId}")]
        public IActionResult PaymentResult(string orderId)
        {

            var order = _context.InitiatedOrders.Find(orderId);
            var student = _context.Users.Find(order?.UserId);
            var course = _courseService.GetCourse(order?.CourseId);
            if (order == null || student == null)
                return RedirectToAction("Error", "Home");
            
            
            //Determine payment reason
            switch (order.Reason)
            {
                case EnumList.PaymentReason.Register:
                    if (course == null)
                        return RedirectToAction("Error", "Home");

                    break;
                     
                case EnumList.PaymentReason.Invoice:
                    var invoice = _context.Invoices.Find(order.InvoiceNumber);
                    
                    if(invoice == null)
                        return RedirectToAction("Error", "Home");

                    break;
                    
                
                case EnumList.PaymentReason.Empty:
                case EnumList.PaymentReason.Donate:
                case EnumList.PaymentReason.Other:
                default:
                    return RedirectToAction("Error", "Home");
            }

//            vm.Result = result;

            return View(order);
        }




        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}