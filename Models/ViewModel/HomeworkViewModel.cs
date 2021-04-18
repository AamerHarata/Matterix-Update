using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class HomeworkViewModel
    {
        public List<LectureFile> CourseHomework { get; set; }
        public List<Homework> StudentsDeliveredHomework { get; set; }
    }
}