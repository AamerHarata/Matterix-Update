namespace Matterix.Models
{
    public class Homework
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string RootPath { get; set; }
        
        public int Mark { get; set; } = 0;
        public string TeacherComment { get; set; }= "";
        public string LectureFileName { get; set; }
        public string LectureFileLectureId { get; set; }
        public LectureFile LectureFile { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}