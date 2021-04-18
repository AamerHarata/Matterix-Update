using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.Admin;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Rest.Api.V2010.Account.Usage.Record;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;


namespace Matterix.Controllers
{
    public class Admin : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly PaymentService _paymentService;
        private readonly EmailService _email;
        private readonly SmsService _sms;
        private readonly FilesService _files;
        private readonly CourseService _course;


        public Admin(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env,
            PaymentService paymentService,
            EmailService email,
            SmsService sms,
            FilesService files,
            CourseService course)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
            _paymentService = paymentService;
            _email = email;
            _sms = sms;
            _files = files;
            _course = course;

        }



        [Route("/Admin/{searchPattern?}")] //Done
        [Authorize(Policy = "Admin")]
        public IActionResult Index(string searchPattern)
        {
            //ToDo :: Give the correct access permissions: Admin / Director / Leader
            // if (!User.HasClaim("Role", "Admin"))
            //     return RedirectToAction("Error", "Home");
            // var admin = _userManager.GetUserAsync(User).Result;
            // if (admin != null)
            // {
            //     if(!string.Equals(_userManager.GetUserAsync(User).Result.Email, "AAMER.HARATA@HOTMAIL.COM",
            //     StringComparison.CurrentCultureIgnoreCase))
            //     return NotFound();
            // }


            
            var allUsers = new List<ApplicationUser>();
            
            if(string.IsNullOrEmpty(searchPattern)) //Users last month
                allUsers = _context.Users.ToList().Where(x=>x.SignUpDate > DateTime.Now.AddDays(-30)).OrderByDescending(x => x.SignUpDate).ToList();
            else
            {
                searchPattern = searchPattern.ToUpper();
                var splitPattern = searchPattern.Split(" ");
                
                var address = _context.Addresses.Include(x => x.User).ToList().Where(x =>
                    x.Street.ToUpper().Contains(searchPattern) || x.City.ToUpper().Contains(searchPattern));
                
                
                var userWithNameSearch = new List<ApplicationUser>();
                //ToDo :: Edit search pattern, just like in Invoices
                if (splitPattern.Length >= 2)
                    userWithNameSearch = _context.Users.ToList()
                        .Where(x => x.FirstName.ToUpper().Contains(splitPattern[0]) ||
                                    x.FirstName.ToUpper().Contains(splitPattern[1]) ||
                                    x.LastName.ToUpper().Contains(splitPattern[0]) ||
                                    x.LastName.ToUpper().Contains(splitPattern[1])).ToList();


                allUsers = _context.Users.ToList()
                    .Where(x => x.FirstName.ToUpper().Contains(searchPattern) || x.LastName.ToUpper().Contains(searchPattern) ||
                                x.Id.ToUpper().Contains(searchPattern) || x.NormalizedEmail.Contains(searchPattern) ||
                                x.PhoneNumber.ToString().Contains(searchPattern) ||
                                x.Role.ToString().ToUpper().Contains(searchPattern)).ToList();
                    ;

                    var enumerable = address.ToList();
                    if (enumerable.Any())
                    foreach (var adrs in enumerable)
                        allUsers.Add(adrs.User);
                
                if(userWithNameSearch.Any())
                    allUsers.AddRange(userWithNameSearch);

                allUsers = allUsers.OrderBy(x => x.SignUpDate).ToList();
            }

            return View(allUsers);
        }


        //Tested -- done
        [Authorize(Policy = "Admin")]
        [Route("/Admin/EditStudent/{userId}")] //Done
        [HttpGet]
        public async Task<IActionResult> EditStudent(string userId)
        {
            //ToDo :: Give the correct access permissions: Admin / Director / Leader
//            if (!User.HasClaim("Role", "Admin") || string.IsNullOrEmpty(userId))
//                return NotFound();
            // var admin = await _userManager.GetUserAsync(User);
            // if (admin != null)
            // {
            //     if(!string.Equals(_userManager.GetUserAsync(User).Result.Email.ToUpper(), "AAMER.HARATA@HOTMAIL.COM",
            //         StringComparison.CurrentCultureIgnoreCase))
            //         return NotFound();
            // }

            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            return View(user);
            
        }
        
        
        //Tested -- done
        [Authorize(Policy = "Admin")]
        [Route("/Admin/EditStudent/{userId}")] //Done
        [HttpPost]
        public async Task<IActionResult> EditStudent([Bind("FirstName,LastName,MiddleName,ProfileUserName,Email,BirthDate,SignUpDate,Role,Gender,BlockType,BlockDate,BlockDescription,PersonalNumber,CurrentPassword,PhoneNumber,EmailConfirmed,PhoneNumberConfirmed,LockoutEnd,Language")]
            ApplicationUser newUser, string userId, string city, string street, string zipcode)
        
        {
            
            
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var address = _context.Addresses.Include(x => x.User).SingleOrDefault(x => x.UserId == user.Id);
            if (user == null)
                return NotFound("User is null");
            if (address == null)
            {
                address= new Address(){User = user};
                _context.Add(address);
                await _context.SaveChangesAsync();
            }
            
            newUser.Id = user.Id;

            if (_context.Users.ToList().Where(x=>x.Id != user.Id).Any(x => string.Equals(x.ProfileUserName, newUser.ProfileUserName, StringComparison.CurrentCultureIgnoreCase)))
            {
                ViewData["uniqueUserName"] = "Username Exists!";
                return View(newUser);
            }
            
            //ToDo :: Centralize IsEmailOrUserNameTaken() Function 
            if (_context.Users.ToList().Where(x=>x.Id != user.Id).Any(x => string.Equals(x.FirstName, newUser.FirstName, StringComparison.CurrentCultureIgnoreCase) && string.Equals(x.LastName, newUser.LastName, StringComparison.CurrentCultureIgnoreCase)))
            {
                ViewData["uniqueName"] = "Name Exist!";
                return View(newUser);
            }
            
            var setUsernameResult = _userManager.SetUserNameAsync(user, newUser.Email);
            if (!setUsernameResult.Result.Succeeded)
            {
                ViewData["uniqueEmail"] = "Email Taken!";
                return View(newUser);
            }
            
            //ToDo :: Try to set the password here

            _userManager.SetEmailAsync(user, newUser.Email).Wait();
            user.FirstName = newUser.FirstName;
            user.MiddleName = newUser.MiddleName;
            user.LastName = newUser.LastName;
            user.ProfileUserName = newUser.ProfileUserName;
            user.LockoutEnd = newUser.LockoutEnd;
            
            //ToDo :: Prevent to change me from admin, change climes add or remove
            user.Role = newUser.Role;
            
            // ToDo :: Modify the edition of clime / role with keeping the security of no changing in Aamer Harata 
            if(!string.Equals(user.Email, "Aamer.harata@hotmail.com", StringComparison.CurrentCultureIgnoreCase)){
                if (newUser.Role == EnumList.Role.Admin)
                {
                    await _userManager.AddClaimAsync(user, new Claim("Role", "Admin"));
                }else if (newUser.Role == EnumList.Role.Teacher)
                {
                    await _userManager.AddClaimAsync(user, new Claim("Role", "Teacher"));
                    await _userManager.RemoveClaimAsync(user, new Claim("Role", "Admin"));
                }
                else
                {
                
                    await _userManager.RemoveClaimAsync(user, new Claim("Role", "Teacher"));
                    await _userManager.RemoveClaimAsync(user, new Claim("Role", "Admin"));
                    
                }
            }
            
            
            user.Gender = newUser.Gender;
            
            user.Language = newUser.Language;
            user.BirthDate = newUser.BirthDate;
            user.BlockDate = newUser.BlockDate;
            user.SignUpDate = newUser.SignUpDate;
            user.PersonalNumber = newUser.PersonalNumber;
            user.BlockType = newUser.BlockType;
            user.PhoneNumber = newUser.PhoneNumber;
            user.EmailConfirmed = newUser.EmailConfirmed;
            user.PhoneNumberConfirmed = newUser.PhoneNumberConfirmed;
            address.Street = street;
            address.City = city;
            address.ZipCode = zipcode;

            if (user.CurrentPassword != newUser.CurrentPassword)
            {
                var addPasswordResult = await _userManager.ChangePasswordAsync(user, user.CurrentPassword, newUser.CurrentPassword);
                if (addPasswordResult.Succeeded)
                {
                    user.CurrentPassword = newUser.CurrentPassword;
                    var usedPassword = new UsedPassword()
                    {
                        User = user, PlaceCreated = "Admin", DateCreated = Format.NorwayDateTimeNow(), Password = user.CurrentPassword
                    };
                    _context.Add(usedPassword);
                }
                else
                {
                    ViewData["setPassword"] = "The Password didn't success!";
                }
            }
                   

            _context.Update(user);
            await _context.SaveChangesAsync();
            

            return View(user);
            
        }


        //Tested -- Done
        [Authorize(Policy = "Admin")]
        [Route("/Admin/UserPage/{userId}")]
        public  IActionResult UserPage(string userId)
        {
            //ToDo :: Give the correct access permissions according to the role: Admin / Director (Must be created). 
            // var admin = _userManager.GetUserAsync(User).Result;
            // if (admin != null)
            // {
            //     if(!string.Equals(_userManager.GetUserAsync(User).Result.Email.ToUpper(), "AAMER.HARATA@HOTMAIL.COM",
            //         StringComparison.CurrentCultureIgnoreCase))
            //         return NotFound();
            // }
            
            
            var user = _context.Users.Find(userId);
            if (userId == null || user == null)
            {
                return BadRequest();
            }

            var payments = _context.Payments.Include(x => x.Course).Include(x => x.User)
                .Where(x=>x.UserId == userId).OrderByDescending(x=>x.DateTime).ToList();
            var invoices = _context.Invoices.Include(x => x.Course).Include(x => x.User)
                .Where(x => x.UserId == userId).OrderByDescending(x => x.CreateDate).ToList();
            var feedback = _context.CourseFeedback.Include(x => x.User).Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateTime).ToList();
            var ratings = _context.Ratings.Include(x => x.Course).Include(x => x.User)
                .Where(x => x.UserId == userId).ToList();
            var registrations = _context.Registrations.Include(x => x.Student).Include(x => x.Course)
                .Where(x => x.StudentId == userId).OrderByDescending(x => x.RegisterDate).ToList();
            var passwords = _context.UsedPasswords.Include(x => x.User).Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateCreated).ToList();
            var activities = _context.UserDevices.Include(x => x.User).Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateTime).ToList();
            var openLecture = _context.OpenLectures.Where(x => x.StudentId == userId).Include(x=>x.Lecture)
                .Include(x=>x.Lecture.Course).OrderBy(x => x.Lecture.CourseId).ThenBy(x=>x.Lecture.Number).ToList();

            var increments = new List<InvoiceIncrement>();
            foreach(var inv in invoices)
                increments.AddRange(_context.Increments.Where(x=>x.InvoiceNumber == inv.Number).Include(x=>x.Invoice).ToList());
            
            ViewData["Courses"] = new SelectList(from x in _context.Courses.OrderByDescending(x=>x.StartDate) select new {x.Id, x.Subject, x.Code, FullName= x.Subject + " / " + x.Code}
                , "Id", "FullName");
            
            var adminViewModel = new AdminViewModel()
            {
                User = user, Payments = payments, Invoices = invoices, FeedBacks = feedback, Ratings = ratings, Registrations = registrations,
                Passwords = passwords, Activities = activities, OpenLectures = openLecture, Increments = increments
            };
            
            
            
            
            
            return View(adminViewModel);
        }





        [Authorize(Policy = "Admin")]
        [Route("/Admin/CancelInvoice")]
        public async Task<IActionResult> CancelInvoice(int invoiceNumber)
        {

            var invoice = await _context.Invoices.FindAsync(invoiceNumber);
            if (invoice == null)
                return NotFound("Invoice not found");
            invoice.Canceled = true;
            invoice.Paid = false;

            _context.Update(invoice);
            await _context.SaveChangesAsync();
            
            var possiblePayment = _context.Payments.SingleOrDefault(x => x.InvoiceNumber == invoiceNumber);
            if (possiblePayment == null) return Ok();
            possiblePayment.Refunded = true;
            possiblePayment.RefundedAt = Format.NorwayDateTimeNow();
            possiblePayment.ExtraDescription = $"Refunded with canceling invoice nr: {invoiceNumber}";
            _context.Update(possiblePayment);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        
    



        [Route("/Admin/SendEmail/")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendEmail(string userId, string subject, string body, EnumList.Language language)
        {
            
            
            await _email.CustomAdminEmail(userId, subject, body, language);
            
            
            return Ok();
        }
        
        
        
        
        [Route("/Admin/SendGroupEmail/")] 
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendGroupEmail(string courseId, string subject, string body, EnumList.Language language)
        {

            var registrations = _context.Registrations
                .Where(x => x.CourseId == courseId)
                .ToList()
                .Where(x => x.IsActive())
                .ToList();

            var ids = new List<string>();
            
            
            foreach(var reg in registrations)
                ids.Add(reg.StudentId);
            
            ids.Add(_context.Courses.Find(courseId).TeacherId);
            ids.Add(StaticInformation.AdminMatterixId);
            
            
            
            await _email.CourseGroupEmail(ids , subject , body, language);
            
            
            return Ok();
        }
        
        
        
        [Route("/Admin/SendGroupSms/")] 
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendGroupSms(string courseId, string body)
        {

            var registrations = _context.Registrations.ToList()
                .Where(x => x.IsActive()).Where(x => x.CourseId == courseId)
                .ToList();

            var ids = new List<string>();
            
            
            foreach(var reg in registrations)
                ids.Add(reg.StudentId);

            var teacherId = _context.Courses.Find(courseId).TeacherId;
            ids.Add(teacherId);
            
            //ToDo :: Remove Admin Id when everything is fine
            if(teacherId != StaticInformation.AdminMatterixId)
                ids.Add(StaticInformation.AdminMatterixId);



            await _sms.GroupSms(ids, body);
            
            
            return Ok();
        }
        
        
        
        

        //Tested -- Done
        [Route("/Admin/SendInvoiceReminder/")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendInvoiceReminder(string userId, int invoiceNumber)
        {
            await _email.InvoiceReminderEmail(invoiceNumber);

            return Ok();
        }
        

        
        
        
        //Tested -- Done
        [Route("/Admin/BlockUser/")] 
        [Authorize(Policy = "Admin")]
        public IActionResult BlockUser(string userId, bool blockTheUser, EnumList.Block blockType, string message)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            if(user == null)
                return NotFound("The user is null");
            if (user.Role == EnumList.Role.Admin)
                return NotFound("We Cannot Block The Admin");
            user.Blocked = blockTheUser;
            user.BlockDate = Format.NorwayDateTimeNow();
            user.BlockType = blockType;
            user.BlockDescription = message;
            
            _context.Update(user);
            _context.SaveChanges();
            
            //Sign the user out
            _userManager.UpdateSecurityStampAsync(user).Wait();
            
            return Ok();
        }

        //Tested -- Done
        [Route("/Admin/EditReg")] 
        [Authorize(Policy = "Admin")]
        public IActionResult EditRegistration(string userId, string courseId, decimal price, DateTime expDate, bool exp, string comment, bool cancel)
        {
            var reg = _context.Registrations
                .Where(x => x.CourseId == courseId)
                .SingleOrDefault(x => x.StudentId == userId);


            if (reg == null)
                return NotFound();
            reg.Price = price;
            reg.ExpireDate = expDate;
            reg.AdminComment = comment;
            reg.Expire = exp;
            reg.Canceled = cancel;

            _context.Update(reg);
            _context.SaveChanges();

            return Ok();
        }

        
        
        //Tested -- done
        [Route("/Admin/AddReg")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddRegistration(string userId, string courseId, decimal price, DateTime expDate,
            string comment)
        {
            if (_context.Registrations.Include(x => x.Student).Include(x => x.Course)
                .Any(x => x.StudentId == userId && x.CourseId == courseId))
                return BadRequest("Already registered");
            
            
            var course = _context.Courses.Find(courseId);
            var student = _userManager.FindByIdAsync(userId).Result;
            
            if(expDate == DateTime.MinValue)
                expDate = Format.NorwayDateTimeNow().AddYears(1);
            
            if (course == null || student == null)
                return BadRequest("Course or student, or both are null");
            
            if(userId == course.TeacherId)
                return BadRequest("This student is course teacher");
            
            var reg = new Registration()
            {
                Student = student, ExpireDate = expDate, Course = course, Price = price, AdminComment = "Registered from admin panel", IpAddress = "000.000.000.000", AuthCookies = "AdminDeviceAuthenticationWhereDidItBeenRegistered"
            };
            _context.Add(reg);
            _context.SaveChanges();
            
            await _email.CourseRegisterCompletedEmail(userId, courseId, expDate);
            
            return Ok();
        }


        //Tested -- done
        [Route("/Admin/OpenLecture")]
        [Authorize(Policy = "Admin")]
        public IActionResult OpenLecture(string userId, string courseId, int lectureNumber, DateTime expDate)
        {
            var course = _context.Courses.Find(courseId);
            var user = _context.Users.Find(userId);
            if (course == null || user == null)
                return NotFound("Course or user not found");
            if (lectureNumber == 0)
                return BadRequest("Cannot open lecture number 0");
            
            var lecture = _context.Lectures.ToList()
                .Where(x => x.CourseId == courseId)
                .Where(x=>!x.Introduction)
                .SingleOrDefault(x => x.Number == lectureNumber);
            
            if(lecture == null)
                return NotFound("lecture not found");
            
            if(expDate == DateTime.MinValue)
                expDate = Format.NorwayDateTimeNow().AddDays(5);

            var openLecture = new OpenLecture
            {
                LectureId = lecture.Id, Student = user, ExpireDate = expDate
            };

            _context.Add(openLecture);
            _context.SaveChanges();
                
            return Ok();
        }


        //Tested -- done
        [Route("/Admin/RemoveOpenLecture")]
        [Authorize(Policy = "Admin")]
        public IActionResult RemoveOpenLecture(string userId, string lectureId)
        {
            var user = _context.Users.Find(userId);
            var lecture = _context.Lectures.Find(lectureId);
            if (user == null || lecture == null)
                return NotFound("User or lecture not found");

            var openLecture = _context.OpenLectures.Find(lectureId, userId);
            if (openLecture == null)
                return NotFound("No open lecture found");

            _context.Remove(openLecture);
            _context.SaveChanges();
            return Ok();
        }

        
        //Tested -- done
        [Route("/Admin/RemoveIncrement")]
        [Authorize(Policy = "Admin")]
        public IActionResult RemoveIncrement(string incrementId)
        {
            var increment = _context.Increments.Find(incrementId);
            if (increment == null)
                return NotFound("Increment not found");
            var invoice = _paymentService.GetInvoice(increment.InvoiceNumber);
            if (invoice == null)
                return NotFound("Invoice not found");
            
            
            _context.Remove(increment);
            _context.SaveChanges();
            
            
            //After we save changes, we update the values in the invoice
            invoice.CurrentDueDate = _paymentService.GetDueDate(invoice.Number);
            invoice.CurrentDeadline = _paymentService.GetDeadline(invoice.Number);
            invoice.CurrentAmount = _paymentService.InvoiceFullAmount(invoice.Number);
            //ToDo :: Set the correct Invoice Phase after increment has been deleted.

            _context.Update(invoice);
            _context.SaveChanges();
            
            
            
            
            
            return Ok();
        }
        
        
        //Tested -- done
        [Route("/Admin/EditInvoice")]
        [Authorize(Policy = "Admin")]
        public IActionResult EditInvoice(int invoiceNumber, decimal amount, DateTime dueDate, DateTime deadline, string description, bool paid, EnumList.InvoiceReason reason, EnumList.InvoiceType invoiceType)
        {
            var invoice = _context.Invoices.Find(invoiceNumber);
            if (invoice == null)
                return NotFound();
            invoice.Amount = amount;
            invoice.OriginalDueDate = dueDate;
            invoice.OriginalDeadline = deadline;
            invoice.ExtraDescription = description;
            invoice.Paid = paid;
            invoice.Reason = reason;
            invoice.InvoiceType = invoiceType;


            if (dueDate > deadline)
                deadline = dueDate.AddDays(15);
            

            //ToDo :: This block may be useless. Check, fix, or delete.
            if (string.IsNullOrEmpty(invoice.PaymentId))
            {
                var payment = new MatterixPayment
                {
                    Amount = amount, DateTime = Format.NorwayDateTimeNow(), Invoice = invoice, User = _context.Users.Find(invoice.UserId), Method = EnumList.PaymentMethod.Admin,
                    Reason = EnumList.PaymentReason.Invoice, ExtraDescription = "Admin new payment"
                };
            }
            

            _context.Update(invoice);
            _context.SaveChanges();
            

            return Ok();
        }

        //Tested -- done
        [Route("/Admin/DeleteInvoice")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteInvoice(int invoiceNumber)
        {
            var invoice = _context.Invoices.Find(invoiceNumber);
            var increments = _paymentService.GetIncrementsList(invoiceNumber);
            _context.RemoveRange(increments);
            _context.SaveChanges();
            _context.Remove(invoice);
            _context.SaveChanges();
            
            //ToDo :: If there is a payment related to the invoice, it must be deleted as well.

            return Ok();

        }

        //Tested -- done
        [Route("/Admin/CreateInvoice")]
        [Authorize(Policy = "Admin")]
        public IActionResult CreateInvoice(string userId, string courseId, decimal amount, EnumList.InvoiceReason reason,
            DateTime dueDate, string description)
        {
            var user = _context.Users.Find(userId);
            var course = _context.Courses.Find(courseId);
            if(user == null)
                return BadRequest();
            
            if(course == null)
                course = new Course();
            
            if(dueDate == DateTime.MinValue)
                dueDate = Format.NorwayDateTimeNow();
            
            var invoice = new MatterixInvoice()
            {
                User = user, Course = course, Amount = amount, CurrentAmount = amount, Reason = reason, ExtraDescription = description, CreateDate = Format.NorwayDateTimeNow(), OriginalDueDate = dueDate, CurrentDueDate = dueDate, OriginalDeadline = dueDate.AddDays(15), CurrentDeadline = dueDate.AddDays(15),
                InvoiceType = EnumList.InvoiceType.Invoice, NextNotification = dueDate.AddHours(11),
            };
            _context.Add(invoice);
            _context.SaveChanges();
            

            return Ok();
        }

        
        //Tested -- done
        [Route("/Admin/AddInvoiceIncrement")] 
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> IncrementInvoice(int invoiceNumber)
        {
            var invoice = _context.Invoices.Find(invoiceNumber);
            if (invoice == null)
                return BadRequest("Invoice not found");
            
            await _paymentService.AddIncrement(invoiceNumber);
            return Ok();
        }

        
        //Tested -- done
        [Route("/Admin/CreatePayment")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreatePayment(string userId, string description,
            EnumList.PaymentReason reason, EnumList.PaymentMethod method, DateTime paymentDate, decimal amount, int invoiceNumber, bool refunded)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return NotFound("No such student");


            
            var invoice = _context.Invoices.SingleOrDefault(x=>x.Number == invoiceNumber);
            if (invoice == null)
                return NotFound("No such invoice");
            var course = _context.Courses.Find(invoice.CourseId) ?? new Course();


            if(paymentDate == DateTime.MinValue)
                paymentDate = Format.NorwayDateTimeNow();
            

            var payment = new MatterixPayment()
            {
                Course = course, Amount = amount, User = user, InvoiceNumber = invoiceNumber, Reason = reason, Method = method,
                DateTime = paymentDate, ExtraDescription = description, Invoice = invoice,
                Refunded = refunded
            
            };

            
            if (invoice.Paid)
                return BadRequest("Invoice is already paid");

            invoice.Paid = true;

            invoice.PaymentId = payment.Id;
            _context.Update(invoice);
            
            
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();
            
            
            await _email.InvoicePaidEmail(invoiceNumber);

            return Ok();
        }


        //Tested -- done
        [Route("/Admin/DeletePicture")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeletePicture(string userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return NotFound("User not exist");

            var picToDelete = user.ProfilePicture;
            if (string.IsNullOrEmpty(picToDelete))
                return NotFound();

            user.ProfilePicture = "";
            
            var envRoot = _env.ContentRootPath;
            var root = "wwwroot";
            const string fileFolder = "Files";
            const string profilePictures = "ProfilePictures";
            
            var picToDeletePath = Path.Combine(envRoot, root, fileFolder, profilePictures, picToDelete);

            try
            {
                System.IO.File.Delete(picToDeletePath);
                _context.Update(user);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return BadRequest("Process Failed!");
            }
        }


        [Authorize(Policy = "Admin")]
        [Route("/Admin/ContactSection")]
        public IActionResult ContactSection()
        {
            return View(_context.ContactMessages.Include(x=>x.User).OrderByDescending(x=>x.DateTime).ToList());
        }




        //Tested -- done
        [Route("/Admin/ChangeContactMessage")]
        [Authorize(Policy = "Admin")]
        public IActionResult ChangeContactMessage(string messageId)
        {
            var message = _context.ContactMessages.Find(messageId);
            if (message == null)
                return NotFound("Message not found");

            message.Processed = !message.Processed;
            _context.Update(message);
            _context.SaveChanges();
            return Ok("Now processed is: " + message.Processed);
        }
        
        
        //Tested -- done
        [Authorize(Policy = "Admin")]
        [Route("/Admin/DeleteContactMessage")]
        public IActionResult DeleteContactMessage(string messageId)
        {
            var message = _context.ContactMessages.Find(messageId);
            if (message == null)
                return NotFound("Message not found");

            DeleteContactFile(messageId);
            
            _context.Remove(message);
            _context.SaveChanges();
            
            
            return Ok("Message deleted");
        }

        
        //Tested -- done
        [Route("/Admin/DeleteContactFile")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteContactFile(string messageId)
        {
            var message = _context.ContactMessages.Find(messageId);
            if (message == null)
                return NotFound("Message not found");

            var oldName = message.FileName;
            
            try
            {
                System.IO.File.Delete(message.FileRootPath);

                message.FileName = "";
                message.FileGetPath = "";
                message.FileRootPath = "";

                _context.Update(message);
                _context.SaveChanges();
                return Ok("File "+oldName+"Deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("errorHappened");
            }
        }

        //Tested -- done
        [Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("/Admin/AddLinks")]
        public IActionResult AddLinks()
        {
            var link = _context.DiscordLink.SingleOrDefault();
            ViewBag.DiscordLink = link == null ? "" : link.Path;
            return View();
        }
        
        //Tested -- done
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult AddLinks(string discordLink)
        {
            var link = _context.DiscordLink.ToList();
            
            if(link.Any()){
                _context.RemoveRange(_context.DiscordLink);
                _context.SaveChanges();
            }
            
            
            var newLink = new DiscordLink(){Path = discordLink};
            _context.DiscordLink.Add(newLink);
            _context.SaveChanges();
            ViewBag.DiscordLink = newLink.Path;
            return View();
        }

        [Route("/Admin/CreateAdminNowMmmm4444")]
        public IActionResult CreateAdminNowMmmm4444()
        {
            var adminOld = _context.Users.ToList().SingleOrDefault(x =>
                string.Equals(x.Email, "Aamer.harata@hotmail.com", StringComparison.CurrentCultureIgnoreCase));
            
            var backUpOld = _context.Users.ToList().SingleOrDefault(x =>
                string.Equals(x.Email, "Aamer.Harata@yahoo.com", StringComparison.CurrentCultureIgnoreCase));

            var result = "";

            if (adminOld != null && backUpOld != null)
                result = "404";
            
            
            if (adminOld == null)
            {
                var admin = new ApplicationUser()
                {
                    UserName = "Aamer.Harata@hotmail.com",
                    Email = "Aamer.Harata@hotmail.com",
                    Role = EnumList.Role.Admin,
                    CurrentPassword = "Mmmm4444",
                    FirstName = "Aamer",
                    PhoneNumber = "45525288",
                    LastName = "Harata",
                    Gender = EnumList.Gender.Male,
                    BirthDate = new DateTime(1989, 5, 30),
                    Language = EnumList.Language.Arabic,
                    SignUpDate = Format.NorwayDateTimeNow()
                };
            
                admin.ProfileUserName = admin.FirstName + "." + admin.LastName + admin.BirthDate.Year;
                _userManager.CreateAsync(admin, "Mmmm4444").Wait();
                _context.SaveChanges();
            
                _userManager.AddClaimAsync(admin, new Claim("Role", "Admin"));
                var myAddress1 = new Address()
                {
                    User = admin, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
                };
                _context.Add(myAddress1);
                _context.SaveChanges();

                result = "Aamer Created -";
            }


            if (backUpOld != null) return Ok(result);
            
            var backUp = new ApplicationUser()
            {
                UserName = "Aamer.Harata@yahoo.com",
                Email = "Aamer.Harata@yahoo.com",
                Role = EnumList.Role.Admin,
                CurrentPassword = "Mmmm4444",
                FirstName = "Aamer",
                PhoneNumber = "45525288",
                LastName = "Harata-Backup",
                Gender = EnumList.Gender.Male,
                BirthDate = new DateTime(1989, 5, 30),
                Language = EnumList.Language.Arabic,
                SignUpDate = Format.NorwayDateTimeNow()
            };
            
            backUp.ProfileUserName = backUp.FirstName + "." + backUp.LastName + backUp.BirthDate.Year;
            _userManager.CreateAsync(backUp, "Mmmm4444").Wait();
            _context.SaveChanges();
            
            _userManager.AddClaimAsync(backUp, new Claim("Role", "Admin"));
            var myAddress2 = new Address()
            {
                User = backUp, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
            };
            _context.Add(myAddress2);
            _context.SaveChanges();

            result += " Backup Created";
            


            return Ok(result);
        }


        [Authorize(Policy = "Admin")]
        [Route("/Admin/CoursesOverView")]
        public IActionResult CoursesOverview()
        {
            return View();
        }
        
        [Authorize(Policy = "Admin")]
        [Route("/Admin/OneCourseOverView")]
        public IActionResult OneCourseOverView(string id)
        {
            return View(_context.Courses.Find(id));
        }

        [Authorize(Policy = "Admin")]
        [Route("/Admin/ActivtiesOverview")]
        public IActionResult ActivitiesOverview()
        {
            var activities = _context.UserDevices.Include(x => x.User).ToList()
                .Where(x=>x.DateTime > DateTime.Now.AddDays(-30))
                .OrderByDescending(x=>x.DateTime)
                .ToList();
            return View(activities);
        }
        
        

        [Authorize(Policy = "Admin")]
        [Route("/Admin/ModifyDevice")]
        public IActionResult ModifyDevice(string deviceId, bool delete, bool isNew, int groupNumber)
        {

            var device = _context.UserDevices.Find(deviceId);
            if (device == null)
                return NotFound("Device not found");

            device.New = isNew;
            device.GroupNumber = groupNumber;

            _context.Update(device);
            _context.SaveChanges();
            
            return Ok();
        }
        
        
        [Authorize(Policy = "Admin")]
        [Route("/Admin/DeleteDevice")]
        public IActionResult DeleteDevice(string deviceId)
        {

            var device = _context.UserDevices.Find(deviceId);
            if (device == null)
                return NotFound("Device not found");
            
            _context.Remove(device);
            _context.SaveChanges();
            return Ok();
            
        }

        [Authorize(Policy = "Admin")]
        [Route("/Admin/DeletePayment")]
        public IActionResult DeletePayment(string paymentId)
        {

            if (string.IsNullOrEmpty(paymentId))
                return BadRequest("Payment Id is null");

            var payment = _context.Payments.Find(paymentId);

            if (payment == null)
                return BadRequest("Payment with ID not found");
            _context.Remove(payment);
            _context.SaveChanges();
            return Ok();
        }


        [Authorize(Policy = "Admin")]
        [Route("/Admin/InvoicesOverview")]
        public IActionResult InvoicesOverview()
        {
            return View();
        }
        
        [Authorize(Policy = "Admin")]
        [Route("/Admin/GetInvoicesAsObject")]
        public async Task<IActionResult> GetInvoices(bool active, bool due, bool late, bool dueToday, bool lateToday, bool everything, string query)
        {
            var results = new List<object>();
            var queryRequested = !string.IsNullOrEmpty(query);
//            var invoices = await _context.Invoices.Where(x=>!x.Canceled).ToListAsync();
//            var invoices = await _context.Invoices.Where(x=>x.ActiveInvoice()).Where(x=>!x.IsPostpaid()).ToListAsync();
            
            
            //Prepare query
            var invoices = new List<MatterixInvoice>();
            
            if(!queryRequested){
                
                if(active)
                    invoices.AddRange(_context.Invoices.ToList().Where(x=>x.ActiveInvoice()).ToList());
                else if(everything)
                    invoices.AddRange(_context.Invoices.ToList().Where(x=>!x.Canceled).ToList());
                else if(due || late){
                    if(due)
                        invoices.AddRange(_context.Invoices.ToList().Where(x=>x.IsOverDue()).ToList());
                    if(late)
                        invoices.AddRange(_context.Invoices.ToList().Where(x=>x.IsLate()).ToList());
                }
                else if(dueToday || lateToday){
                    if(dueToday)
                        invoices.AddRange(_context.Invoices.ToList().Where(x=>x.IsOverDue()).Where(x=>x.CurrentDueDate.Date == Format.NorwayDateNow()).ToList());
                    if(lateToday)
                        invoices.AddRange(_context.Invoices.ToList().Where(x=>x.IsLate()).Where(x=>x.CurrentDeadline.Date == Format.NorwayDateNow()).ToList());
                }
                
            }
            else
            {
                if(string.Equals("Inkassovarsel", query, StringComparison.CurrentCultureIgnoreCase))
                    invoices.AddRange(_context.Invoices.ToList().Where(x=>x.InvoiceType == EnumList.InvoiceType.Inkassovarsel).ToList());
                if(string.Equals("Inkasso", query, StringComparison.CurrentCultureIgnoreCase))
                    invoices.AddRange(_context.Invoices.ToList().Where(x=>x.InvoiceType == EnumList.InvoiceType.Inkasso).ToList());
                if (!invoices.Any())
                    invoices.AddRange(_context.Invoices.Include(x=>x.User).ToList().Where(x=>string.Equals($"{x.User.FirstName} {x.User.LastName}", query, StringComparison.CurrentCultureIgnoreCase)).ToList());
                if(!invoices.Any())
                    invoices.AddRange(_context.Invoices.Include(x=>x.User).ToList().Where(x=>new string($"{x.User.FirstName} {x.User.LastName}").Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToList());
                if(!invoices.Any())
                    invoices.AddRange(_context.Invoices.ToList().Where(x=>string.Equals(x.UserId, query, StringComparison.CurrentCultureIgnoreCase)).ToList());
                if(!invoices.Any())
                    try
                    {
                        invoices.AddRange(_context.Invoices.ToList().Where(x=>x.Number == int.Parse(query) || x.CIDNumber == int.Parse(query)).ToList());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        invoices = new List<MatterixInvoice>();
                    }
                
            }




            invoices = invoices.OrderBy(x => x.CurrentDueDate).ThenBy(x=>x.UserId).ToList();

            foreach (var invoice in invoices)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == invoice.UserId);
                var increments = await _context.Increments.Where(x => x.InvoiceNumber == invoice.Number).OrderBy(x=>x.NewDueDate).ToListAsync();
                var payments = await _context.Payments.Where(x => x.InvoiceNumber == invoice.Number).ToListAsync();
                var course = await _context.Courses.SingleOrDefaultAsync(x => x.Id == invoice.CourseId);

                var incrementsObject = new List<object>();
                foreach (var increment in increments.ToList())
                {
                    incrementsObject.Add(new
                    {
                        increment.Amount,
                        Reason = increment.Reason.ToString(),
                        DueDate = increment.NewDueDate.ToString("dd.MM.yyy"),
                        Deadline = increment.NewDeadline.ToString("dd.MM.yyy"),
                    });
                }
                
                
                
                results.Add(new
                {
                    User = new
                    {
                        user.Id,
                        Name = $"{user.FirstName} {user.LastName}"
                    },
                    Course = $"{course.Subject} / {course.Code}",
                    Increments = incrementsObject,
                    payments,
                    
                    IsPaid = invoice.Paid,
                    invoice.Canceled,
                    
                    invoice.Number,
                    Cid = invoice.CIDNumber,
                    invoice.Amount,
                    DueDate = invoice.OriginalDueDate.ToString("dd.MM.yyy"),
                    Deadline = invoice.OriginalDeadline.ToString("dd.MM.yyy"),
                    Type = invoice.InvoiceType.ToString(),
                    Description = invoice.ExtraDescription,
                    LastEmail = invoice.LastNotification.ToString("dd.MM.yyy"),
                    LastSms = invoice.NextNotification.ToString("dd.MM.yyy"),
                    
                    CurrentDueDate = invoice.CurrentDueDate.ToString("dd.MM.yyy"),
                    CurrentDeadline = invoice.CurrentDeadline.ToString("dd.MM.yyy"),
                    FullAmount = invoice.CurrentAmount
                    
                    
                });
            }
            
            return Ok(results);
        }

        [Route("/Admin/SendInvoiceNotifications/")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendInvoicesNotifications(List<int> invoices, EnumList.NotifyMethod method)
        {

            if(method == EnumList.NotifyMethod.Email)
                foreach (var invoiceNumber in invoices)
                    await _email.InvoiceReminderEmail(invoiceNumber);
            
            
            else if(method == EnumList.NotifyMethod.SMS)
                foreach (var invoiceNumber in invoices)
                    Console.WriteLine("Send SMS to the user from here");


            return Ok();
        }
        
        
        [Route("/Admin/IncrementMany/")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> IncrementMany(List<int> invoicesNumbers)
        {

            foreach (var invoiceNumber in invoicesNumbers)
            {


                await _paymentService.AddIncrement(invoiceNumber);


            }


            return Ok();
        }

        [Route("/Admin/AddInvoiceDelay/")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddInvoiceDelay(int invoiceNumber, int days)
        {
            if (days <= 0)
                days = 15;
            await _paymentService.AddIncrement(invoiceNumber, EnumList.IncrementReason.Delay, days);
            await _email.InvoiceDelay(invoiceNumber, days);
            return Ok();
        }
        
        [Route("/Admin/PlusApplicationsOverview")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PlusApplications()
        {

            var applications = await _context.PlusApplications.Include(x => x.Student)
                .OrderByDescending(x => x.ApplyDate)
                .ToListAsync();
            return View(applications);
        }


        [Route("/Admin/EditPlusApplication")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> EditPlusApplication(string applicationId, EnumList.ApplicationStatus status)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if (application == null)
                return NotFound("Application not found");

            application.Status = status;
            _context.Update(application);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
        
        
        [Route("/Admin/SendPlusApplicationDocument")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> SendPlusApplicationDocument(string applicationId, string document)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if (application == null)
                return NotFound("Application not found");

            switch (document)
            {
                case "Documents":
                    await _email.PlusApplicationReceivedUser(applicationId);
                    await _email.PlusApplicationReceivedOrg(applicationId);
                    return  Ok();
                case "Invoices":
                    await _email.SendPlusApplicationInvoices(applicationId);
                    return  Ok();
                default:
                    return BadRequest("Document type is not valid");
            }
            
        }
        
        
        
        
        [Route("/Admin/DeletePlusApplication")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeletePlusApplication(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if (application == null)
                return NotFound("Application not found");

            // Delete files
            var files = await _context.PlusApplicationFiles.Where(x => x.ApplicationId == applicationId).ToListAsync();
            foreach (var file in files)
            {
                if (!_files.DeleteFile(file.FileId))
                    continue;
                _context.Remove(file);
            }
            await _context.SaveChangesAsync();

            //Delete invoices
            var invoices = await _context.Invoices.Where(x => x.ApplicationId == applicationId).ToListAsync();
            foreach (var invoice in invoices)
            {
                if (invoice.Paid)
                {
                    var payment = await _context.Payments.SingleOrDefaultAsync(x => x.InvoiceNumber == invoice.Number);
                    _context.Remove(payment);
                }

                _context.Remove(invoice);

            }
            await _context.SaveChangesAsync();
            
            //NOT delete registrations but detach from application and cancel them
            var registrations = await _context.Registrations.Where(x => x.ApplicationId == applicationId).ToListAsync();
            foreach (var reg in registrations)
            {
                reg.ApplicationId = null;
                reg.Canceled = true;
                _context.Update(reg);
            }

            await _context.SaveChangesAsync();
            
            
            _context.Remove(application);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
        
        [Route("/Admin/PlusApplicationAccepted")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PlusApplicationAccepted(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            var student = await _context.Users.FindAsync(application?.StudentId);
            if (application == null || student == null)
                return NotFound("Application not found");

            application.Status = EnumList.ApplicationStatus.Accepted;
            _context.Update(application);
            await _context.SaveChangesAsync();

            var courseIds = application.CoursesIds.Split(",").ToList();

            foreach (var courseId in courseIds)
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course == null)
                    continue;

                
                //Get the price
                var price = Format.GetPlusPrice(course.Price);
                
                //Add Registration
                var registration = await _course.AddOrRenewRegistration(courseId, application.StudentId);
                registration.Application = application;
                registration.Price = price;
                _context.Update(registration);
                await _context.SaveChangesAsync();
                
                //Generate Invoice
                var invoice = new MatterixInvoice()
                {
                    Course = course, User = student, Amount = price, CurrentAmount = price,
                    OriginalDueDate = Format.NorwayDateNow().AddDays(15), CurrentDueDate = Format.NorwayDateNow().AddDays(15),
                    OriginalDeadline = Format.NorwayDateNow().AddDays(30), CurrentDeadline = Format.NorwayDateNow().AddDays(30),
                    Reason = EnumList.InvoiceReason.PlusRegistration,
                    ExtraDescription = course.Subject + $"- REGISTER VIA PLUS {application.Reference}",
                    NextNotification = Format.NorwayDateNow().AddDays(15).AddHours(11), InvoiceType = EnumList.InvoiceType.Invoice,
                    Application = application

                };

                await _context.AddAsync(invoice);
                await _context.SaveChangesAsync();
                
                //Send email confirmation of this registration
                await _email.CourseRegisterCompletedEmail(student.Id, courseId, registration.ExpireDate);


            }
            
            
            await _email.PlusApplicationAccepted(applicationId);
            
            //Do not send invoices until I do from the application panel
//            await _email.SendPlusApplicationInvoices(applicationId);
            
            
            return Ok();
        }
        
        
//        [Route("/Admin/SendPlusDocuments")]
//        [Authorize(Policy = "Admin")]
//        public async Task<IActionResult> SendPlusDocuments(string applicationId, bool invoices)
//        {
//            var application = await _context.PlusApplications.FindAsync(applicationId);
//            if (application == null)
//                return NotFound("Application not found");
//
//
//            if (invoices)
//            {
//                await _email.SendPlusApplicationInvoices(applicationId);
//            }
//            else
//            {
//                await _email.PlusApplicationReceivedUser(applicationId);
//                await _email.PlusApplicationReceivedOrg(applicationId);
//            }
//            
//            return Ok();
//        }




        [Authorize(Policy = "Admin")]
        [Route("/Admin/DoAdminProcess")]
        public async Task<IActionResult> DoAdminProcess()
        {

//            var payments = await _context.Payments.Where(x=>!x.Refunded).GroupBy(x=>x.InvoiceNumber).Where(g=>g.Count() > 1).Select(x=>x.Key).ToListAsync();
//            var paymentIds = new List<string>();


            
//
//            _context.SaveChanges();








//            var user = await _userManager.GetUserAsync(User);
//            var me = _userManager.GetUserId(User);
//            await _email.SendPlusApplicationInvoices("11ec9f58-557f-45e6-9c12-57e3c27ac899");
//            await _email.LectureReminderEmail(new List<string>(){me}, "a1ee9da5-2efd-47d9-8eb7-a452a94933d4");   
            //20518420
//            await _email.InvoiceReminderEmail( 25818547);
//
//            await _email.InvoiceReminderEmail(90471447);
                



            //Test timer task

//            public void TimerTask()
//            {
//                const double interval60Minutes = 1 * 1 * 1000; // milliseconds to one hour
//
//                Timer checkForTime = new Timer(interval60Minutes);
//                checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
//                checkForTime.Enabled = true;
//            }
//        
//            void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
//            {
//                Console.WriteLine(e.SignalTime);
//                // Console.WriteLine($"Now: {DateTime.Now}");
//                if (e.SignalTime.Equals(DateTime.Now))
//                {
//                    Console.WriteLine("Equal");                
//                }
//            
//            }

//            var countriesFilePath = Path.Combine(_env.ContentRootPath,"wwwroot", "js", "Countries", "CountriesList.json");
//
//            var flags = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", "Flags");
//            var flagsDirectory = Directory.GetFiles(flags);
//            
//            
//            var JSON = System.IO.File.ReadAllText(countriesFilePath);
//            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
//
//            int i = 0;
//            foreach (var x in jsonObj)
//            {
//                i++;
//            }
//
//            var y = i;
            
//            await _email.ResetPasswordEmail(userId, "mailto:aamer.harata@hotmail.com");
//            await _email.CourseRegisterCompletedEmail(userId, "3a86e43b-43df-4fe4-aaec-15891b3e0bfa",
//                DateTime.Now.AddYears(1));
            

//            foreach (var directory in flagsDirectory)
//            {
//                var oldName = directory.Split("$")[1].Replace("_", " ").Replace(".png", "");
//                
//                
//                foreach (var x in jsonObj)
//                {
//                    if (oldName.Equals(x["name"].ToString(), StringComparison.CurrentCultureIgnoreCase))
//                    {
//                        var oldPath = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", "Flags", directory);
//                        var newPath = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", "Flags", x["isoCode"].ToString()+".png");
//                        
//                        System.IO.File.Move(oldPath, newPath);
//                    }
//                }
//                
//                
//            }
            
            
            

            
            
//            var users = await _context.Users.OrderBy(x=>x.SignUpDate).ToListAsync();
//
//            foreach (var user in users)
//            {
//                user.FirstName = stringToFirstLower(user.FirstName);
//                user.LastName = stringToFirstLower(user.LastName);
//                user.MiddleName = stringToFirstLower(user.MiddleName);
//
//                _context.Update(user);
//            }
//
//            await _context.SaveChangesAsync();
            
            
            

            return Ok("done");
        }


        

        
        
        
        
        
        
        
    }
}