using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class Course
    {
        public string Id { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Code { get; set; }
        
        [Required]
        public EnumList.Language Language { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }
        
        public string Picture { get; set; } = "";

        public string Background { get; set; } = "";
        
        public bool Available { get; set; }
        
        public bool Ended { get; set; }
        
        public string Book { get; set; }
        
        public string Goal { get; set; }
        
        public string ClassUrl { get; set;}
        
        public string MeetingId { get; set;}
        
        public string MeetingPass { get; set; }
        public bool Hidden { get; set; }
        public int MaxStudents { get; set; } = -1;
        public bool InstallmentAvailable { get; set; }

        public string ExtraDescription { get; set; } = "";
        
        [Required]
        public string TeacherId { get; set; }
        
        public ApplicationUser Teacher { get; set; }

        public bool IsAvailable()
        {
            return Available && !Hidden;
        }
    }
}