//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using Matterix.Data;
//using Matterix.Models;
//using Matterix.Models.ViewModel;
//using Matterix.Models.Vipps;
//using Matterix.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Stripe;
//using Address = Matterix.Models.Address;
//
//namespace Matterix.Controllers
//{
//    public class Payment111Controller: Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly AccessService _access;
//        private readonly CourseService _courseService;
//        private readonly PaymentService _paymentService;
//        private readonly HttpClient Client = new HttpClient();
//        private readonly HttpClient Client_Check = new HttpClient();
//        private readonly EmailService _email;
//        private readonly InformationService _info;
//        
//        // ToDo :: Test Values
//        //        private readonly Dictionary<string, string> VippsParameter = new Dictionary<string, string>()
//        //{
//        //{ "client_id", "ab6357c1-2337-4c84-bdd6-40c580507a2e" }, { "client_secret", "RHZ1dDZ0UWtDMFJZN051WldHZ08=" }, {"Ocp-Apim-Subscription-Key", "c518e2f133234c26b295fc36be493c16"},{"vippsBaseUrl", "https://apitest.vipps.no"}};
//
//
//        //ToDo :: Live Values
//        private readonly Dictionary<string, string> VippsParameter = new Dictionary<string, string>()
//        {
//            { "client_id", "01a71e9a-2472-4462-888c-2af384689e2d" }, { "client_secret", "N3MwaEpWWlJ1Y1BHTWs4ZjV5UlU=" }, {"Ocp-Apim-Subscription-Key", "7b411c67e04a4774ac83274bb7f388ed"},{"vippsBaseUrl", "https://api.vipps.no"}};
//        
//        
//
//        public Payment111Controller(ApplicationDbContext context, AccessService access, CourseService courseService, PaymentService paymentService, EmailService email, InformationService info)
//        {
//            _context = context;
//            _access = access;
//            _courseService = courseService;
//            _paymentService = paymentService;
//            _email = email;
//            _info = info;
//        }
//        
//        
//        //Take the user into payment process page
//        [Authorize]
//        [HttpGet]
////        [Route("/Payment/{reason}")]
//        public IActionResult Index(EnumList.PaymentReason reason, string courseId, int invoiceNumber)
//        {
//            //Shared variable
//            var vm = new PaymentViewModel
//            {
//                Reason = reason, Course = new Course(), Address = new Address(), Student = new ApplicationUser(),
//                Invoices = new List<MatterixInvoice>()
//            };
//            var course = _courseService.GetCourse(courseId);
//            
//            var student = _context.Users.Find(_access.GetUserId(User));
//            var address = _context.Addresses.SingleOrDefault(x => x.UserId == student.Id);
//
//            if (student == null || address == null)
//                return RedirectToAction("Error", "Home");
//            
//            vm.Student = student;
//            vm.Address = address;
//            
//            //Determine payment reason
//            switch (reason)
//            {
//                case EnumList.PaymentReason.Register:
//                    if (course == null || !course.IsAvailable())
//                        return RedirectToAction("Error", "Home");
//                    
//                    //User already has access to the course
//                    if(_access.CourseViewAccess(User, courseId))
//                        return RedirectToAction("CourseArea", "Course", new {courseId});
//
//                    ViewBag.AltCourse = "";
//                    if (course.Ended)
//                    {
//                        var altCourse = _context.Courses.Where(x =>
//                            !x.Ended && x.IsAvailable()).SingleOrDefault(x => string.Equals(x.Subject.Replace(" ", ""), course.Subject.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase));
//                        
//                        if(altCourse!=null)
//                            ViewBag.AltCourse = altCourse.Id;
//                            
//                    }
//                    
//                    //ToDo :: Check Max Student - If not, return
//
//                    if (!student.SignedStudentAgreement)
//                        return RedirectToAction("StudentAgreement", "Instructions", new {returnUrl = courseId});
//                    
//                    //ToDo :: Check Student Agreement - if not, return
//                    //ToDo :: Check Installment Available -- If not, continue with preventing installment
//                    
//
//                    vm.Course = course;
//                    
//                    var registerInvoices = _paymentService.CreateOnRegisterInvoices(courseId, student);
//
//                    vm.InvoiceToPay = registerInvoices.SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
//                    vm.Invoices = registerInvoices.Where(x=>x.Reason != EnumList.InvoiceReason.Registration).OrderBy(x=>x.OriginalDueDate).ToList();
//                    return View(vm);
//                    
//                
//                
//                
//                
//                
//                case EnumList.PaymentReason.Invoice:
//                    var invoice = _paymentService.GetInvoice(invoiceNumber);
//                    if(invoice == null || !invoice.ActiveInvoice())
//                        return RedirectToAction("Error", "Home");
//
//                    vm.Course = _courseService.GetCourse(invoice.CourseId) ?? new Course();
//                    //ToDo :: Check any increment for the invoice here _PaymentService.InvoiceFullAmount
//                    vm.InvoiceToPay = invoice;
//                    return View(vm);
//                    
//                
//                case EnumList.PaymentReason.Empty:
//                case EnumList.PaymentReason.Donate:
//                case EnumList.PaymentReason.Other:
//                default:
//                    return RedirectToAction("Error", "Home");
//            }
//            
//        }
//
//
//
//
//
//        //Create Stripe payment
////        [Route("/Payment/Stripe/")]
//        [Authorize]
//        public IActionResult Stripe(string courseId, EnumList.PaymentReason reason, UserDevice device, bool payAllNow, string stripeAccessToken, int invoiceNumber)
//        {
//
//            var course = _courseService.GetCourse(courseId);
//            var invoice = _paymentService.GetInvoice(invoiceNumber);
//            var user = _context.Users.Find(_access.GetUserId(User));
//            var description = "";
//            var serviceId = "";
//
//            if (user == null)
//                return BadRequest(new {result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
//            
//            var stripeToken = stripeAccessToken;
//            decimal amountToPay = 0;
//
//            switch (reason)
//            {
//                case EnumList.PaymentReason.Register:
//                    //Check if course null
//                    if(course == null)
//                        return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
//                    
//                    //Get on register invoice
//                    var registerInvoice = _paymentService.CreateOnRegisterInvoices(courseId, user)
//                        .SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
//                    
//                    //Determine the amount user wants to pay now
//                    if (payAllNow)
//                        amountToPay = course.Price;
//                    else
//                        amountToPay = registerInvoice?.Amount ?? 0;
//
//                    description = $"Charge for {user.FirstName} {user.LastName} - {user.Email} For Course {course.Subject}-{course.Code} Payment: {amountToPay} kr";
//                    break;
//                
//                
//                
//                
//                
//                
//                case EnumList.PaymentReason.Invoice:
//                    //Check if invoice is null
//                    if(invoice == null || !invoice.ActiveInvoice())
//                        return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
//                    
//                    amountToPay = invoice.CurrentAmount;
//                    description = $"Betaling av {user.FirstName} {user.LastName} - Fakturanummer: {invoice.Number} - KID-nummer: {invoice.CIDNumber}";
//                    
//                    break;
//
//
//                case EnumList.PaymentReason.Empty:
//                case EnumList.PaymentReason.Donate:
//                case EnumList.PaymentReason.Other:
//                default: 
//                    return BadRequest(new {userId=user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
//            }
//            
//            
//            
//            //For more safety check if the amount is 0
//            if(amountToPay <= 0)
//                return BadRequest(new {result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId, invoiceNumber,reason = reason.ToString()});
//
//            try
//            {
//                var customerOptions = new CustomerCreateOptions
//                {
//                    Description = $"{user.FirstName +" "+ user.LastName}",
//                    Source = stripeToken,
//                    Email = $"{user.Email}",
//                    Metadata = new Dictionary<string, string>
//                    {
//                        {"UniqueId", $"USERID-{user.Id}-COURSE-{course.Id}-{Format.NorwayDateTimeNow().Year}"}
//                    }
//                };
//                
//                var customerService = new CustomerService();
//                var customer = customerService.Create(customerOptions);
//                
//                var options = new ChargeCreateOptions
//                {
//                    Amount = (int) amountToPay * 100,
//                    Currency = "nok",
//                    Description = description,
//                    Customer = customer.Id,
//                    ReceiptEmail = $"{user.Email}",
//                };
//                
//                var service = new ChargeService();
//                var charge = service.Create(options);
//
//                serviceId = charge.Id;
//
//
//            }
//            
//            //Failed both payment and process
//            catch (StripeException e)
//            {
//                switch (e.StripeError.ErrorType)
//                {
//                    //if the user enters a card that can't be charged.
//                    case "card_error":
//                        return BadRequest(new {userId= user.Id, result = EnumList.PaymentResult.Failed.ToString(), message = "cardError", courseId, invoiceNumber, reason = reason.ToString()});
//                    //Failure to connect to Stripe's API
//                    case "api_connection_error":
//                    //API errors cover any other type of problem 
//                    case "api_error":
//                        return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "connectionError", courseId, invoiceNumber,reason = reason.ToString()});
//                    //Failure to properly authenticate yourself in the request.
//                    case "authentication_error":
//                        return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "authError", courseId, invoiceNumber,reason = reason.ToString()});
//                    //Invalid request errors arise when your request has invalid parameters.
//                    case "invalid_request_error":
//                        return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "connectionError", courseId, invoiceNumber,reason = reason.ToString()});
//                    //Too many requests hit the API too quickly.
//                    case "rate_limit_error":
//                        return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "connectionError", courseId, invoiceNumber,reason = reason.ToString()});
//                    // when a card number or expiration date is invalid or incomplete
//                    case "validation_error":
//                        return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "cardError", courseId, invoiceNumber,reason = reason.ToString()});
//                    default: return BadRequest(new {userId= user.Id,result = EnumList.PaymentResult.Failed.ToString(), message = "unknownCardError", courseId, invoiceNumber,reason = reason.ToString()});
//                }
//            }
//
//
//            
//            //Success payment and process
//            if(reason == EnumList.PaymentReason.Register)
//                if (CompleteRegistration(user.Id, courseId, reason, EnumList.PaymentMethod.Stripe, serviceId,
//                payAllNow, device).Result)
//                    return Ok(new {result = EnumList.PaymentResult.Success.ToString(), message = "success", courseId, invoiceNumber,reason = reason.ToString()});
//            if(reason == EnumList.PaymentReason.Invoice)
//                if(CompleteInvoicePayment(user.Id, invoiceNumber, courseId, serviceId, EnumList.PaymentMethod.Stripe, device).Result)
//                    return Ok(new {userId= user.Id, result = EnumList.PaymentResult.Success.ToString(), message = "success", courseId, invoiceNumber,reason =reason.ToString()});
//
//            
//            //The only case where the payment done but the process failed
//            return BadRequest(new {userId= user.Id, result = EnumList.PaymentResult.Error.ToString(), message = "cardPaymentDoneError", courseId, invoiceNumber,reason = reason.ToString()});
//        }
//
//
//
//        
//        
//        
//        //Create Vipps Payment
////        [Route("/Payment/CreateVipps/")]
//        [Authorize]
//        public async Task<IActionResult> CreateVipps(string courseId, EnumList.PaymentReason reason, [Bind("AuthCookies,Ip,DeviceType,OperatingSystem")]UserDevice device, bool payAllNow, int invoiceNumber)
//        {
//            
//            var invoice = _paymentService.GetInvoice(invoiceNumber);
//            var user = _context.Users.Find(_access.GetUserId(User));
//            
//            if(user == null)
//                return BadRequest(new{result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});
//            
//            
//            var orderId = "";
//            var transactionText = "";
//            decimal amountToPay = 0;
//
//
//
//
//
//            //Determine amount and description
//            switch (reason)
//            {
//                
//                case EnumList.PaymentReason.Register:
//                    //Check if course null
//                    var course = _courseService.GetCourse(courseId);
//                    if(course == null)
//                        return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});
//                    
//                    //Get on register invoice
//                    var registerInvoice = _paymentService.CreateOnRegisterInvoices(courseId, user)
//                        .SingleOrDefault(x => x.Reason == EnumList.InvoiceReason.Registration);
//                    
//                    //Determine the amount user wants to pay now
//                    if (payAllNow)
//                        amountToPay = course.Price;
//                    else
//                        amountToPay = registerInvoice?.Amount ?? 0;
//
//                    transactionText = $"{course.Subject}--{course.Code}";
//
//                    orderId = $"{course.Id.Split("-")[0]}-{user.Id.Split("-")[0]}-{Guid.NewGuid().ToString().Split("-")[0]}";
//                    break;
//                
//                
//                
//                
//                
//                
//                
//                
//                case EnumList.PaymentReason.Invoice:
//                    //Check if invoice is null
//                    if(invoice == null)
//                        return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", reason = reason, url = Url.Action("PaymentResult", "Payment")});
//
//                    if (string.IsNullOrEmpty(courseId))
//                        courseId = invoice.CourseId;
//                    amountToPay = invoice.CurrentAmount;
//                    transactionText = $"Faktura{invoiceNumber}-KID{invoice.CIDNumber}";
//                    orderId =
//                        $"{invoiceNumber}-{invoice.CIDNumber}-{Guid.NewGuid().ToString().Split("-")[0]}";
//                    break;
//                
//                
//                
//                
//                
//                
//                
//                case EnumList.PaymentReason.Donate:
//                case EnumList.PaymentReason.Empty:
//                case EnumList.PaymentReason.Other:
//                default:
//                    return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", courseId = courseId, invoiceNumber = invoice.Number, reason = reason, url = Url.Action("PaymentResult", "Payment")});
//            }
//
//
//
//
//
//            if (amountToPay <= 0)
//                return BadRequest(new{userId= user.Id, result = EnumList.PaymentResult.Failed, message = "error", courseId = courseId, invoiceNumber = invoice.Number, reason = reason, url = Url.Action("PaymentResult", "Payment")});
//
//            var initiatedOrder = new InitiatedOrder()
//            {
//                User = user, Reason = reason, CourseId = courseId, InvoiceNumber = invoiceNumber, Ip = device.Ip,
//                Amount = amountToPay, PayAllNow = payAllNow, Id = orderId, DeviceType = device.DeviceType,
//                AuthCookies = device.AuthCookies, OperatingSystem = device.OperatingSystem
//            };
//            await _context.AddAsync(initiatedOrder);
//            await _context.SaveChangesAsync();
//
//            try
//            {
//                await _email.FollowPaymentLink(user.Id, $"{StaticInformation.FullWebsite}/Payment/FollowPayment?orderId={orderId}");
//
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"Error in {orderId}");
//                Console.WriteLine(e);
//            }
//            
//            
//
//            var accessToken = VippsAccessToken().Result;
//            
//            var queryString = HttpUtility.ParseQueryString(string.Empty);
//            
//            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
//            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
//            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments?" + queryString;           
//            
//            HttpResponseMessage response;
//            
//            
//            
//            
//            var vippsPayment = new VippsPayment()
//            {
//                transaction = new transaction()
//                {
//                    amount = (int) amountToPay*100,
//                    orderId = orderId,
//                    transactionText = transactionText
//                },
//                customerInfo = new customerInfo()
//                {
//                    mobileNumber = $"{user.PhoneNumber}", // ToDo :: Change this number on production
//                }
//            };
//            
////            _config.GetSection("liveWebsite").Value
//            vippsPayment.merchantInfo.fallBack =
//                StaticInformation.FullWebsite + "/VippsCallBack?" +
//                "userId="+user.Id+
//                "&orderId=" + vippsPayment.transaction.orderId +
//                "&courseId=" + courseId +
//                "&invoiceNumber=" + invoiceNumber +
//                "&payAllNow=" + payAllNow +
//                "&amount=" + (int) amountToPay +
//                "&reason=" + reason +
//                "&ip=" + device.Ip+
//                "&deviceType=" + device.DeviceType+
//                "&operatingSystem=" + device.OperatingSystem+
//                "&authCookies=" + device.AuthCookies+
//                "&token=" + accessToken;
//
////            vippsPayment.merchantInfo.callbackPrefix = vippsPayment.merchantInfo.fallBack;
////            if (device.DeviceType == EnumList.DeviceType.Mobile)
////            {
////                vippsPayment.merchantInfo.isApp = true;
////            }
//            
//            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));
//
//
//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = Client.PostAsync(uri, content).Result;
//                var responseString = response.Content.ReadAsStringAsync().Result;
//                JObject parseResponse = JObject.Parse(responseString);
//                var url = parseResponse["url"];
//                
//                
//                //Run Task to give the payment 5 minutes to cancel if not completed, then return
////                Task.Factory.StartNew(CheckVippsPayment(orderId));
////                Task.Factory.StartNew( () => CheckVippsPayment(orderId, "Bearer "+accessToken), CancellationToken.None,
////                    TaskCreationOptions.LongRunning, 
////                    TaskScheduler.Default);
//                
//                
//                return Ok(url);
//                
//            }
//
//            
//        }
//        
//        
//        
////        [Route("/VippsRefund")]
//        [Authorize(Policy = "Admin")]
//        public async Task<IActionResult> Refund(string paymentId, string orderId, decimal amount)
//        {
//
//            var payment = _context.Payments.Find(paymentId);
//            if (payment == null)
//                return NotFound("Payment id not found");
//            
//            var queryString = HttpUtility.ParseQueryString(string.Empty);
//
//            var accessToken = VippsAccessToken().Result;
//
//            Client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ accessToken);
//            Client.DefaultRequestHeaders.Add("X-Request-Id", orderId);
//            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
//            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//            
//            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/refund?" + queryString;
//            HttpResponseMessage response;
//            
//            var vippsPayment = new VippsPayment()
//            {
//                merchantInfo = new merchantInfo(),
//                transaction = new transaction()
//                {
//                    amount = (int) amount*100,
//                    transactionText = "Refund payment: "+paymentId+" - amount: "+ amount
//                    
//                },
//                customerInfo = null,
//            };
//            
//            
//            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));
//            var processStatus = 0;
//
//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = await Client.PostAsync(uri, content);
//                var responseString = response.Content.ReadAsStringAsync().Result;
//                processStatus = (int) response.StatusCode;
//            }
//
//            if (processStatus != 200) return BadRequest("The process failed!");
//            
//            payment.ExtraDescription = "Refunded: " + amount;
//            payment.RefundedAt = Format.NorwayDateTimeNow();
//            payment.Refunded = true;
//            
//
//            _context.Update(payment);
//            _context.SaveChanges();
//
//
//            var relatedInvoice = _context.Invoices.SingleOrDefault(x => x.PaymentId == paymentId);
//
//            if (relatedInvoice == null) return Ok();
//            relatedInvoice.Paid = false;
//            relatedInvoice.Canceled = true;
//            _context.Update(relatedInvoice);
//            _context.SaveChanges();
//
//
//            return Ok();
//
//
//        }
//
//
////        [Route("/Payment/FollowPayment")]
//
//        public async Task<IActionResult> FollowPayment(string orderId)
//        {
//
//            var order = _context.InitiatedOrders.FirstOrDefault(x => x.Id == orderId);
//            if (order == null)
//                return RedirectToAction("Error", "Home");
//
//            //Send email to user that has
//            //string userId, string orderId, string courseId, bool payAllNow, int amount, EnumList.PaymentReason reason, int invoiceNumber, UserDevice device, string token
//
//
//            var queryString = HttpUtility.ParseQueryString(string.Empty);
//            var token = VippsAccessToken().Result;
//            var accessToken = "Bearer " + token;
//            var fullResult = "NONE";
//
//            Client_Check.DefaultRequestHeaders.Add("Authorization", accessToken);
//            Client_Check.DefaultRequestHeaders.Add("X-Request-Id", orderId);
//            Client_Check.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
//            Client_Check.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//
//            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/details";
//            HttpResponseMessage response;
//
//            var vippsPayment = new VippsPayment()
//            {
//                merchantInfo = new merchantInfo(),
//                transaction = new transaction()
//                {
//                    transactionText = "transaction test"
//                },
//
//                customerInfo = null,
//            };
//
//            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));
//
//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = Client_Check.GetAsync(uri).Result;
//                fullResult = await response.Content.ReadAsStringAsync();
//            }
//
//
//
//
//            try
//            {
//                var history = JObject.Parse(fullResult).SelectToken("transactionLogHistory");
//                var finalOperation = history.First["operation"].ToString();
//
//
//                if (finalOperation.Equals("RESERVE"))
//                {
//                    var device = new UserDevice()
//                    {
//                        Ip = order.Ip, DeviceType = order.DeviceType, AuthCookies = order.AuthCookies, OperatingSystem = order.OperatingSystem,
//                    };
//
//                    return RedirectToAction("VippsCallBack",
//                        new
//                        {
//                            userId = order.UserId, orderId = orderId, courseId = order.CourseId,
//                            payAllNow = order.PayAllNow, amount = (int) order.Amount, reason = order.Reason,
//                            invoiceNumber = order.InvoiceNumber, ip = device.Ip, deviceType = device.DeviceType,
//                            operatingSystem = device.OperatingSystem, authCookies = device.AuthCookies, token
//                        });
//                    //Return to capture
//                }
//                
//                if (finalOperation.Equals("CAPTURE"))
//                {
//                    return RedirectToAction("PaymentResult",
//                        new
//                        {
//                            userId = order.UserId, result = EnumList.PaymentResult.Success, reason = order.Reason,
//                            courseId = order.CourseId, invoiceNumber = order.InvoiceNumber, message = "success"
//                        });
//                    //Return to success
//                }
//                if (finalOperation.Equals("REFUND"))
//                {
//                    return Ok("Refunded - تم إعادة الدفعة مسبقاً");
//                }
//
//                if (finalOperation.Equals("INITIATE"))
//                {
//                    return RedirectToAction("Index",
//                        new {reason = order.Reason, courseId = order.CourseId, invoiceNumber = order.InvoiceNumber});
//                }
//
//                var exit = $"حدث خطأ يرجى إرسال الرمز التالي لنا: {orderId}";
//                
//                return Ok(new {history = history, finalValue = finalOperation});
//
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return Ok("Not exist");
//            }
//
//            
//
//            
//            
//            
//            
//            
//        }
//
//
//
//
//        //Vipps payment will return here
////        [Route("/VippsCallBack")]
//        public async Task<IActionResult>VippsCallBack(string userId, string orderId, string courseId, bool payAllNow, int amount, EnumList.PaymentReason reason, int invoiceNumber, UserDevice device, string token)
//        {
//            
//            
//            var paymentResponse = await VippsCapturePayment("Bearer " + token, orderId);
//
//            if (paymentResponse != 200) //The Money didn't paid
//                return RedirectToAction("PaymentResult",
//                    new {userId = userId, result = EnumList.PaymentResult.Failed, message = "errorVippsCanceled", reason = reason, courseId = courseId, invoiceNumber = invoiceNumber});
//
//
//
//            if (amount <= 0) // Money could be paid
//                return RedirectToAction("PaymentResult",
//                    new {userId = userId, result = EnumList.PaymentResult.Failed, message = "error", reason = reason, courseId = courseId, invoiceNumber = invoiceNumber});
//            
//            var user = _context.Users.Find(userId);
//            if (user == null)
//                return RedirectToAction("PaymentResult",
//                    new {userId = userId, result = EnumList.PaymentResult.Failed, message = "vippsPaymentDoneError", reason = reason});
//            
//            
//            var course = _courseService.GetCourse(courseId);
//            
//            //ToDo :: Redirect to success with reason etc ...
//            if(reason == EnumList.PaymentReason.Register)
//                if (await CompleteRegistration(userId, courseId, reason, EnumList.PaymentMethod.Vipps, orderId,
//                    payAllNow, device))
//                    return RedirectToAction("PaymentResult",
//                        new {userId=userId, result = EnumList.PaymentResult.Success, message = "success", reason = reason, courseId = courseId});
//            if(reason == EnumList.PaymentReason.Invoice)
//                if (await CompleteInvoicePayment(userId, invoiceNumber, courseId, orderId, EnumList.PaymentMethod.Vipps, device))
//                    return RedirectToAction("PaymentResult",
//                        new {userId=userId, result = EnumList.PaymentResult.Success, message = "success", reason = reason, invoiceNumber = invoiceNumber});
//
//            //ToDo :: payment done but something wrong
//            return RedirectToAction("PaymentResult",
//                new {userId= userId, result = EnumList.PaymentResult.Failed, message = "vippsPaymentDoneError", reason = reason});
//            
//            
//            
//        }
//
//
//
//        //Handler Free Registrations
////        [Route("/Payment/CreateFreeRegistration")]
//        public async Task<IActionResult> CreateFreeRegistration(string courseId, EnumList.DeviceType deviceType, string ip, EnumList.OperatingSystem operatingSystem, string authCookies)
//        {
//            var user = _context.Users.Find(_access.GetUserId(User));
//            var course = _courseService.GetCourse(courseId);
//
//            if (user == null || course == null || course.Price > 0)
//                return BadRequest(new {result = EnumList.PaymentResult.Failed.ToString(), message = "error", courseId,reason = EnumList.PaymentReason.Register.ToString()});
//
//
//            var registration = new Registration
//            {
//                Course = course, Student = user, Price = 0, IpAddress = ip, AuthCookies = authCookies,
//                ExpireDate = Format.NorwayDateTimeNow().AddYears(1)
//            };
//
//            var isNew = _info.IsDeviceNew(user.Id, authCookies, ip);
//            var groupNumber = _info.GetDeviceGroupNumber(user.Id, authCookies, ip);
//            
//            var device = new UserDevice
//            {
//                Activity = EnumList.Activity.CourseRegister, Ip = ip, User = user,
//                DeviceType = deviceType, AuthCookies = authCookies, OperatingSystem = operatingSystem,
//                New = isNew, GroupNumber = groupNumber
//            };
//
//            _context.Add(registration);
//            _context.SaveChanges();
//            _context.Add(device);
//            _context.SaveChanges();
//                        
//            
//            await _email.CourseRegisterCompletedEmail(user.Id, courseId,Format.NorwayDateTimeNow().AddYears(1));
//            
//            
//            return Ok(new {result = EnumList.PaymentResult.Success.ToString(), message = "success", courseId,reason = EnumList.PaymentReason.Register.ToString(), userId= user.Id});
//        }
//        
//        
//        
//        
//        //Get Vipps access token
//        private async Task<string> VippsAccessToken()
//        {
//            
//            Client.DefaultRequestHeaders.Add("X-Version","1");
//            Client.DefaultRequestHeaders.Add("client_id", VippsParameter["client_id"]);
//            Client.DefaultRequestHeaders.Add("client_secret", VippsParameter["client_secret"]);
//            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//
//
//            var response = await Client.PostAsync(VippsParameter["vippsBaseUrl"]+"/accessToken/get", null);
//
//            var responseString = await response.Content.ReadAsStringAsync();
//            
//             
//            JObject parseResponse = JObject.Parse(responseString);
//
//            var accessToken = parseResponse["access_token"];
//
//            return accessToken.ToString();
//        }
//
//        
//        //Done the Vipps payment
//        private async Task<int> VippsCapturePayment(string token, string orderId)
//        {
//            var queryString = HttpUtility.ParseQueryString(string.Empty);
//
//            Client.DefaultRequestHeaders.Add("Authorization", token);
//            Client.DefaultRequestHeaders.Add("X-Request-Id", orderId);
//            Client.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
//            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
//
//            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/capture?" + queryString;
//            HttpResponseMessage response;
//
//            var vippsPayment = new VippsPayment()
//            {
//                merchantInfo = new merchantInfo(),
//                transaction = new transaction()
//                {
//                    transactionText = "transaction test"
//                },
//
//                customerInfo = null,
//            };
//
//            byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(vippsPayment));
//
//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = Client.PostAsync(uri, content).Result;
//                var responseString = await response.Content.ReadAsStringAsync();
//                return (int) response.StatusCode;
//            }
//        }
//
//
//        //Complete an invoice payment
//        private async Task<bool> CompleteInvoicePayment(string userId, int invoiceNumber, string courseId, string serviceId, EnumList.PaymentMethod method, UserDevice userDevice)
//        {
//            var course = _courseService.GetCourse(courseId);
//            var invoice = _paymentService.GetInvoice(invoiceNumber);
//            var user = _context.Users.FindAsync(userId).Result;
//            if (invoice == null || user == null)
//                return false;
//            
//            if(course== null)
//                course = new Course();
//
//            var payment = new MatterixPayment
//            {
//                User = user, Course = course, Amount = invoice.CurrentAmount, Reason = EnumList.PaymentReason.Invoice,
//                Invoice = invoice, PaymentServiceRef = serviceId, Method = method
//            };
//
//
//            await _context.AddAsync(payment);
//            await _context.SaveChangesAsync();
//            
//            invoice.Paid = true;
//            invoice.PaymentId = payment.Id;
//            invoice.NextNotification = DateTime.MaxValue;
//
//            _context.Update(invoice);
//            await _context.SaveChangesAsync();
//            
//            var isNew = _info.IsDeviceNew(user.Id, userDevice.AuthCookies, userDevice.Ip);
//            var groupNumber = _info.GetDeviceGroupNumber(user.Id, userDevice.AuthCookies, userDevice.Ip);
//            
//            var device = new UserDevice
//            {
//                User = user, Activity = EnumList.Activity.Payment, Ip = userDevice.Ip, DeviceType = userDevice.DeviceType, AuthCookies = userDevice.AuthCookies,
//                New = isNew, GroupNumber = groupNumber, OperatingSystem = userDevice.OperatingSystem
//            };
//            await _context.AddAsync(device);
//            _context.SaveChanges();
//            
//            //Here the invoice and payments are done -- send the email
//            await _email.InvoicePaidEmail(invoiceNumber);
//            
//            return true;
//        }
//        
//        //Complete the registration
//        private async Task<bool> CompleteRegistration(string userId, string courseId, EnumList.PaymentReason reason, EnumList.PaymentMethod method, string serviceId, bool payAllNow, UserDevice userDevice)
//        {
//            var course = _courseService.GetCourse(courseId);
//            var user = _context.Users.Find(userId);
//            
//            //Check if user is null
//            if (user == null || reason != EnumList.PaymentReason.Register)
//                return false;//Check if course is null
//            if (course == null)
//                return false;
//            
//            //Add the device made the registration
//                    
//            var isNew = _info.IsDeviceNew(user.Id, userDevice.AuthCookies, userDevice.Ip);
//            var groupNumber = _info.GetDeviceGroupNumber(user.Id, userDevice.AuthCookies, userDevice.Ip);
//            var device = new UserDevice
//            {
//                User = user, Activity = EnumList.Activity.CourseRegister, Ip = userDevice.Ip, DeviceType = userDevice.DeviceType, AuthCookies = userDevice.AuthCookies,
//                New = isNew, GroupNumber = groupNumber, OperatingSystem = userDevice.OperatingSystem
//            };
//            await _context.AddAsync(device);
//            await _context.SaveChangesAsync();
//                    
//            //Add payment activity
//            var device2 = new UserDevice
//            {
//                User = user, Activity = EnumList.Activity.Payment, Ip = userDevice.Ip, DeviceType = userDevice.DeviceType, AuthCookies = userDevice.AuthCookies,
//                New = isNew, GroupNumber = groupNumber
//            };
//            await _context.AddAsync(device2);
//            await _context.SaveChangesAsync();
//
//            //Determine registration expire date
//            var expireDate = _courseService.EstimateRegExpireDate(courseId);
//                    
//            //Add registration
//            await _courseService.AddOrRenewRegistration(courseId, userId, device);        
//            
//            
//            
//                    
//                    
//            //Add invoices
//
//            var paidInvoice = new MatterixInvoice();
//                    
//            if (payAllNow)
//            {
//                paidInvoice = new MatterixInvoice
//                {
//                    Course = course, User = user, Amount = course.Price, CurrentAmount = course.Price, Paid = true, Reason = EnumList.InvoiceReason.Registration, OriginalDeadline = Format.NorwayDateTimeNow().AddDays(15), CurrentDeadline = Format.NorwayDateTimeNow().AddDays(15), OriginalDueDate = Format.NorwayDateTimeNow().Date, CurrentDueDate = Format.NorwayDateTimeNow().Date, InvoiceType = EnumList.InvoiceType.Invoice, 
//                };
////                paidInvoice = paidInvoice;
//                        
//                //This invoice is paid now
//                await _context.AddAsync(paidInvoice);
//                await _context.SaveChangesAsync();
//
//            }
//            else
//            {
//                var invoices = _paymentService.CreateOnRegisterInvoices(courseId, user);
//
//                foreach (var inv in invoices)
//                {
//                    if (inv.Reason == EnumList.InvoiceReason.Registration)
//                    {
//                        paidInvoice = inv;
//                        await _context.AddAsync(paidInvoice);
//                        await _context.SaveChangesAsync();
//                                
//                    }else if (inv.Reason == EnumList.InvoiceReason.MonthlyPayment)
//                    {
//                        await _context.AddAsync(inv);
//                        await _context.SaveChangesAsync();
//                    }
//                }
//
//            }
//                    
//            //Add Payment
//            var payment = new MatterixPayment
//            {
//                Course = course, User = user, Reason = EnumList.PaymentReason.Register, Invoice = paidInvoice,
//                Amount = paidInvoice.Amount, Method = method, PaymentServiceRef = serviceId
//            };
//
//            await _context.AddAsync(payment);
//            await _context.SaveChangesAsync();
//
//            paidInvoice.Paid = true;
//            paidInvoice.PaymentId = payment.Id;
//            paidInvoice.NextNotification = DateTime.MaxValue;
//            
//            _context.Update(paidInvoice);
//            await _context.SaveChangesAsync();
//            
//            
//            //Here the invoice and payments are done -- send the email
//            await _email.InvoicePaidEmail(paidInvoice.Number);
//                    
//
//            //Here the registration is done -- send email
//
//            await _email.CourseRegisterCompletedEmail(userId, courseId, expireDate);
//            return true;
//            
//
//            
//
//        }
//        
//        
//        //Check Vipps payment after 5 minutes
////        private async void CheckVippsPayment(string orderId, string token)
////        {
////            await Task.Delay(new TimeSpan(0, 0, 30));
////            
////            var accessToken = VippsAccessToken().Result;
////
////            Client_Check.DefaultRequestHeaders.Add("Authorization", "Bearer "+ accessToken);
////            Client_Check.DefaultRequestHeaders.Add("X-Request-Id", orderId);
////            Client_Check.DefaultRequestHeaders.Add("X-TimeStamp", DateTime.Now.ToString());
////            Client_Check.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);
////            
////            var uri = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/details?" + string.Empty;
////            HttpResponseMessage response;
////            
////            
////            var processStatus = 0;
////            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new VippsPayment()));
////
////            using (var content = new ByteArrayContent(byteData))
////            {
////                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
////                response = await Client_Check.GetAsync(uri);
////                var responseString = JObject.Parse(response.Content.ReadAsStringAsync().Result);
////                processStatus = (int) response.StatusCode;
////
////                var transactionResult = responseString["transactionLogHistory"].First["operation"];
////
////                if (processStatus != 200 || !string.Equals(transactionResult.ToString(), "INITIATE",
////                        StringComparison.CurrentCultureIgnoreCase)) return;
////                
////                var uri1 = VippsParameter["vippsBaseUrl"]+"/ecomm/v2/payments/" + orderId + "/cancel?" + string.Empty;
////                response = await Client_Check.PutAsync(uri1, content);
////                responseString = JObject.Parse(response.Content.ReadAsStringAsync().Result);
////            }            
////            
////
////            
////
////
////            
////        }
//        
//
//
//
////        [Route("/Payment/Result/{result}")]
//        public IActionResult PaymentResult(string userId, EnumList.PaymentResult result, EnumList.PaymentReason reason, string courseId, int invoiceNumber, string message)
//        {
//            //Shared variable
//            var vm = new PaymentResultViewModel
//            {
//                Reason = reason, Course = new Course(), Student = new ApplicationUser(),
//            };
//            var course = _courseService.GetCourse(courseId);
//            var student = _context.Users.Find(userId);
//
//
//            if (student == null)
//                result = EnumList.PaymentResult.Error;
//            
//            vm.Student = student;
//            
//            
//            //Determine payment reason
//            switch (reason)
//            {
//                case EnumList.PaymentReason.Register:
//                    if (course == null)
//                        return RedirectToAction("Error", "Home");
//
//                    vm.Course = course;
//                    break;
//                     
//                case EnumList.PaymentReason.Invoice:
//                    var invoice = _context.Invoices.Find(invoiceNumber);
//                    if(invoice == null)
//                        return RedirectToAction("Error", "Home");
//
//                    vm.Course = course ?? new Course();
//                    vm.Invoice = invoice;
//                    break;
//                    
//                
//                case EnumList.PaymentReason.Empty:
//                case EnumList.PaymentReason.Donate:
//                case EnumList.PaymentReason.Other:
//                default:
//                    return RedirectToAction("Error", "Home");
//            }
//
//            if (result == EnumList.PaymentResult.Success)
//                message = "success";
//
//            vm.message = string.IsNullOrEmpty(message) ? "error" : message;
//
//            vm.Result = result;
//
//            return View(vm);
//        }
//
//
//
//
//        
//        
//        
//        
//        
//        
//        
//        
//        
//        
//        
//        
//        
//        
//    }
//}