namespace Matterix.Models
{
    public class LectureVideo
    {
        public string Url { get; set; }
        public string UniqueCode { get; set; }
        public string Name { get; set; }
        public int VideoNumber { get; set; }
        public string LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}