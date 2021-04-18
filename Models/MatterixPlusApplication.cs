using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class MatterixPlusApplication
    {
        public string Id { get; set; }

        public DateTime ApplyDate { get; set; } = Format.NorwayDateTimeNow();
        
        public string Applier { get; set; }
        
        public string ContactPersonName { get; set; }
        
        public string ContactPersonEmail { get; set; }
        
        public string ContactPersonPhoneCode { get; set; }
        public string ContactPersonPhone { get; set; }
        
        public string Organization { get; set; }
        
        public string Program { get; set; }
        
        public string City { get; set; }

        public string CoursesIds { get; set; } = ""; //This can be many courses split with a comma
        
        public int Reference { get; set; } = new Random().Next(10000, 99999);
        
        public int PassCode { get; set; } =new Random().Next(1000, 9999);

        public EnumList.ApplicationStatus Status { get; set; } = EnumList.ApplicationStatus.PendingCoursesChoosing;
        
        public string Replay { get; set; }
        
        //ToDo :: Add field (mechanism) for uploaded documents
        
        
        
        
        
        public ApplicationUser Student { get; set; }
        public string StudentId { get; set; }
    }
}