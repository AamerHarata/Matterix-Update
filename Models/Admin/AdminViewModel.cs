using System.Collections.Generic;

namespace Matterix.Models.Admin
{
    public class AdminViewModel
    {
        
        public List<CourseFeedback> FeedBacks { get; set; }
        public List<CourseRating> Ratings { get; set; }
        public List<MatterixInvoice> Invoices { get; set; }
        public List<MatterixPayment> Payments { get; set; }
        public List<Registration> Registrations { get; set; }
        public List<UsedPassword> Passwords { get; set; }
        public List<UserDevice> Activities { get; set; }
        
        public List<OpenLecture> OpenLectures { get; set; }
        public List<InvoiceIncrement> Increments { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}