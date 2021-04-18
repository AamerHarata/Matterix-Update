using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class JobApplication
    {
        public string Id { get; set; }
        public DateTime ApplyDate { get; set; } = Format.NorwayDateTimeNow();
        public string CourseName { get; set; }
        public string VideoLink { get; set; }
        public string ExtraMessage { get; set; } = "";
        public string Replay { get; set; } = "";
        public string CvRootPath { get; set; }
        public string CvWebPath { get; set; }
        public bool Processed { get; set; }
        public DateTime InterviewDate { get; set; } = DateTime.MinValue;

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }



    }
}