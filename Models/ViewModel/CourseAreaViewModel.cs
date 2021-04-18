using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class CourseAreaViewModel
    {
        public Course Course { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<LectureFile> Files { get; set; }
        public HomeworkViewModel HomeworkVm { get; set; }
        public HomeworkViewModel HomeworkVmForTeacher { get; set; }
        public List<LectureVideo> Videos { get; set;}
        public List<CourseFeedback> Feedback { get; set; }
        public List<ApplicationUser> People { get; set; }

    }
}