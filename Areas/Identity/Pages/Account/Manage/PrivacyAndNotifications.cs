using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Matterix.Areas.Identity.Pages.Account.Manage
{
    public partial class PrivacyAndNotificationsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;


        public PrivacyAndNotificationsModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        
        public class InputModel
        {
            public bool ShowName { get; set; }
            public string FullName { get; set; }
            public string ProfileUserName { get; set; }
            

            public MailNotify MailNotify { get; set; }
            public SmsNotify SmsNotify { get; set; }
            
        }
        
        public class MailNotify
        {
            public bool BeforeLecture { get; set; }
            public bool CourseUpdate { get; set; }
            public bool ImportantUpdate { get; set; }
            public bool OfferAndOther { get; set; }
        }

        public class SmsNotify
        {
            public bool BeforeLecture { get; set; }
            public bool CourseUpdate { get; set; }
            public bool ImportantUpdate { get; set; }
            public bool OfferAndOther { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            var notificationList = _context.NoNotifications.Where(x => x.UserId == user.Id);
            
            var mailNotify = new MailNotify()
            {
                BeforeLecture = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.Email).Any(x=>x.NotificationType == EnumList.Notifications.LectureStart),
                CourseUpdate = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.Email).Any(x=>x.NotificationType == EnumList.Notifications.CourseUpdate),
                ImportantUpdate = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.Email).Any(x=>x.NotificationType == EnumList.Notifications.ImportantUpdate),
                OfferAndOther = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.Email).Any(x=>x.NotificationType == EnumList.Notifications.OfferAndOther),
            };
            
            //ToDo :: Add Sms notify list
            var smsNotify = new SmsNotify()
            {
                BeforeLecture = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.SMS).Any(x=>x.NotificationType == EnumList.Notifications.LectureStart),
                CourseUpdate = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.SMS).Any(x=>x.NotificationType == EnumList.Notifications.CourseUpdate),
                ImportantUpdate = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.SMS).Any(x=>x.NotificationType == EnumList.Notifications.ImportantUpdate),
                OfferAndOther = !notificationList.Where(x=>x.Method == EnumList.NotifyMethod.SMS).Any(x=>x.NotificationType == EnumList.Notifications.OfferAndOther),

            };
            
            Input = new InputModel()
            {
                ShowName = user.ShowFullName,
                FullName = user.FirstName+" "+user.LastName,
                ProfileUserName = user.ProfileUserName,
                MailNotify = mailNotify,
                SmsNotify = smsNotify
            };
            
            
            return Page();
        }

        public IActionResult OnPostAsync(IFormFile pictureFile)
        {

            return Page();


        }

       

    }
}
