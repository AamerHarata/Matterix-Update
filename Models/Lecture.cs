using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class Lecture
    {
        public string Id { get; set; }
        public int Number { get; set; }
//        [DataType(DataType.Date)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public EnumList.Days Day { get; set; }
        
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public TimeSpan From { get; set; }
        
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public TimeSpan To { get; set; }

        public string Title { get; set; } = "";
        public string Preparation { get; set; }
        public string Description { get; set; }
        public bool Free { get; set; }
        public bool Introduction { get; set; }
        public bool Completed { get; set; }
        
        public string CourseId { get; set; }
        public Course Course { get; set; }


        public bool IsIntro()
        {
            return Number <= 0 && Title == "intro";
        }
        
        public bool IsSample()
        {
            return Number <= 0 && Title == "sample";
        }
    }
}