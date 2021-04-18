using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class UserProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Course> RegisteredCourses { get; set; }
        public List<Course> TeacherCourses { get; set; }
    }
}