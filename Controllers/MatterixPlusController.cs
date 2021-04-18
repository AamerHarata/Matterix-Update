using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Verify.V2.Service;

namespace Matterix.Controllers
{
    
    public class MatterixPlus : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FilesService _file;
        private readonly InformationService _info;
        private readonly CourseService _course;
        private readonly AccessService _access;
        private readonly PdfService _pdf;
        private readonly EmailService _email;

        public MatterixPlus(ApplicationDbContext context, UserManager<ApplicationUser> userManager, FilesService file, InformationService info, CourseService course, AccessService access, PdfService pdf, EmailService email)
        {
            _context = context;
            _userManager = userManager;
            _file = file;
            _info = info;
            _course = course;
            _access = access;
            _pdf = pdf;
            _email = email;
        }

        

        

        

        





        [Route("/plus")]
        public IActionResult Index()
        {
            
            var userId = _userManager.GetUserId(User);
            ViewBag.previousApplications = _context.PlusApplications.Any(x => x.StudentId == userId);
            return View();
        }

        [Route("plus/apply/Identity")]
        [HttpGet]
        public async Task<IActionResult> Identity()
        {
            ViewData["countries"] = _info.GetCountries();

            var studentId = _userManager.GetUserId(User)?? "";
            ViewBag.StudentId = studentId;
            
            if(User.Identity.IsAuthenticated && _context.PlusApplications.Where(x=>x.StudentId == studentId).Any(x=>x.Status == EnumList.ApplicationStatus.Declined))
                return RedirectToAction("Error", "Home"); // ToDo :: Return to view says that you have already declined application
            
            return View(new MatterixPlusApplication());
        }
        
        [Route("plus/apply/Identity")]
        [HttpPost]
        public async Task<IActionResult> Identity(MatterixPlusApplication application)
        {
            var user = await _context.Users.FindAsync(application.StudentId);
            if (user == null)
                return RedirectToAction("Error", "Home");
            
            if(_context.PlusApplications.Where(x=>x.StudentId == user.Id).Any(x=>x.Status == EnumList.ApplicationStatus.Declined))
                return RedirectToAction("Error", "Home"); // ToDo :: Return to view says that you have already declined application
                
            
            application.Student = user;
            
            await _context.AddAsync(application);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("ChooseCourses", new {applicationId = application.Id});
        }


        [Route("/plus/ChooseCourses")]
        [HttpGet]
        public async Task<IActionResult> ChooseCourses(string applicationId) //Add later parameter CourseId if any redirection to this action with a value
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if(application == null)
                return RedirectToAction("Error", "Home");

            ViewBag.applicationId = applicationId;
            
            var user = await _context.Users.FindAsync(application.StudentId);
            if (user == null)
                return RedirectToAction("Error", "Home");

            var studentId = user.Id;
            
            
            
            var allCourses = _course.GetAllCourses().Where(x => x.IsAvailable()).ToList();
            var courses = new List<Course>();
            
            
            //Add only not owned courses
            foreach (var course in allCourses)
                if(!_access.CourseViewAccess(studentId, course.Id))
                courses.Add(course);
            
            
            return View(courses);
            
        }

        [Route("/plus/ChooseCourses")]
        [HttpPost]
        public async Task<IActionResult> ChooseCourses(string applicationId, string coursesIds)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if (application == null)
                return RedirectToAction("Error", "Home");
            
            //If the applications has already courses, redirect user to the application page (Course re-choosing is not possible by the user)
            if(!string.IsNullOrEmpty(application.CoursesIds))
                return RedirectToAction("Application", new {applicationId, passCode = application.PassCode});

            application.CoursesIds = coursesIds;
            application.Status = EnumList.ApplicationStatus.PendingDocuments;
            _context.Update(application);
            await _context.SaveChangesAsync();

            
            
            //Do not send documents until I do from the admin panel
//            await _email.PlusApplicationReceivedUser(applicationId);
//            await _email.PlusApplicationReceivedOrg(applicationId);
            
            
            return RedirectToAction("Application", new {applicationId, passCode = application.PassCode});
        }
        
        
        [Route("/plus/application/{applicationId?}")]
        public async Task<IActionResult> Application(string applicationId, int passCode)
        {
            if (string.IsNullOrEmpty(applicationId))
                return RedirectToAction("Find");
            
            var application = await _context.PlusApplications.Where(x=>x.Id == applicationId).Include(x=>x.Student).SingleOrDefaultAsync();
            
            if(application == null || application.PassCode != passCode)
                return RedirectToAction("Find");

            //Add application courses
            var courses = new List<Course>();
            foreach (var courseId in application.CoursesIds.Split(",").ToList())
            {
                var course = _course.GetCourse(courseId);
                if(course == null)
                    continue;
                courses.Add(course);
            }

            var files = await _context.PlusApplicationFiles.Where(x => x.ApplicationId == applicationId).Select(x => x.File)
                .ToListAsync();

            var invoice = await _context.Invoices.Where(x => x.ApplicationId == applicationId).ToListAsync();

            var vm = new MatterixPlusViewModel
            {
                Application = application, Courses = courses, Files = files, Invoices = invoice
            };
            
            return View(vm);
        }
        
        [Route("/plus/application/find")]
        [HttpGet]
        public async Task<IActionResult> Find(int reference)
        {
            ViewBag.reference = reference == 0 ? "" : reference.ToString();
            ViewBag.passCode = "";
            return View();
        }
        
        [HttpPost]
        [Route("/plus/application/find")]
        public async Task<IActionResult> Find(int reference, int passCode)
        {
            ViewBag.reference = reference;
            ViewBag.passCode = passCode;
            
            var application = await _context.PlusApplications.Where(x => x.Reference == reference)
                .SingleOrDefaultAsync(x => x.PassCode == passCode);

            if (application != null)
                return RedirectToAction("Application", new {applicationId = application.Id, passCode = application.PassCode});
            
            ModelState.AddModelError("wrongInformation", "{{$t('message.wrongInformation')}}");
            
            return View();
        }


        [Route("/plus/application/UploadFile")]
        public async Task<IActionResult> UploadApplicationFile(string applicationId, IFormFile file)
        {

            var application = await _context.PlusApplications.FindAsync(applicationId);
            
            if (application == null || file == null || file.Length == 0)
                return BadRequest("errorRefresh");
            
            
            //Check file size and type
            if(!_file.IsSizeAllowed(EnumList.MatterixFileType.MatterixPlusApproval, file.Length))
                return BadRequest("largeFileMax25");
            if(!_file.IsTypeAllowed(EnumList.MatterixFileType.MatterixPlusApproval, file.ContentType))
                return BadRequest("fileTypeNotSupported");


            var fileId = _file.SaveFileToSystem(file, EnumList.MatterixFileType.MatterixPlusApproval,
                application.Reference.ToString());

            
            if (string.IsNullOrEmpty(fileId))
                return BadRequest("errorRefresh");
            
            var fileObject = _file.GetFileObject(fileId);
            
            if(fileObject == null)
                return BadRequest("errorRefresh");
            
            
            var plusFile = new PlusApplicationFile()
            {
                Application = application, File = fileObject
            };

            await _context.AddAsync(plusFile);
            await _context.SaveChangesAsync();
            
            //A Document has been received so the application is under processing
            application.Status = EnumList.ApplicationStatus.UnderProcessing;
            _context.Update(application);
            await _context.SaveChangesAsync();
            
            var messageToAdmin = new ContactMessage()
            {
                Reason = EnumList.Contact.AdminMessage, User = _context.Users.Find(application.StudentId), Message = $"Admission file in application {application.Reference} received. https://matterix.no/Admin/PlusApplicationsOverview"
            };

            try
            {
                await _context.AddAsync(messageToAdmin);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return Ok();
        }


        public IActionResult DownloadApplicationFile(string applicationId, EnumList.MatterixPlusRegDocument plusRegDocument)
        {
            return _pdf.GetMatterixApplicationFile(applicationId, plusRegDocument);
        }


        [Route("/plus/applications")]
        [Authorize]
        public async Task<IActionResult> Applications()
        {
            var userId = _userManager.GetUserId(User);
            var applications = await _context.PlusApplications.Where(x => x.StudentId == userId).ToListAsync();
            if (!applications.Any())
                return RedirectToAction("Error", "Home");
            
            return View(applications);
        }

        


        [Route("/plus/GetStudentIdentity")]
        public async Task<IActionResult> GetStudentIdentity(string phoneCode, string phoneNumber, string email)
        {
            phoneCode = phoneCode.Trim();
            phoneNumber = phoneNumber.Trim();
            email = email.Trim().ToUpper();
            var student = await _context.Users.Where(x => x.PhoneNumber == phoneNumber)
                .Where(x=> string.Equals(x.NormalizedEmail, email))
                .SingleOrDefaultAsync(x => x.PhoneCode == phoneCode);

            if (student == null)
                return BadRequest(); //ToDo :: Return that this user does not exist
            
            return Ok(new {studentId = student.Id});
        }

        [Route("/plus/SendVerificationCode")]
        public async Task<IActionResult> SendVerificationCode(string studentId)
        {
            var student = await _context.Users.FindAsync(studentId);
            if (student == null)
                return BadRequest();
            
            try
            {
                await VerificationResource.CreateAsync(
                    to: $"{student.PhoneCode}{student.PhoneNumber}",
                    channel: "sms",
                    pathServiceSid: StaticInformation.TwilioVerificationServiceSid
                );
                
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return BadRequest();
            
        }

        [Route("/plus/CheckVerificationCode")]
        public async Task<IActionResult> CheckVerificationCode(string studentId, string code)
        {
            var student = await _context.Users.FindAsync(studentId);
            if (student == null)
                return BadRequest();
            
            if (string.IsNullOrEmpty(code))
                return BadRequest("wrongCode");

            var name = $"{student.FirstName} {student.LastName}";
            var email = student.Email;

            try
            {
                var verification = await VerificationCheckResource.CreateAsync(
                    to: $"{student.PhoneCode}{student.PhoneNumber}",
                    code: code,
                    pathServiceSid: StaticInformation.TwilioVerificationServiceSid
                );
                
                if (verification.Status != "approved") return BadRequest("wrongCode");
                return Ok(new {name, email});

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return BadRequest();
        }


        
        
        
    }
}