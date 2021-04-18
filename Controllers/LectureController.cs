using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Controllers
{
    public class LectureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseService _courseService;
        private readonly IWebHostEnvironment _environment;
        private readonly LectureService _lectureService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AccessService _access;
        private readonly EmailService _email;
        private readonly SmsService _sms;

        public LectureController(ApplicationDbContext context, CourseService courseService, IWebHostEnvironment environment, LectureService lectureService, UserManager<ApplicationUser> userManager, AccessService access, EmailService email, SmsService sms)
        {
            _context = context;
            _courseService = courseService;
            _environment = environment;
            _lectureService = lectureService;
            _userManager = userManager;
            _access = access;
            _email = email;
            _sms = sms;
        }

        
        
        
        [Route("/Lecture/Update/")]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult Update(string lectureId, string courseId, string title, string description,
            string preparation, bool completed, bool free, TimeSpan from, TimeSpan to, EnumList.Days day, DateTime lectureDate)
        {
            //Check if the day match the date
            if (_context.Lectures.Where(x=>x.CourseId == courseId).Where(x => x.Id != lectureId).Any(x => x.Date == lectureDate))
            {
//                return BadRequest("The date already taken");
                return BadRequest("dateTaken");
            }
            
            if (lectureDate.DayOfWeek.ToString() != day.ToString())
                return BadRequest("dayNotMatch");

            if (to < from)
                return BadRequest("endTimeHigher");
            
            
            var lecture = _lectureService.GetLecture(lectureId);

            if (lecture == null)
                return BadRequest("errorHappened");

            var oldDate = lecture.Date;

            lecture.Title = title;
            lecture.Description = description;
            lecture.Preparation = preparation;
            lecture.Completed = completed;
            lecture.Free = free;
            lecture.Day = day;
            lecture.Date = lectureDate;
            lecture.From = from;
            lecture.To = to;

            try
            {
                _context.Lectures.Update(lecture);
                _context.SaveChanges();
                
            }
            catch
            {
                return BadRequest("errorHappened");
            }


            if (oldDate != lectureDate)
                _courseService.ReorderCourseLectures(lecture.CourseId);
            
            return Ok();

            
        }


        [Route("/Lecture/UploadFile/")]
        [HttpPost]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult UploadFile(string lectureId)
        {
            
        //Get the file from request
            var file = Request.Form.Files[0];
            
            //Check if the file empty
            if (file == null || file.Length == 0)
                return BadRequest("fileEmpty");

            //Should not contains "!!!" because it used by my system for naming
            if (file.Name.Contains("@"))
                return BadRequest("invalidName");

            var acceptedFiles = new List<string>()
            {
                "application/vnd.oasis.opendocument.text", "application/octet-stream",
                "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "application/vnd.ms-powerpoint",
                "application/pdf", "application/vnd.geogebra.file", "image/png", "image/jpeg"
            };

            if (!acceptedFiles.Contains(file.ContentType))
            {
                Console.WriteLine($"File Type not supported is: {file.ContentType}");
                return BadRequest("fileTypeNotSupported");
            }

            var lecture = _lectureService.GetLecture(lectureId);
            var course = _courseService.GetCourse(lecture.CourseId);
            
            var envRoot = _environment.ContentRootPath;
            var root = "wwwroot";
            const string fileFolder = "Files";
            const string courseFiles = "CourseFiles";
            var courseTarget = course.Subject + "-" + course.StartDate.Year + "-" + course.Id;
            var fileName = "LecNr-" + lecture.Number + "@"+file.Name;
            var fileSaveTargetPath = Path.Combine(envRoot, root, fileFolder, courseFiles, courseTarget, fileName);
            var fileGetPath = "~/" + fileFolder + "/" + courseFiles + "/" + courseTarget + "/" + fileName;

            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            // It was repeated, seems to be wrong, let's try to comment it out
//            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
//                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            if (Directory.GetDirectories(envRoot+"/"+root+"/"+ fileFolder, courseFiles).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+courseFiles));
            
            if(Directory.GetDirectories(envRoot+"/"+root+"/"+fileFolder+"/"+courseFiles, courseTarget).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+courseFiles+"/"+courseTarget));

            if (Directory.GetFiles(envRoot+"/" + root + "/" + fileFolder + "/" + courseFiles + "/" + courseTarget, fileName).Length !=
                0)
                return BadRequest("fileExists");



            try
            {
                using (var stream = new FileStream(fileSaveTargetPath, FileMode.Create))
                {
                    file.CopyToAsync(stream).Wait();
                }
                
                var courseFile = new LectureFile()
                {
                    Lecture = lecture, Name = file.Name, Path = fileGetPath, RootPath = fileSaveTargetPath
                };

                _context.Add(courseFile);
                _context.SaveChanges();
                return Ok("fileAddedSuccessfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("errorRefresh");
            }

        }
        
        [Route("/Lecture/GetFile")]
        [HttpGet]
        public IActionResult GetFile(string lectureId, string name)
        {
            var file = _lectureService.GetLectureFile(lectureId, name);

            return PartialView("../Course/CoursePartial/_LectureFile", file);
        }
        
        
        
        [Route("/Lecture/DeleteFile/")]
        [HttpDelete]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult DeleteFile(string lectureId, string name)
        {
            //Get file entry from database
            var file = _lectureService.GetLectureFile(lectureId, name);

            if (file == null)
                return BadRequest("error");
            
            

            try
            {
                System.IO.File.Delete(file.RootPath);
                
                _context.Remove(file);
                _context.SaveChanges();
                return Ok("File"+name+"Deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("errorHappened");
            }
            

        }



        [HttpGet]
        [Route("/Lecture/EditFile")]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult EditFile(string lectureId, string name)
        {
            var file = _lectureService.GetLectureFile(lectureId, name);
            return PartialView("../Course/CoursePartial/_LectureFileEdit", file);

        }
        
        [HttpPut]
        [Route("/Lecture/EditFile")]
        [Authorize(Policy = "AdminOrTeacher")]
        public async Task<IActionResult> EditFile(string lectureId, string name, bool isHomework, DateTime deadLine, bool notification)
        {
            var file = _lectureService.GetLectureFile(lectureId, name);
            if (file == null)
                return BadRequest("error");

            var wasHomework = file.IsHomeWork;
            
            file.IsHomeWork = isHomework;
            file.DeadLine = isHomework ? deadLine : Format.NorwayDateTimeNow();

            _context.Update(file);
            await _context.SaveChangesAsync();

            if (wasHomework || !isHomework) return Ok("File updated");
            
            if (!notification) return Ok("File updated");
            
            var lecture = _lectureService.GetLecture(lectureId);
            var registeredStudent = _context.Registrations.ToList()
                .Where(x => x.IsActive())
                .Where(x => x.CourseId == lecture.CourseId)
                .Select(x => x.StudentId)
                .ToList();
            var studentIds = registeredStudent;
            studentIds.Add(_context.Courses.Find(lecture.CourseId).TeacherId);
            await _email.FileAddedNotification(studentIds, lectureId, name);


            return Ok("File updated");

        }
        
        [Route("/Lecture/GetVideos")]
        [HttpGet]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult AddVideos(string lectureId)
        {
            var lectureVideo =  _lectureService.GetLectureVideos(lectureId);
            var vm = new VideoViewModel()
            {
                OneLectureVideos = lectureVideo, AllCourseVideos = new List<LectureVideo>()
            };

            return PartialView("../Course/CoursePartial/_LectureVideoAdd", vm);
        }
        
        [Route("/Lecture/AddVideos")]
        [HttpPost]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult AddVideos(List<LectureVideo> videos)
        {
            if (videos == null || videos.Count ==0)
                return BadRequest();

            foreach (var video in videos)
                video.UniqueCode = Guid.NewGuid().ToString();
            var lecture = _lectureService.GetLecture(videos[0].LectureId);
            _lectureService.RemoveAllVideos(lecture.Id);
            _lectureService.AddVideos(videos);
            
            
            return PartialView("../Course/CoursePartial/_LectureVideo", videos);
        }
        
        
        [Route("/Lecture/RemoveVideos")]
        [HttpPost]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult DeleteVideos(string lectureId)
        {
            
            _lectureService.RemoveAllVideos(lectureId);
            
            
            return PartialView("../Course/CoursePartial/_LectureVideo", new List<LectureVideo>());
        }

        [Route("/Lecture/AddNewLecture")]
        [HttpPost]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult AddNewLecture(string courseId, bool intro)
        {
            if (intro)
                if (!_access.IsAdmin(User))
                    return BadRequest();
            _lectureService.AddNewLecture(courseId, intro);

            return Ok();
        }

        [Route("/Lecture/AddHomework")]
        [Authorize]
        public IActionResult AddHomework(string lectureId, string courseId, string studentId, string homeworkFileName)
        {
            //Get the related lecture file (Homework)
            var lectureFile = _lectureService.GetLectureFile(lectureId, homeworkFileName);
            
            //Check if the request is valid
            if (lectureFile == null)
                return NotFound();
            
            
            //Get the delivery file
            var homeworkDelivery = Request.Form.Files[0];
            var homeworkDeliveryName = homeworkDelivery.Name;
            
            
            //Delivery not exist, so make a new one
            var oldHomeworkInDatabase =
                _lectureService.HomeworkDeliveredFile(lectureId, homeworkFileName, studentId);
            
            //Check if the file empty
            if (homeworkDelivery.Length == 0)
                return BadRequest("fileEmpty");

            //Should not contains "!!!" because it used by my system for naming
            if (homeworkDeliveryName.Contains("@"))
                homeworkDeliveryName = homeworkDeliveryName.Replace("@", "");

            if (homeworkDelivery.Length > 25 * 1024 * 1024)
                return BadRequest("largeFileMax25");

            var acceptedFiles = new List<string>()
            {
                "application/vnd.oasis.opendocument.text", "application/octet-stream",
                "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "application/vnd.ms-powerpoint",
                "application/pdf", "application/vnd.geogebra.file", "image/png", "image/jpeg"
            };

            if (!acceptedFiles.Contains(homeworkDelivery.ContentType))
            {
                Console.WriteLine($"File Type not supported is: {homeworkDelivery.ContentType} ------------------");
                return BadRequest("fileTypeNotSupported");
            }

            var course = _courseService.GetCourse(courseId);
            var lecture = _lectureService.GetLecture(lectureId);
            var student = _userManager.GetUserAsync(User).Result;

            if (course == null || lecture == null || student == null)
                return NotFound("errorHappened");
            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string fileFolder = "Files";
            const string homeworksDelivery = "HomeworksDelivery";
            var courseTarget = course.Subject + "-" + course.StartDate.Year + "-" + course.Id;
            var homeworkDeliveryFileName = "LecNr-" + lecture.Number + "-" + student.FirstName + "-" +student.LastName+ "@"+homeworkDeliveryName;
            
            
            var fileSaveTargetPath = Path.Combine(envRoot, root, fileFolder, homeworksDelivery, courseTarget, homeworkDeliveryFileName);
            var fileGetPath = "~/" + fileFolder + "/" + homeworksDelivery + "/" + courseTarget + "/" + homeworkDeliveryFileName;

            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            if (Directory.GetDirectories(envRoot+"/"+root+"/"+ fileFolder, homeworksDelivery).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+homeworksDelivery));
            
            if(Directory.GetDirectories(envRoot+"/"+root+"/"+fileFolder+"/"+homeworksDelivery, courseTarget).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+homeworksDelivery+"/"+courseTarget));

//            if (Directory.GetFiles(envRoot+"/" + root + "/" + fileFolder + "/" + homeworksDelivery + "/" + courseTarget, homeworkDeliveryFileName).Length !=
//                0)
//                return BadRequest("Files in same name delivered");



            try
            {
                using (var stream = new FileStream(fileSaveTargetPath, FileMode.Create))
                {
                    homeworkDelivery.CopyToAsync(stream).Wait();
                }

                
                
                
                var newHomeworkDeliveryFile = new Homework()
                {
                    LectureFile = lectureFile, Name = homeworkDelivery.FileName, Path = fileGetPath, RootPath = fileSaveTargetPath, Student = student
                };
                
                if (oldHomeworkInDatabase != null)
                {
                    System.IO.File.Delete(oldHomeworkInDatabase.RootPath);
                    _context.Remove(oldHomeworkInDatabase);
                    _context.SaveChanges();
                }
                

                _context.Add(newHomeworkDeliveryFile);
                _context.SaveChanges();
                return Ok("File Added Successfully");
        }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Error! Please refresh and try again.");
            }
        }
        
        [Route("/Lecture/AddMark")]
        [Authorize(Policy = "AdminOrTeacher")]
        [HttpPut]
        public async Task<IActionResult> AddMark(string lectureId,  string relatedHomeworkFileName, string studentId, int mark)
        {
            var homeWorkDeliveryFile =
                _lectureService.HomeworkDeliveredFile(lectureId, relatedHomeworkFileName, studentId);
            if (homeWorkDeliveryFile == null)
                return BadRequest("errorHappened");

            try
            {
                homeWorkDeliveryFile.Mark = mark;
                _context.Update(homeWorkDeliveryFile);
                await _context.SaveChangesAsync();
                
                await _email.MarkAddedNotification(studentId, homeWorkDeliveryFile.Name, mark, homeWorkDeliveryFile.TeacherComment);
                
                return Ok();

            }
            catch
            {
//                return BadRequest("Error: Use the code: ADMRK21, to contact us!");
                return BadRequest("errorHappened");
            }
        }
        
        
        
        [Route("/Lecture/AddHomeworkComment")]
        [Authorize(Policy = "AdminOrTeacher")]
        [HttpPut]
        public IActionResult AddHomeworkComment(string lectureId,  string relatedHomeworkFileName, string studentId, string comment)
        {
            var homeWorkDeliveryFile =
                _lectureService.HomeworkDeliveredFile(lectureId, relatedHomeworkFileName, studentId);
            if (homeWorkDeliveryFile == null)
                return BadRequest("errorHappened");

            try
            {
                homeWorkDeliveryFile.TeacherComment = comment;
                _context.Update(homeWorkDeliveryFile);
                _context.SaveChanges();
                
                
                return Ok();

            }
            catch
            {
                return BadRequest("errorHappened");
            }
        }
        
        [Route("/Lecture/GetUrl")]
        [HttpGet]
        public IActionResult GetVideoUrl(string videoId)
        {
            var video = _context.Videos.Include(x=>x.Lecture).SingleOrDefault(x => x.UniqueCode == videoId);

            
            if (video == null)
                return BadRequest("Video Not Exists");
            
            var isVideoOpen = _access.CourseViewAccess(User, video.Lecture.CourseId) || video.Lecture.Free ||  video.Lecture.Introduction || _access.IsLectureOpen(video.LectureId, User);

            if(isVideoOpen)
                return Ok(new {url = video.Url, lectureNumber = video.Lecture.Number, name = video.Lecture.Title});

            return BadRequest("No Access");
            
        }

        [Route("/Lecture/SendLectureReminder/")]
        [Authorize(Policy = "AdminOrTeacher")]
        public async Task<IActionResult> SendLectureReminder(string courseId)
        {
            var course = _courseService.GetCourse(courseId);
            if (course == null)
                return NotFound("Fatal error! Course not found.. Contact admin");
            
            var lectureToday = await _context.Lectures.Where(x => x.CourseId == courseId)
                .SingleOrDefaultAsync(x => x.Date == Format.NorwayDateNow());
            if (lectureToday == null)
                return BadRequest("No Lecture Today");
            
            var minutes = (int) lectureToday.From.Subtract(Format.NorwayTimeNow()).TotalMinutes;

            if (minutes > 45)
                return BadRequest("Still more than 45 minutes to the lecture! Please try again later ...");

            var alreadyNotified = _context.Notifications
                .Where(x => x.Reference == lectureToday.Id)
                .Where(x => x.Type == EnumList.Notifications.LectureStart)
                .ToList()
                .Any(x => x.TimeToSend.Date == Format.NorwayDateNow());
            if(alreadyNotified)
                return BadRequest("Notifications for this lecture has already been sent via SMS and E-mail");
            
                
            

            var registrations = _context.Registrations.ToList()
                .Where(x => x.CourseId == courseId).Where(x => x.IsActive())
                .ToList();
            var studentIds = new List<string>();
            
            foreach(var reg in registrations)
                studentIds.Add(reg.StudentId);
            
            studentIds.Add(course.TeacherId);
            
            // var adminId = _context.Users.ToList().SingleOrDefault(x =>
            //     string.Equals(x.Email, "Aamer.harata@hotmail.com", StringComparison.CurrentCultureIgnoreCase))?.Id;
            var adminId = StaticInformation.AdminMatterixId;
            
            if(!string.IsNullOrEmpty(adminId) && course.TeacherId != adminId)
                studentIds.Add(adminId);
            
            
            //Create Email notifications
            await _email.LectureReminderEmail(studentIds, lectureToday.Id);
            
            //Create SMS notifications
            await _sms.LectureReminder(studentIds, lectureToday.Id);
            
            return Ok();
        }


        [Route("/Lecture/Delete/")]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult DeleteLecture(int lectureNumber, string lectureId)
        {
            var lecture = _lectureService.GetLecture(lectureId);

            if (lecture == null || lecture.Number != lectureNumber)
                return BadRequest("Error Happened");

            var courseId = lecture.CourseId;

            _lectureService.RemoveAllVideos(lectureId);
            
            var files = _lectureService.GetLectureFiles(lectureId);
            var homeworkDelivery = _lectureService.GetLectureHomeworkDelivery(lectureId);

            foreach (var file in files)
            {
                try
                {
                    System.IO.File.Delete(file.RootPath);
                
                    _context.Remove(file);
                    _context.SaveChanges();
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Lecture: {lecture.Number}, id: {lectureId}, file: {file.Name} not deleted");
                }
                
            }
            
            
            
            foreach (var file in homeworkDelivery)
            {
                try
                {
                    System.IO.File.Delete(file.RootPath);
                
                    _context.Remove(file);
                    _context.SaveChanges();
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Lecture: {lecture.Number}, id: {lectureId}, homework: {file.Name} not deleted");
                }
                
            }

            _context.Remove(lecture);
            _context.SaveChanges();
            
            _courseService.ReorderCourseLectures(courseId);
            
            
            


            return Ok("dataSavedSuccessfully");
            
            
        }
        
        public FileResult DownloadFile(string path, string name)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            string fileName = name;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        
        
        

    }
}