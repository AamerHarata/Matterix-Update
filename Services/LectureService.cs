using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Matterix.Models;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class LectureService
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseService _courseService;

        public LectureService(ApplicationDbContext context, CourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }
        public List<LectureFile> GetLectureFiles(string lectureId)
        {
            //ToDo :: Check if the Include is really necessary here, if not, then remove it.
            return _context.Files.Include(x => x.Lecture).Where(x=>x.LectureId== lectureId).ToList();

        }
        
        public List<LectureVideo> GetLectureVideos(string lectureId)
        {
            //ToDo :: Check if the Include is really necessary here (mostly it is), if not, then remove it.
            return _context.Videos.Include(x => x.Lecture).Where(x=>x.LectureId == lectureId).OrderBy(x=>x.VideoNumber).ToList();
        }

        public Lecture GetLecture(string lectureId) {return _context.Lectures.SingleOrDefault(x => x.Id == lectureId);}

        public LectureFile GetLectureFile(string lectureId, string fileName)
        {
            return _context.Files.Include(x => x.Lecture).Where(x=>x.LectureId == lectureId).SingleOrDefault(x=>x.Name == fileName);
        }
        
        public List<Homework> GetLectureHomeworkDelivery(string lectureId)
        {
            return _context.Homework.Include(x => x.LectureFile).Include(x => x.Student)
                .Where(x => x.LectureFileLectureId == lectureId).ToList();
        }
        
        public void AddVideos(List<LectureVideo> videos)
        {
            _context.Videos.AddRange(videos);
            _context.SaveChanges();

        }
        public void RemoveAllVideos(string lectureId)
        {
            var videosToDelete = GetLectureVideos(lectureId);
            _context.Videos.RemoveRange(videosToDelete);
            _context.SaveChanges();
        }

        public void AddNewLecture(string courseId, bool intro)
        {
            var course = _courseService.GetCourse(courseId);
            var lectures = _courseService.GetCourseLectures(courseId);
            var lastLecture = lectures.OrderByDescending(x=>x.Date).Where(x=>!x.Introduction).ToList()[1];
            var lastIntroLecture = lectures.OrderBy(x=>x.Number).Where(x=>x.Introduction).Take(1).SingleOrDefault();

            if (lastLecture == null || course == null)
                return;

            var lectureNumber = lastLecture.Number + 2;

            if (intro){
                if(lastIntroLecture == null)
                    lectureNumber = 0;
                else
                    lectureNumber = lastIntroLecture.Number - 1;
            }
            
            var newLecture = new Lecture()
            {
                Course = course, Day = lastLecture.Day, Date = lastLecture.Date.AddDays(7), From = lastLecture.From, To = lastLecture.To,
                Number = lectureNumber, Introduction = intro
            };

            if (intro)
                newLecture.Title = "intro";

            _context.Add(newLecture);
            _context.SaveChanges();

        }

        public Homework HomeworkDeliveredFile(string lectureId, string homeworkRelatedFileName, string userId)
        {
            var homework = GetLectureFile(lectureId, homeworkRelatedFileName);
            if(!homework.IsHomeWork)
                return null;

            var deliveryFile = _context.Homework.Include(x => x.Student).Include(x => x.LectureFile)
                .ToList()
                .Where(x => x.LectureFile.Name == homeworkRelatedFileName)
                .Where(x => x.LectureFile.LectureId == lectureId).SingleOrDefault(x=>x.StudentId == userId);

            return deliveryFile;
        }
        
        
    }
}