using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class Registration
    {
        public DateTime RegisterDate { get; set; } = Format.NorwayDateTimeNow();
        public decimal Price { get; set; }
        public string AdminComment { get; set; } = "";
        public bool Expire { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public string AuthCookies { get; set; }= "";
        public string IpAddress { get; set; }= "";
        
        public string DiscountCard { get; set; }= "";
        public bool Live { get; set; }
        public bool Canceled { get; set; }
        
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        
        public int Count { get; set; }
        
        //If registration went through plus application this is going to be used
        public string ApplicationId { get; set; }
        public MatterixPlusApplication Application { get; set; }


        public bool IsActive()
        {
            var expiredDueDate = ExpireDate < Format.NorwayDateTimeNow();
            return !Expire && !Canceled && !expiredDueDate;
        }

        public bool IsPlus()
        {
            return !string.IsNullOrEmpty(ApplicationId);
        }
    }
}