using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Course> AllCourses { get; set; } = new List<Course>();
        public List<Course> OwnCourses { get; set; } = new List<Course>();
//        public List<Course> TeachCourses { get; set; } = new List<Course>();
        
        public List<Lecture> UpcomingLectures { get; set; } = new List<Lecture>();
        public List<LectureFile> UpcomingHomework { get; set; } = new List<LectureFile>();
        public List<MatterixInvoice> UpcomingInvoices { get; set; } = new List<MatterixInvoice>();
        
        public List<InitiatedOrder> NonCompletedOrders { get; set; } = new List<InitiatedOrder>();
    }
}