using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class LectureFile
    {
        public string Path { get; set; }
        public string RootPath { get; set; }
        public string Name { get; set; }
        public bool IsHomeWork { get; set; }
        
        public DateTime UploadDate { get; set; } = Format.NorwayDateTimeNow();
        
        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; } = Format.NorwayDateTimeNow().Date.AddDays(2);
        public string LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}