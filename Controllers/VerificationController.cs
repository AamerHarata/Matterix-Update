using System;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account.Usage.Record;
using Twilio.Rest.Verify.V2.Service;

namespace Matterix.Controllers
{
    public class VerificationController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public VerificationController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        



        [Authorize]
        [Route("/Verification/")]
        public async Task<IActionResult> Index(string courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Error", "Home");
            
            if(user.PhoneNumberConfirmed)
                return RedirectToAction("Index", "Home");
            
            var phoneNumber = $"{user.PhoneCode}{user.PhoneNumber}";
            
            ViewBag.CourseId = courseId;
            
            
            return View("Index", new []{user.PhoneCode, user.PhoneNumber});
        }
        
        [Authorize]
        public async Task<IActionResult> SendVerificationCode(string courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Error", "Home");
            
            if(user.PhoneNumberConfirmed)
                return RedirectToAction("Index", "Home");
            
            var codeSent = false;
            
            try
            {
                var verification = await VerificationResource.CreateAsync(
                    to: $"{user.PhoneCode}{user.PhoneNumber}",
                    channel: "sms",
                    pathServiceSid: StaticInformation.TwilioVerificationServiceSid
                );
                
                if (verification.Status == "pending")
                    codeSent = true;
                
                
                
//                ToDo:: This used to send normal Message 
//                var message = await MessageResource.CreateAsync(
//                    body: "مرحباً عمرون 🌹\nكيف الحال",
//                    from: new Twilio.Types.PhoneNumber("Matterix"), 
//                    to: new Twilio.Types.PhoneNumber(phoneNumber)
//                );
                
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                codeSent = false;
            }
            
            return RedirectToAction("CheckCode", new {courseId, codeSent});
            
        }



        

        [Authorize]
        [Route("/Verification/CheckCode")]
        public async Task<IActionResult> CheckCode(string courseId, bool codeSent)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Error", "Home");
            
            if(user.PhoneNumberConfirmed)
                return RedirectToAction("Index", "Home");

            var phoneNumber = $"{user.PhoneCode}{user.PhoneNumber}";
            
            ViewBag.CourseId = courseId;
            ViewBag.CodeSent = codeSent;

            
            
            return View("CheckCode", new []{user.PhoneCode, user.PhoneNumber});
        }

        
        
        [Authorize]
        [Route("/Verification/VerifyNumber")]
        public async Task<IActionResult> VerifyNumber(string code, UserDevice userDevice)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.PhoneNumberConfirmed)
                return BadRequest("refresh");
            
            if (string.IsNullOrEmpty(code))
                return BadRequest("wrongCode");



            try
            {
                var verification = await VerificationCheckResource.CreateAsync(
                    to: $"{user.PhoneCode}{user.PhoneNumber}",
                    code: code,
                    pathServiceSid: StaticInformation.TwilioVerificationServiceSid
                );
                
                if (verification.Status != "approved") return BadRequest("wrongCode");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
            
            //If we come here then the code is correct but not saved to the database
            user.PhoneNumberConfirmed = true;
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded) return BadRequest();
            
            try
            {
                var oldCookies =  HttpContext.Request.Cookies["_ulisp"];
                var oldDevices = _context.UserDevices.Where(x => x.UserId == user.Id)
                    .Where(x => x.AuthCookies == oldCookies).OrderByDescending(x => x.DateTime).ToList();
                var oldDevice = new UserDevice();
                if (oldDevices.Any())
                    oldDevice = oldDevices[0];
                var device = new UserDevice()
                {
                    User = user, Ip = oldDevice.Ip, OperatingSystem = oldDevice.OperatingSystem, AuthCookies = oldCookies, GroupNumber = oldDevice.GroupNumber,
                    Activity = EnumList.Activity.PhoneVerification, DeviceType = oldDevice.DeviceType
                };
                await _context.AddAsync(device);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
                
            return Ok();
            


        }
        
        
        
        

        
        
        
        
        
    }
}