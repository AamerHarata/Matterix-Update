using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Matterix.Data;
using Microsoft.AspNetCore.Mvc;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Models.Vipps;
using System.Text;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Matterix.Controllers
{
    public class HomeController : Controller
    {
        //Used for Vipps Check
        private readonly HttpClient Client = new HttpClient();
        private readonly HttpClient Client_Check = new HttpClient();
        private readonly Dictionary<string, string> VippsParameter = new Dictionary<string, string>()
        {
            { "client_id", "01a71e9a-2472-4462-888c-2af384689e2d" }, { "client_secret", "N3MwaEpWWlJ1Y1BHTWs4ZjV5UlU=" }, {"Ocp-Apim-Subscription-Key", "7b411c67e04a4774ac83274bb7f388ed"},{"vippsBaseUrl", "https://api.vipps.no"}
        };
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CourseService _courseService;
        private readonly ApplicationDbContext _context;
        private readonly PaymentService _paymentService;
        private readonly IHostingEnvironment _environment;
        private readonly InformationService _information;
        private readonly EmailService _email;
        private readonly PdfService _pdf;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, CourseService courseService, ApplicationDbContext context, PaymentService paymentService, IHostingEnvironment environment, InformationService information, EmailService email, PdfService pdf)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _courseService = courseService;
            _context = context;
            _paymentService = paymentService;
            _environment = environment;
            _information = information;
            _email = email;
            _pdf = pdf;
        }



        public async Task<IActionResult> Index()
        {
            
            var user = _userManager.GetUserAsync(User).Result;

            //Prevent fake Id for already logged in user in Development mode
            if (User.Identity != null && User.Identity.IsAuthenticated && user == null)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Index));
            }
            
            
            //All Courses
            var vm = new HomeViewModel();
            if(User.HasClaim("Role", "Admin"))
                vm.AllCourses = _courseService.GetAllCourses();
            else
                vm.AllCourses = _courseService.GetAllCourses().Where(x=>!x.Hidden).ToList();
            
            vm.OwnCourses = new List<Course>();

            if (!User.Identity.IsAuthenticated) return View(vm);


            ViewBag.EmailVerified = user.EmailConfirmed;
            ViewBag.PhoneVerified = user.PhoneNumberConfirmed;
            ViewBag.StudentAgreementSigned = user.SignedStudentAgreement;
            
            
            //The user is student
            vm.OwnCourses = _courseService.GetOwnedCourses(user.Id).Where(x=>!x.Hidden).ToList();


            //The user is teacher
            if (User.HasClaim("Role", "Teacher"))
            {
                var teacherCourses =  _courseService.GetTeachCourses(user.Id).Where(x=>!x.Hidden).ToList();
                vm.OwnCourses.InsertRange(0, teacherCourses);

            }


            //The user is admin, mostly me
            if (User.HasClaim("Role", "Admin"))
            {
                vm.OwnCourses = vm.AllCourses;
            }
            
            
            
            var comingLectures = new List<Lecture>();
            
            
            var allHomework = new List<LectureFile>();
            var notDeliveredHomework = new List<LectureFile>();
            

            foreach (var course in vm.OwnCourses)
            {
                var nonCompletedLectures = _courseService.GetNonCompletedLectures(course.Id).Where(x=>x.Number> 0).ToList(); //Added number > 0 to avoid introduction lectures
                if(nonCompletedLectures.Any())
                    comingLectures.Add(nonCompletedLectures[0]);
                allHomework.AddRange(_context.Files.Include(x=>x.Lecture.Course).Where(x=>x.Lecture.CourseId == course.Id).Where(x=>x.IsHomeWork).Where(x=>x.DeadLine.Date >= Format.NorwayDateTimeNow().Date));
            }
            
            foreach (var course in vm.AllCourses)
            {
                var nonCompletedIntro = _courseService.GetNonCompletedLectures(course.Id).Where(x=>x.Title == "intro").ToList(); //Added introduction lectures to all people however
                if(nonCompletedIntro.Any())
                    comingLectures.Add(nonCompletedIntro[0]);
            }

            foreach (var homework in allHomework)
                if(!_context.Homework.Any(x=>x.StudentId == user.Id && x.LectureFile.Name == homework.Name && x.LectureFile.Lecture.Id == homework.LectureId))
                    notDeliveredHomework.Add(homework);
            

            
            
            vm.UpcomingLectures = comingLectures.Count != 0 ? comingLectures.Where(x=> x.Date.Date >= Format.NorwayDateTimeNow().Date).OrderBy(x => x.Date).ThenBy(x=>x.From).ToList() : new List<Lecture>();
            vm.UpcomingHomework = notDeliveredHomework.OrderBy(x=>x.DeadLine).ToList();
            vm.UpcomingInvoices = _paymentService.GetActiveInvoices(user.Id).OrderBy(x=>x.CurrentDueDate).ToList();
          
            
            
            
            //Check uncompleted orders where the money paid in vipps
            
            //Get possible uncompleted orders
            var anyOrders = _context.InitiatedOrders
                .Where(x => x.UserId == user.Id)
                .Where(x => x.PaymentMethod == EnumList.PaymentMethod.Vipps)
                .Any(x => x.Status == EnumList.OrderStatus.Initiated || x.Status == EnumList.OrderStatus.ActionRequired);

            if (anyOrders)
            {
                //Check the actual status of the orders
                CheckAndModifyOrders(user.Id);
            }
            
            
            //Get just the orders those require action
            vm.NonCompletedOrders = _context.InitiatedOrders.Where(x => x.UserId == user.Id)
                .Where(x => x.PaymentMethod == EnumList.PaymentMethod.Vipps)
                .Where(x=> x.Status == EnumList.OrderStatus.ActionRequired).ToList();


            return View(vm);
            
        }

        public IActionResult Test()
        {
            return View();
        }
        
        public IActionResult Privacy(){return View();}

        public IActionResult AboutUs(){return View();}
        
        
        

        [HttpGet]
        public IActionResult ContactUs()
        {
            ViewData["countries"] = _information.GetCountries();
            
            if (!User.Identity.IsAuthenticated)
                return View(new ContactViewModel());

            var user = _userManager.GetUserAsync(User).Result;
            
            return View(new ContactViewModel{FullName = $"{user.FirstName} {user.LastName}", User = user});
        }
        
        [HttpPost]
        public IActionResult ContactUs(ContactViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Device.Ip) || string.IsNullOrEmpty(viewModel.Device.AuthCookies))
                return RedirectToAction("Error");

            if (string.IsNullOrEmpty(viewModel.Message) || string.IsNullOrEmpty(viewModel.FullName) || string.IsNullOrEmpty(viewModel.User.PhoneNumber) || string.IsNullOrEmpty(viewModel.User.Email))
            {
                ModelState.AddModelError("fieldEmpty", "{{$t('message.completeTheForm')}}");
                
            }
            
            var contactMessage = new ContactMessage()
            {
                AuthCookies = viewModel.Device.AuthCookies, Ip = viewModel.Device.Ip, Name = viewModel.FullName,
                Email = viewModel.User.Email, PhoneNumber = viewModel.User.PhoneNumber,
                Message = viewModel.Message, Reason = viewModel.Reason
            };

            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user != null)
                    contactMessage.User = user;
            }
            
            //ToDo :: Handle the file here

            _context.Add(contactMessage);
            _context.SaveChanges();
            
            if(viewModel.File==null || viewModel.File.Length< 1)
            
                return Ok(contactMessage.Id.Split("-")[0]);


            

            var file = viewModel.File;


            if (file.Length > 25 * 1024 * 1024)
            {
                ModelState.AddModelError("fileError", "{{$t('message.largeFileMax25')}}");
                return BadRequest("largeFileMax25");
            }
            
            
            var fileName = file.FileName;
            var acceptedFiles = new List<string>()
            {
                "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "application/vnd.ms-powerpoint",
                "application/pdf", "application/vnd.geogebra.file", "image/png", "image/jpeg"
            };

            if (!acceptedFiles.Contains(file.ContentType))
            {
                
                ModelState.AddModelError("fileError", "{{$t('message.fileTypeNotSupported')}}");
                return BadRequest("fileTypeNotSupported");
            }

            if (fileName.Length > 200)
                return BadRequest("errorHappened");
            
            
            fileName = Guid.NewGuid().ToString().Split("-")[0]+ fileName;

            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string fileFolder = "Files";
            const string contact = "ContactFiles";

            
            var fileSaveTargetPath = Path.Combine(envRoot, root, fileFolder, contact, fileName);
            var fileGetPath = "~/" + fileFolder + "/" + contact + "/" + fileName;

            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            if(Directory.GetDirectories(envRoot+"/"+root+"/"+fileFolder, "ContactFiles").Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+contact));



            


            


            try
            {
                using (var stream = new FileStream(fileSaveTargetPath, FileMode.Create))
                {
                    file.CopyToAsync(stream).Wait();
                }


                contactMessage.FileRootPath = fileSaveTargetPath;
                contactMessage.FileGetPath = fileGetPath;
                contactMessage.FileName = fileName;
                _context.Update(contactMessage);
                _context.SaveChanges();
                
                
                return Ok(contactMessage.Id.Split("-")[0]);;

        }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("fileError", "{{$t('message.fileTypeNotSupported')}}");
                return BadRequest("errorRefresh");
            }
        }


        [Authorize]
        public async Task<IActionResult> ContactMessages()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Error");

            var messages = await _context.ContactMessages.Where(x => x.UserId == user.Id)
                .OrderByDescending(x => x.DateTime).ToListAsync();
            
            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> JobApplication()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View();
            
            var previousApplications = await _context.JobApplications.Where(x => x.UserId == user.Id).ToListAsync();
            var vm = new JobApplicationViewModel(){Application = new JobApplication(), PreviousApplications = previousApplications};
            
            return View(vm);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> JobApplication(JobApplication application, IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Error");
            
            var vm = new JobApplicationViewModel(){Application = application};
            
            if (string.IsNullOrEmpty(application.CourseName) || string.IsNullOrEmpty(application.VideoLink) || file == null)
                return View(vm);
            
            
            
            //Adding file
            if (file.Length > 25 * 1024 * 1024)
            {
                ModelState.AddModelError("fileError", "{{$t('message.largeFileMax25')}}");
                return View(vm);
            }
            
            
            var fileName = file.FileName;
            var acceptedFiles = new List<string>()
            {
                "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "application/vnd.ms-powerpoint",
                "application/pdf", "application/vnd.geogebra.file", "image/png", "image/jpeg"
            };

            if (!acceptedFiles.Contains(file.ContentType))
            {
                
                ModelState.AddModelError("fileError", "{{$t('message.fileTypeNotSupported')}}");
                return RedirectToAction("Error");
            }

            
            fileName = Guid.NewGuid().ToString().Split("-")[0]+ fileName;

            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string fileFolder = "Files";
            const string contact = "JobApplicationCvs";

            
            var fileSaveTargetPath = Path.Combine(envRoot, root, fileFolder, contact, fileName);
            var fileGetPath = "~/" + fileFolder + "/" + contact + "/" + fileName;

            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            if(Directory.GetDirectories(envRoot+"/"+root+"/"+fileFolder, contact).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+contact));



            try
            {
                using (var stream = new FileStream(fileSaveTargetPath, FileMode.Create))
                {
                    file.CopyToAsync(stream).Wait();
                }


                application.CvRootPath = fileSaveTargetPath;
                application.CvWebPath = fileGetPath;
                application.User = user;

                if (!application.VideoLink.Contains("http", StringComparison.CurrentCultureIgnoreCase))
                    application.VideoLink = $"https://{application.VideoLink}";
            
                await _context.AddAsync(application);
                await _context.SaveChangesAsync();

                await _email.JobApplicationReceived(application.Id);
                
                return Ok();

        }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(vm);
            }
            
        }


        public IActionResult Help()
        {
            return Ok();
        }
        
        
        
        
        public IActionResult Blocked(string userId)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            if (user == null || !user.Blocked)
            {
                return RedirectToAction("Index");
            }
            
            var devices = _context.UserDevices.Include(x => x.User).Where(x => x.UserId == user.Id)
                .OrderByDescending(x => x.DateTime).ToList();
            var invoices = _context.Invoices.Include(x => x.User).Include(x=>x.Course).ToList().Where(x => x.ActiveInvoice())
                .Where(x => x.UserId == userId).ToList();
            var address = _context.Addresses.Include(x => x.User).SingleOrDefault(x => x.UserId == userId);

            var totalAmount = 0;

            if (invoices.Any())
                totalAmount = (int) invoices.Sum(x => x.CurrentAmount);
            
            

            var blockedViewModel = new BlockedViewModel()
            {
                Devices = devices, User = user, Invoices = invoices, Address = address,
                ContactEmail = StaticInformation.ContactEmail,
                ContactPhone = StaticInformation.ContactNumber,
                TotalInvoices = totalAmount
            };
            
            return View(blockedViewModel);
        }


        
        [HttpGet]
        public IActionResult Schedule()
        {
            return View();
        }
        
        
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Schedule(IFormFile file)
        {
            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string images = "Images";
            const string newFileName = "Schedule.png";
            
            
            
            var fileSaveTargetPath = Path.Combine(envRoot, root, images,  newFileName);
            

            
            
            
            
            try
            {
                using (var stream = new FileStream(fileSaveTargetPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                
                
                return View();

            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("error");

            }
        }
        
        
        [HttpGet]
        [Route("/User/{username}")]
        public IActionResult UserProfile(string username)
        {
            var user = _context.Users.ToList().SingleOrDefault(x => string.Equals(x.ProfileUserName, username, StringComparison.CurrentCultureIgnoreCase));
            if (user == null)
                return RedirectToAction(nameof(Error));


            var courses = _context.Registrations.Where(x => x.StudentId == user.Id).Where(x=>!x.Canceled).OrderBy(x => x.RegisterDate).Select(x=>x.Course).ToList();
            var teachCourses = _context.Courses.Where(x => x.TeacherId == user.Id).ToList();

            
            ViewBag.ProfileOwner = false;
            
            if(User.Identity.IsAuthenticated)
                if(string.Equals(username, _userManager.GetUserAsync(User).Result.ProfileUserName, StringComparison.CurrentCultureIgnoreCase))
                    ViewBag.ProfileOwner = true;
                
            
            
            var profileVm = new UserProfileViewModel()
            {
                User = user, TeacherCourses = teachCourses, RegisteredCourses = courses
            };
            return View(profileVm);
        }
        
        [HttpPost]
        [Route("/home/ChangeUserName/")]
        [Authorize]
        public IActionResult ChangeUserName(string userId, string status)
        {

            if (!User.HasClaim("Role", "Admin"))
            {
                if (userId != _userManager.GetUserId(User))
                    return BadRequest("Access Denied");
            }

            var user = _userManager.GetUserAsync(User).Result;


            user.StatusMessage = status;
            _context.Update(user);
            _context.SaveChanges();

            return Ok(status);
        }
        
        
        
        
        [Route("/EmailNameValidation/")]
        public IActionResult IsEmailOrNameTaken(string email, string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return BadRequest("error");

            if (_context.Users.ToList().Any(x =>
                string.Equals(x.FirstName.Replace(" ", ""), firstName.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.LastName.Replace(" ", ""), lastName.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)))
                return BadRequest("nameIsTaken");
            if (_context.Users.ToList().Any(x => string.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase)))
                return BadRequest("emailIsTaken");

            return Ok();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        private void CheckAndModifyOrders(string userId)
        {
            
            var orders = _context.InitiatedOrders.Where(x => x.UserId == userId)
                .Where(x => x.PaymentMethod == EnumList.PaymentMethod.Vipps)
                .Where(x => x.Status == EnumList.OrderStatus.Initiated || x.Status == EnumList.OrderStatus.ActionRequired).ToList();
            
            var token = VippsAccessToken().Result;
            var accessToken = "Bearer " + token;
            
            Client_Check.DefaultRequestHeaders.Add("Authorization", accessToken);
            Client_Check.DefaultRequestHeaders.Add("X-TimeStamp", Format.NorwayDateTimeNow().ToString());
            Client_Check.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VippsParameter["Ocp-Apim-Subscription-Key"]);


            foreach (var order in orders)
            {
                
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
                    fullResult = response.Content.ReadAsStringAsync().Result;
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
                            if (order.Created.AddHours(1) < Format.NorwayDateTimeNow())
                            {
                                order.Status = EnumList.OrderStatus.Canceled;
                                _context.Update(order);
                                _context.SaveChanges();
                            }
                            continue;

                        case EnumList.VippsPaymentStatus.RESERVE:
                            //Important :: The payment is done but the process not completed --> Return true to show it to the user
                            order.Status = EnumList.OrderStatus.ActionRequired;
                            _context.Update(order);
                            _context.SaveChanges();
                            continue;

                        case EnumList.VippsPaymentStatus.CAPTURE:
                        case EnumList.VippsPaymentStatus.SALE:
                            //The money is paid and the order is completed in this case --> Set the order to be done the return false to remove it from view
                            order.Status = EnumList.OrderStatus.Completed;
                            _context.Update(order);
                            _context.SaveChanges();
                            continue;
                        case EnumList.VippsPaymentStatus.REJECTED:
                        case EnumList.VippsPaymentStatus.VOID:
                        case EnumList.VippsPaymentStatus.FAILED:
                        case EnumList.VippsPaymentStatus.CANCEL:
                        case EnumList.VippsPaymentStatus.INVALID: //The order is not exist (STRIPE Case)
                            //All those cases the money has not paid or returned so no action required, no need to hold the order in records
                            order.Status = EnumList.OrderStatus.Failed;
                            _context.Update(order);
                            _context.SaveChanges();
                            continue;

                        case EnumList.VippsPaymentStatus.REFUND:
                            order.Status = EnumList.OrderStatus.Canceled;
                            _context.Update(order);
                            _context.SaveChanges();
                            continue;


                        default:
                            order.Status = EnumList.OrderStatus.Failed;
                            _context.Update(order);
                            _context.SaveChanges();
                            continue;
                    }



                }
                catch (Exception e)
                {
                    //ToDo :: Order exists in my website but not in Vipps (This case can be stripe for example)
                    order.Status = EnumList.OrderStatus.Failed;
                    _context.Update(order);
                    _context.SaveChanges();
                }
                
                
            }
            
            
            
        }
        
        
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
        
        
        
        
        
        
        
    }
}
