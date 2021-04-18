using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class Schedule
    {
        public int Number { get; set; }
        [Required]
        public EnumList.Days Day { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public TimeSpan From { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public TimeSpan To { get; set; }
        
        public string CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}