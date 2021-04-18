using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Matterix.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AccessService _access;
        private readonly NotificationsService _notifications;

        public SettingsController(ApplicationDbContext context, AccessService access, NotificationsService notifications)
        {
            _context = context;
            _access = access;
            _notifications = notifications;
        }

        


        [Authorize]
        [Route("/Settings/ShowName/")]
        public IActionResult ShowName(bool showName)
        {
            var userId = _access.GetUserId(User);
            if(string.IsNullOrEmpty(userId))
                return BadRequest();

            var user = _context.Users.Find(userId);
            if(user == null)
                return BadRequest();

            user.ShowFullName = showName;
            _context.Update(user);
            _context.SaveChanges();
            return Ok();
        }
        
        [Route("/Settings/Notifications/")]
        [Authorize]
        public IActionResult Notifications(EnumList.Notifications type, EnumList.NotifyMethod method, bool receive = false)
        {
            //ToDo :: Implement Method here
            var userId = _access.GetUserId(User);
            if(string.IsNullOrEmpty(userId))
                return BadRequest();

            var user = _context.Users.Find(userId);
            if(user == null)
                return BadRequest();

            var userNotifications = _context.NoNotifications.Where(x => x.UserId == userId).Where(x=>x.Method == method).ToList();


            if (receive)
            {
                if(!userNotifications.Any())
                    return BadRequest();

                var notification = userNotifications.SingleOrDefault(x => x.NotificationType == type);
                if(notification == null)
                    return BadRequest();

                _context.Remove(notification);
                _context.SaveChanges();
                return Ok();

            }

            if (userNotifications.Any(x => x.NotificationType == type))
                return BadRequest();

            var newNotNotify = new NoNotification {User = user, NotificationType = type, Method = method};
            _context.Add(newNotNotify);
            _context.SaveChanges();
            
            return Ok();
        }

        [Route("/Settings/RevokeNotifications/")]
        [Authorize]
        public async Task<IActionResult> RevokeNotifications(EnumList.NotifyMethod method)
        {
            if(method == EnumList.NotifyMethod.Email)
                await _notifications.RevokeEmail();
            else
                await _notifications.RevokeSms();

            return Ok();
        }
        
        [Route("/Settings/RevokeNotificationsForce/")]
        public async Task<IActionResult> RevokeNotificationsForce()
        {
            //This function for revoking from non authorized users
            await _notifications.RevokeEmail();
            return Ok();
        }
        
    }
}