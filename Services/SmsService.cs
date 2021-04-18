using System;
using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Matterix.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class SmsService
    {
        private readonly ApplicationDbContext _context;

        public SmsService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        
        
        //SMSs Can be sent

        // Course register confirmation
        public async Task CourseRegisterSms(string userId, string courseId)
        {
            var user = await _context.Users.FindAsync(userId);
            var course = await _context.Courses.FindAsync(courseId);
            if(user == null || course == null)
                return;

            var body = "";
            var name = GetName(user.FirstName);
            
            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    body += $"Hei {name}\n";
                    body += "Du har nå påmeldt deg på kurset 1234567890\n";
                    body += "Kurset er direkte. Dermed ";
                    
                    
                    break;
                case EnumList.Language.English:
                    break;
                case EnumList.Language.Arabic:
                    
                    
                    
                    
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }
        
        //LectureReminder
        public async Task LectureReminder(List<string> userIds, string lectureId)
        {

            var lecture = await _context.Lectures.Include(x => x.Course).SingleOrDefaultAsync(x => x.Id == lectureId);
            if(lecture == null)
                return;
            
            var minutes = (int) lecture.From.Subtract(Format.NorwayTimeNow()).TotalMinutes;


            foreach (var userId in userIds)
            {
                var user = await GetUser(userId);
                if(user == null || !AcceptNotification(userId, EnumList.Notifications.LectureStart))
                    continue;

                var body = "";
                var name = GetName(user.FirstName);
                var courseName = GetCourseName(lecture.Course.Subject);

                switch (user.Language)
                {
                    case EnumList.Language.Norwegian:
                        body =
                            $"Hei {name}\n" +
                            $"Leksjon nr {lecture.Number} av {courseName} begynner om {minutes} min 🌹";
                        break;
                    case EnumList.Language.English:
                        body =
                            $"Hi {name}\n" +
                            $"Lecture nr {lecture.Number} of {courseName} starts within {minutes} min 🌹";
                        
                        break;
                    case EnumList.Language.Arabic:
                        body = $"مرحباً {name}\n"+
                               $"تبدأ المحاضرة {lecture.Number} من دورة {courseName} بعد {minutes} دقيقة 🌹";
                        break;
                    default:
                        continue;
                }


                await SaveNotification(user, body, EnumList.Notifications.LectureStart, lectureId);

            }


        }

        // Sms for a group of people from the admin
        public async Task GroupSms(List<string> userIds, string body)
        {
            foreach (var userId in userIds)
            {
                var user = await GetUser(userId);
                if(user == null)
                    continue;
                
                await SaveNotification(user, body, EnumList.Notifications.Admin, "AdminGroupSms");

            }
        }

        // Custom sms from the admin to registered user
        public async Task AdminCustomSms(string userId, string template,
            EnumList.Language language = EnumList.Language.Arabic)
        {
            
        }

        
        // Custom sms from the admin to a non registered user
        public async Task AdminCustomSms(string phoneNumber, string name, string template, EnumList.Language language = EnumList.Language.Arabic)
        {
            
        }
        
        
        
        
        
        
        
        
        
        
        private bool AcceptNotification(string userId, EnumList.Notifications type)
        {
            if (type == EnumList.Notifications.Admin)
                return true;
            
            //ToDO :: Possible database failure here, there must be .ToList() after the Where().
            
            return !_context.NoNotifications.Where(x => x.UserId == userId)
                .Where(x=>x.Method == EnumList.NotifyMethod.SMS)
                .Any(x => x.NotificationType == type);
            
        }

        private async Task SaveNotification(ApplicationUser user, string body, EnumList.Notifications type, string reference)
        {
            //ToDo :: Check if the phone is confirmed before you send this sms
            
            var notification = new Notification()
            {
                User = user, Body = body, PhoneNumber = $"{user.PhoneCode}{user.PhoneNumber}", Method = EnumList.NotifyMethod.SMS,
                Type = type, Reference = reference
            };
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        
        
        private async Task<ApplicationUser> GetUser(string userId){return await _context.Users.FindAsync(userId);}

        private string GetName(string firstName)
        {
            var tokens = firstName.Split(" ");
            if (tokens.Length > 0)
                firstName = tokens[0];

            if (firstName.Length > 10)
                firstName = firstName.Substring(0, 10);
                    

            return firstName;
        }

        private string GetCourseName(string courseName)
        {
            if (courseName.Length <= 10)
                return courseName;

            var tokens = courseName.Split(" ");
            if (tokens.Length > 1)
                courseName = $"{tokens[0]} {tokens[1]}";
            
            if(courseName.Length > 10)
                courseName = courseName.Substring(0, 10);
            
            return courseName;
        }
        
        
        
        
        
        
        
        
    }
}