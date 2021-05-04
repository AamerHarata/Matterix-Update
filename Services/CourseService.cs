using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.Objects;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class CourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context) { _context = context; }

        //This method has been modefied due to  new Countries feature
        public Course GetCourse(string courseId)
        {
            return _context.Courses.Include(x => x.Teacher).Include(x => x.Countries).SingleOrDefault(x => x.Id == courseId);
        }

        public List<Course> GetAllCourses() { return _context.Courses.Include(x => x.Teacher).OrderByDescending(x => x.StartDate).ToList(); }

        public List<Course> GetOwnedCourses(string studentId)
        {
            SetExpiredCourses(studentId);

            var courseRegistered = _context.Registrations
                .Include(x => x.Student)
                .Include(x => x.Course)
                .ThenInclude(x => x.Teacher)
                .ToList()
                .Where(x => x.StudentId == studentId)
                .Where(x => x.IsActive())
                .OrderByDescending(x => x.RegisterDate)
                .Select(x => x.Course).ToList();

            return courseRegistered;
        }

        public void SetExpiredCourses(string studentId)
        {
            var registrations = _context.Registrations.Include(x => x.Course)
                .Where(x => x.StudentId == studentId)
                .Where(x => !x.Expire)
                .ToList();
            foreach (var registration in registrations)
            {
                if (registration.ExpireDate.Date > Format.NorwayDateTimeNow().Date) continue;
                registration.Expire = true;
                _context.Update(registration);
                _context.SaveChanges();
            }
        }
        public List<Course> GetExpiredCourses(string studentId)
        {
            var courseExpired = _context.Registrations.Include(x => x.Student).Include(x => x.Course).ThenInclude(x => x.Teacher).ToList()
                .Where(x => x.StudentId == studentId)
                .Where(x => x.Expire)
                .OrderByDescending(x => x.RegisterDate).Select(x => x.Course).ToList();

            return courseExpired;
        }

        public List<Course> GetTeachCourses(string teacherId)
        {
            return _context.Courses.Include(x => x.Teacher).Where(x => x.TeacherId == teacherId).ToList();
        }

        public List<Schedule> GetCourseSchedule(string courseId)
        {
            var course = GetCourse(courseId);
            return course == null
                ? new List<Schedule>()
                : _context.Schedules.Include(x => x.Course).Where(x => x.CourseId == courseId).OrderBy(x => x.Day)
                    .ToList();
        }

        //ToDo :: Fix lectures count and completed hours by calculating all lectures time correctly
        public int GetLecturesCount(string courseId) { return _context.Lectures.Where(x => !x.Introduction).Count(x => x.CourseId == courseId); }

        public int GetCompletedLecturesCount(string courseId) { return _context.Lectures.Where(x => x.CourseId == courseId).Where(x => !x.Introduction).Count(x => x.Completed); }

        public List<Lecture> GetNonCompletedLectures(string courseId)
        {
            return _context.Lectures.Include(x => x.Course).Where(x => x.CourseId == courseId).Where(x => !x.Course.Ended && !x.Course.Hidden).Where(x => !x.Completed)
                .OrderBy(x => x.Date).ToList();
        }

        public int GetStudentsCount(string courseId) { return _context.Registrations.Where(x => !x.Canceled).Count(x => x.CourseId == courseId); }

        public double ExpectedTotalHours(string courseId) { return ExpectedHours(courseId, "Total"); }

        public double CompletedHours(string courseId) { return ExpectedHours(courseId, "Completed"); }

        private double ExpectedHours(string courseId, string mode)
        {
            var lectureCount = mode.Equals("Total") ? GetLecturesCount(courseId) : GetCompletedLecturesCount(courseId);
            var schedules = GetCourseSchedule(courseId);
            if (lectureCount == 0 || schedules.Count == 0) return 0;
            var totalHours = 0.0;
            foreach (var schedule in schedules)
                totalHours += (schedule.To.TotalHours - schedule.From.TotalHours);
            return Math.Round(lectureCount * totalHours / schedules.Count, 2); // ToDo :: Check if the calculation is correct
        }


        public List<Lecture> GetCourseLectures(string courseId) { return _context.Lectures.Where(x => x.CourseId == courseId).OrderBy(x => x.Number).ThenBy(x => x.Date).ToList(); }

        public void ReorderCourseLectures(string courseId)
        {

            var lectures = GetCourseLectures(courseId);
            var course = GetCourse(courseId);
            if (!lectures.Any() || course == null)
                return;

            lectures = lectures.Where(x => !x.Introduction).OrderBy(x => x.Date).ToList();
            var i = 1;
            foreach (var lec in lectures)
            {
                lec.Number = i;
                _context.Update(lec);
                _context.SaveChanges();
                i++;
            }
        }

        public List<LectureFile> GetCourseFiles(string courseId)
        {
            return _context.Files.Include(x => x.Lecture).Where(x => x.Lecture.CourseId == courseId)
                .OrderBy(x => x.Lecture.Number).ThenBy(x => x.UploadDate).ToList();
        }

        public List<Homework> GetCourseHomeworkDelivery(string courseId)
        {
            return _context.Homework.Include(x => x.LectureFile).Include(x => x.Student)
                .Where(x => x.LectureFile.Lecture.CourseId == courseId).ToList();
        }

        public List<LectureVideo> GetCourseVideos(string courseId)
        {
            return _context.Videos.Include(x => x.Lecture).Where(x => x.Lecture.CourseId == courseId)
                .OrderBy(x => x.Lecture.Number).ThenBy(x => x.VideoNumber).ToList();
        }

        public List<CourseFeedback> GetCourseFeedback(string courseId)
        {
            return _context.CourseFeedback.Include(x => x.User).Include(x => x.Course)
                .Where(x => x.CourseId == courseId).OrderByDescending(x => x.DateTime).ToList();
        }


        public int[] GetCourseRating(string courseId)
        {
            var course = GetCourse(courseId);
            var rating = _context.Ratings.Include(x => x.Course).Where(x => x.Course == course);
            var count = rating.Count();
            var average = 0.0;
            if (rating.Any())
            {
                average = rating.Average(x => x.Rating);
            }

            average = Math.Round(average, 0, MidpointRounding.AwayFromZero);
            return new[] { count, (int)average };
        }

        public int GetUserCourseRating(string courseId, string userId)
        {
            var rating = _context.Ratings.Where(x => x.UserId == userId)
                .Where(x => x.CourseId == courseId);
            return rating.Any() ? rating.SingleAsync().Result.Rating : 0;
        }




















        public void CreateSchedule(string courseId, List<Schedule> schedules)
        {
            var course = GetCourse(courseId);
            if (course == null || !schedules.Any())
                return;

            schedules = schedules.OrderBy(x => x.Day).ToList();
            var lectures = GetCourseLectures(courseId);
            lectures = lectures.Where(x => !x.Completed && !x.Introduction).ToList();

            var index = 1;
            foreach (var schedule in schedules)
            {


                foreach (var lecture in lectures)
                {
                    if (lecture.Day != schedule.Day) continue;
                    lecture.From = schedule.From;
                    lecture.To = schedule.To;
                    _context.Update(lecture);
                    _context.SaveChanges();
                }



                schedule.Course = course;
                schedule.Number = index;
                index++;
                _context.Add(schedule);
                _context.SaveChanges();

            }


        }
        public void CreateLectures(string courseId, List<Schedule> schedules)
        {
            var course = GetCourse(courseId);
            if (course == null)
                return;

            //Order schedules by number
            schedules = schedules.OrderBy(x => x.Number).ToList();
            var count = schedules.Count;


            var lectureDate = course.StartDate;
            var lectures = new List<Lecture>();
            var lectureNumber = 1;

            while (lectureDate <= course.EndDate)
            {
                foreach (var schedule in schedules)
                {
                    if (string.Compare(schedule.Day.ToString(), lectureDate.DayOfWeek.ToString(),
                            StringComparison.CurrentCultureIgnoreCase) != 0) continue;
                    var lecture = new Lecture()
                    {
                        Course = course,
                        Number = lectureNumber,
                        Day = schedule.Day,
                        From = schedule.From,
                        To = schedule.To,
                        Date = lectureDate,
                        Title = ""
                    };
                    //                    Title = course.Subject+" - Lecture: "+lectureNumber //ToDo :: I changed this
                    _context.Add(lecture);
                    _context.SaveChanges();
                    lectureNumber++;
                }

                lectureDate = lectureDate.AddDays(1);
            }
        }


        public CourseObject CourseObject(string courseId, string studentId)
        {
            var course = GetCourse(courseId);
            var teacher = course.Teacher;
            var schedules = GetCourseSchedule(courseId);
            var nextLecture = new Lecture(); //ToDo :: Create function to get the next lecture
            var registration = _context.Registrations.Where(x => x.StudentId == studentId)
                .Where(x => x.CourseId == courseId).SingleOrDefault(x => x.IsActive());
            var validRegistration = registration != null;


            var courseObject = new CourseObject()
            { Course = course, Teacher = teacher, Schedules = schedules, NextLecture = nextLecture, ValidRegistration = validRegistration };


            return courseObject;
        }

        public DateTime EstimateRegExpireDate(string courseId)
        {
            var course = GetCourse(courseId);
            if (course == null)
                return DateTime.MinValue;
            var expireDate = Format.NorwayDateTimeNow().AddYears(1);
            if (course.StartDate > Format.NorwayDateTimeNow())
                expireDate = course.StartDate.AddYears(1);

            return expireDate;
        }

        public async Task<Registration> AddOrRenewRegistration(string courseId, string userId, UserDevice device = null)
        {
            var course = GetCourse(courseId);
            var user = await _context.Users.FindAsync(userId);
            if (course == null || user == null)
                return null;

            if (device == null)
                device = new UserDevice() { Ip = "000.000.000.000", AuthCookies = "AdminDeviceAuthenticationWhereDidItBeenRegistered" };


            var expireDate = EstimateRegExpireDate(courseId);

            //Check if registration exists
            var oldRegistration = _context.Registrations.Find(userId, course.Id);

            if (oldRegistration == null)
            {
                var registration = new Registration
                {
                    Course = course,
                    Student = user,
                    Price = course.Price,
                    IpAddress = device.Ip,
                    ExpireDate = expireDate,
                    AuthCookies = device.AuthCookies,
                    Count = 1
                };
                await _context.AddAsync(registration);
                await _context.SaveChangesAsync();
                return registration;
            }
            else
            {
                oldRegistration.Expire = false;
                oldRegistration.Canceled = false;
                oldRegistration.ExpireDate = expireDate;
                oldRegistration.Price = course.Price;
                oldRegistration.Count++;
                _context.Update(oldRegistration);
                await _context.SaveChangesAsync();
                return oldRegistration;
            }
        }

        //Add New Languages
        public List<Country> GetAllCountries()
        {
            var allCountryList = _context.Country.ToList();
            return allCountryList;
        }


        //Add New Languages
        public List<Country> GetCourseCountries(string courseId)
        {
            var courseCountries = (from country in _context.Country
                                   where country.Courses.Any(c => c.Id == courseId)
                                   select country).ToList();
            return courseCountries;
        }
    }
}