using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class Notification
    {
        public string Id { get; set; }
        public EnumList.NotifyMethod Method { get; set; }
        public DateTime TimeToSend { get; set; } = Format.NorwayDateTimeNow();
        public DateTime TimeSent { get; set; } = DateTime.MinValue;
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Completed { get; set; }
        public int Attempts { get; set; }
        public string Reference { get; set; }
        public EnumList.Notifications Type { get; set; }
        
        
        
        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}