namespace Matterix.Models
{
    public class CourseRating
    {
        //Rating Value
        public int Rating { get; set; }
        
        //Combine key
        public string CourseId { get; set; }
        public Course Course { get; set; }
        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}