using System.Collections.Generic;

namespace Matterix.Models.Objects
{
    public class CourseObject
    {
        public Course Course { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Lecture NextLecture { get; set; }
        public ApplicationUser Teacher { get; set; }
        
        public bool ValidRegistration { get; set; }
    }
}