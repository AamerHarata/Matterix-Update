using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class ContactMessage
    {
        public string Id { get; set; }
        public string Name { get; set; }= "";
        public string Message { get; set; }= "";
        public string ReplayMessage { get; set; }= "";
        public EnumList.Contact Reason { get; set; }
        public DateTime DateTime { get; set; } = Format.NorwayDateTimeNow();
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string FileRootPath { get; set; } = "";
        
        public string FileGetPath { get; set; }
        public string FileName { get; set; } = "";
        
        public string Ip { get; set; } = "";
        public string AuthCookies { get; set; } = "";
        public bool Processed { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}