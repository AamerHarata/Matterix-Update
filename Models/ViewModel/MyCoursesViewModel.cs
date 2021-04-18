using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class MyCoursesViewModel
    {
        public List<Course> OwnedCourses { get; set; }
        public List<Course> TeachCourses { get; set; }
        public List<Course> ExpiredCourses { get; set; }
    }
}