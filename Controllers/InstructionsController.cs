using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FilesService _files;
        private readonly InformationService _info;

        public InstructionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, FilesService files, InformationService info)
        {
            _context = context;
            _userManager = userManager;
            _files = files;
            _info = info;
        }





        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult LiveCourses()
        {
            ViewBag.Logged = true;
            
            if (!User.Identity.IsAuthenticated){
                ViewBag.Logged = false;
                ViewBag.LiveCourseAccess = false;
                return View();
            }

            if (User.HasClaim("Role", "Teacher") || User.HasClaim("Role", "Admin"))
            {
                ViewBag.LiveCourseAccess = true;
                return View(new List<Course>());
            }
            
            var studentId = _userManager.GetUserId(User);
            
            var registrations = _context.Registrations.Include(x => x.Course).Where(x => x.StudentId == studentId).Where(x=>x.IsActive())
                .Where(x => !x.Course.Ended).ToList();
            
            ViewBag.LiveCourseAccess = registrations.Any();

            var courses = registrations.Select(x => x.Course).ToList();
            
            return View(courses);
        }
        
        
        [Authorize]
        public IActionResult CourseChatHelp()
        {
            ViewBag.Logged = true;
            
            if (!User.Identity.IsAuthenticated){
                ViewBag.Logged = false;
                ViewBag.LiveCourseAccess = false;
                return View();
            }

            if (User.HasClaim("Role", "Teacher") || User.HasClaim("Role", "Admin"))
            {
                ViewBag.LiveCourseAccess = true;
                return View();
            }
            
            var studentId = _userManager.GetUserId(User);
            
            var registrations = _context.Registrations.Include(x => x.Course).Where(x => x.StudentId == studentId)
                .ToList();
            
            ViewBag.LiveCourseAccess = registrations.Any();
            
            return View();
        }
        
        public IActionResult ShortVideos()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> StudentAgreement(string returnUrl = null)
        {
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl)? "none" : returnUrl;
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Error", "Home");
            
            
            
            return View(user);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StudentAgreement(UserDevice device, bool agree, string returnUrl = null)
        {
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl)? "none" : returnUrl;
            
            var user = await _userManager.GetUserAsync(User);

            if (user == null || !agree)
                return RedirectToAction("Error", "Home");

            user.SignedStudentAgreement = true;
            user.SignedStudentAgreementAt = Format.NorwayDateTimeNow();

            _context.Update(user);
            await _context.SaveChangesAsync();
            
            var isNew = _info.IsDeviceNew(user.Id, device.AuthCookies, device.Ip);
            var groupNumber = _info.GetDeviceGroupNumber(user.Id, device.AuthCookies, device.Ip);
            
            var userDevice = new UserDevice
            {
                Ip = device.Ip, User = user, AuthCookies = device.AuthCookies, Activity = EnumList.Activity.SigningAgreement,
                OperatingSystem = device.OperatingSystem, New = isNew, GroupNumber = groupNumber, DeviceType = device.DeviceType
            };

            _context.Add(userDevice);
            await _context.SaveChangesAsync();
            
            return View(user);
        }

        [Authorize]
        [HttpGet]
        public FileResult AgreementFile(EnumList.Language language)
        {
            byte[] fileBytes = _files.GetStudentAgreement(language);
            
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, $"Agreement-{language}-V1.pdf");
        }

        public IActionResult Welcome()
        {
            return Ok();
        }

        public IActionResult HowToStart()
        {
            return View();
        }
        
        
    }
}