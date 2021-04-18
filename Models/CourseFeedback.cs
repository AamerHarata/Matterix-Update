using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class CourseFeedback
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; } = Format.NorwayDateTimeNow();
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}