using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Microsoft.AspNetCore.Mvc;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseService _courseService;
        private readonly AccessService _access;
        private readonly FilesService _files;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseController(CourseService courseService, ApplicationDbContext context, AccessService access, FilesService files, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _courseService = courseService;
            _access = access;
            _files = files;
            _userManager = userManager;
        }
        public IActionResult CourseBox(string id)
        {
            ViewBag.CoursesId = (from x in _courseService.GetAllCourses() select x.Id).ToList();
            return PartialView("CoursePartial/_CourseBox", _courseService.GetCourse(id));
        }

        [Authorize]
        [Route("/Course/")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return NotFound();

            var userId = _access.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return BadRequest();

            var vm = new MyCoursesViewModel
            {
                OwnedCourses = _courseService.GetOwnedCourses(userId).Where(x => !x.Hidden).ToList(),
                TeachCourses = _courseService.GetTeachCourses(userId).Where(x => !x.Hidden).ToList(),
                ExpiredCourses = _courseService.GetExpiredCourses(userId).Where(x => !x.Hidden).ToList()


            };
            if (User.HasClaim("Role", "Admin"))
                vm.TeachCourses = _courseService.GetAllCourses();
            return View(vm);
        }

        [AllowAnonymous]
        [Route("/Course/Search/{searchPattern?}")]
        public IActionResult Search(string searchPattern, bool live)
        {
            return RedirectToAction("Index", "Home"); // I Added that to temporarily stop search area. The search now is only from Home/Index

            ViewBag.Live = live;
            var courses = new List<Course>();
            if (string.IsNullOrEmpty(searchPattern))
            {
                if (_access.IsAdmin(User))
                    courses = _courseService.GetAllCourses();
                else
                    courses = _courseService.GetAllCourses().Where(x => !x.Hidden).ToList();
            }
            else
            {
                ViewBag.SearchPattern = searchPattern;
                searchPattern = searchPattern.ToUpper();

                if (_access.IsAdmin(User))
                    courses.AddRange(_context.Courses.Include(x => x.Teacher)
                        .Where(x => (x.Teacher.FirstName + " " + x.Teacher.LastName).ToUpper().Contains(searchPattern)
                                  || x.Subject.ToUpper().Contains(searchPattern) || x.Code.ToUpper().Contains(searchPattern) || x.Id.ToUpper().Contains(searchPattern)));
                else
                    courses.AddRange(_context.Courses.Where(x => !x.Hidden).Include(x => x.Teacher)
                        .Where(x => (x.Teacher.FirstName + " " + x.Teacher.LastName).ToUpper().Contains(searchPattern)
                                  || x.Subject.ToUpper().Contains(searchPattern) || x.Code.ToUpper().Contains(searchPattern) || x.Id.ToUpper().Contains(searchPattern)));

            }

            if (live)
            {
                courses = courses.Where(x => !x.Ended).ToList();
            }

            return View(courses);
        }


        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {  //Add new countries
            CourseViewModel model = new CourseViewModel();
            List<Country> countriesList = _courseService.GetAllCountries();
            List<CountryViewModel> countryViewModel = new List<CountryViewModel>();
            foreach (var country in countriesList)
            {
                CountryViewModel c = new CountryViewModel();
                c.Country = country;
                c.isAvailable = false;
                countryViewModel.Add(c);
            }
            model.CountriesViewModel = countryViewModel;

            //Add new countries


            //            if(!User.Identity.IsAuthenticated || !_access.IsTeacherOrAdmin(User))
            //                return BadRequest();

            //The Admin Can Chose all teachers or admin
            if (User.HasClaim("Role", "Admin"))
                ViewData["TeacherId"] = new SelectList(from x in _context.Users.Where(x => x.Role != EnumList.Role.Student) select new { x.Id, x.FirstName, x.LastName, FullName = x.FirstName + " " + x.LastName }
                    , "Id", "FullName");

            //Teacher can just chose him self
            else
                ViewData["TeacherId"] = new SelectList(
                    from x in _context.Users
                        .Where(x => x.Id == _access.GetUserId(User))
                    select new { x.Id, x.FirstName, x.LastName, FullName = x.FirstName + " " + x.LastName }
                    , "Id", "FullName");

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Create(CourseViewModel courseModel)
        {


            if (!ModelState.IsValid || string.IsNullOrEmpty(courseModel.Course.TeacherId))
                return View(courseModel);

            List<CountryViewModel> availableCountriesViewModel = courseModel.CountriesViewModel.Where(x => x.isAvailable == true).ToList();
            var teacher = _context.Users.Find(courseModel.Course.TeacherId);
            if (teacher == null)
                return View(courseModel);

            var course = courseModel.Course;
            var schedules = courseModel.Schedules;
            var picture = courseModel.Picture;
            course.Teacher = teacher;
            _context.Add(course);
            _context.SaveChanges();
            List<Country> courseCountries = availableCountriesViewModel.Select(x => x.Country).ToList();
            course.Countries = courseCountries;

            _courseService.CreateSchedule(course.Id, schedules);
            _courseService.CreateLectures(course.Id, schedules);
            _context.SaveChanges();

            if (picture != null && picture.Length > 0)
                _files.AddCoursePicture(course, picture);

            //ToDo :: Redirect to the course area
            return RedirectToAction("Index", "Course");
        }

        [HttpGet]
        [Authorize(Policy = "AdminOrTeacher")]
        [Route("/Course/Edit/{courseId}")]
        public IActionResult Edit(string courseId)
        {
            var course = _courseService.GetCourse(courseId);
            if (course == null)
                return NotFound();

            var schedules = _courseService.GetCourseSchedule(courseId);
            //Add New Cuntries
            List<Country> countries = _courseService.GetCourseCountries(courseId);
            List<Country> allCountries = _courseService.GetAllCountries();
            List<CountryViewModel> countryViewModel = new List<CountryViewModel>();
            foreach (var country in allCountries)
            {

                CountryViewModel c = new CountryViewModel();
                c.Country = country;
                c.isAvailable = false;
                countryViewModel.Add(c);
            }

            foreach (var country in countries)
            {
                foreach (var cvm in countryViewModel)
                {
                    if (country.IsoCode == cvm.Country.IsoCode)
                    {
                        cvm.isAvailable = true;
                    }
                }
            }
            //Add New Cuntries


            //The Admin Can Chose all teachers or admin
            if (User.HasClaim("Role", "Admin"))
                ViewData["TeacherId"] = new SelectList(from x in _context.Users.Where(x => x.Role != EnumList.Role.Student) select new { x.Id, x.FirstName, x.LastName, FullName = x.FirstName + " " + x.LastName }
                    , "Id", "FullName");

            //Teacher can just chose him self
            else
                ViewData["TeacherId"] = new SelectList(
                    from x in _context.Users
                        .Where(x => x.Id == _access.GetUserId(User))
                    select new { x.Id, x.FirstName, x.LastName, FullName = x.FirstName + " " + x.LastName }
                    , "Id", "FullName");


            var vm = new CourseViewModel() { Course = course, Schedules = schedules, CountriesViewModel = countryViewModel };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrTeacher")]
        public IActionResult Edit(string courseId, CourseViewModel courseModel)
        {

            //Check Model State
            if (!ModelState.IsValid || !courseModel.Schedules.Any())
                return BadRequest();

            var course = _courseService.GetCourse(courseId);
            var teacher = _context.Users.Find(courseModel.Course.TeacherId);

            if (course == null || teacher == null)
                return NotFound();

            //ToDo :: Uncomment this for extra security || Move it up to be in the same method
            //            if(!_access.IsAdmin(User) || !_access.IsCourseTeacher(User, courseId))
            //                return BadRequest();

            _context.RemoveRange(_courseService.GetCourseSchedule(courseId));
            _courseService.CreateSchedule(courseId, courseModel.Schedules);
            _context.SaveChanges();
            //Add New Countries
            var courseCountries = course.Countries;
            if (courseCountries == null)
            {
                courseCountries = new List<Country>();
            }
            foreach (var cvm in courseModel.CountriesViewModel)
            {
                bool isNew = true;
                foreach (var c in courseCountries)
                {
                    if (cvm.Country.IsoCode == c.IsoCode)
                    {
                        isNew = false;
                        if (!cvm.isAvailable)
                        {
                            courseCountries.Remove(c);
                            break;
                        }
                    }
                }
                if (isNew && cvm.isAvailable)
                {
                    Country country = new Country { IsoCode = cvm.Country.IsoCode, Name = cvm.Country.Name };
                    courseCountries.Add(country);
                }
            }
            //Add New Countries
            course.Countries = courseCountries;
            course.Subject = courseModel.Course.Subject;
            course.Code = courseModel.Course.Code;
            course.Language = courseModel.Course.Language;
            course.StartDate = courseModel.Course.StartDate;
            course.EndDate = courseModel.Course.EndDate;
            course.Price = courseModel.Course.Price;
            course.Teacher = teacher;
            course.ClassUrl = courseModel.Course.ClassUrl;
            course.MeetingId = courseModel.Course.MeetingId;
            course.MeetingPass = courseModel.Course.MeetingPass;
            course.Ended = courseModel.Course.Ended;
            course.Hidden = courseModel.Course.Hidden;
            _context.SaveChanges();

            if (courseModel.Picture != null && courseModel.Picture.Length > 0)
                _files.AddCoursePicture(course, courseModel.Picture);

            if (courseModel.Background != null && courseModel.Background.Length > 0)
                _files.AddCourseBackground(course, courseModel.Background);


            return RedirectToAction("CourseArea", new { courseId });
        }


        [Authorize(Policy = "Admin")]
        public IActionResult Delete(string courseId)
        {
            //ToDo :: Use this to delete a course, delete all files and lectures related. Delete all related objects if any.
            return Ok();
        }



        [Route("/Course/Area/{courseId}")]
        [AllowAnonymous]
        public IActionResult CourseArea(string courseId)
        {
            var course = _courseService.GetCourse(courseId);
            if (course == null)
                return BadRequest();

            var schedule = _courseService.GetCourseSchedule(courseId);
            var lectures = _courseService.GetCourseLectures(courseId);
            var files = _courseService.GetCourseFiles(courseId).OrderByDescending(x => x.Lecture.Number).ToList();
            var videos = _courseService.GetCourseVideos(courseId);
            var feedback = _courseService.GetCourseFeedback(courseId);
            var courseHomework = files.Where(x => x.IsHomeWork).OrderByDescending(x => x.Lecture.Number).ThenBy(x => x.DeadLine)
                .ToList();
            var studentsDeliveryHomework = new List<Homework>();

            if (_access.CourseEditAccess(User, courseId))
            {
                studentsDeliveryHomework = _courseService.GetCourseHomeworkDelivery(courseId);
            }
            var homeworkVm = new HomeworkViewModel { CourseHomework = courseHomework, StudentsDeliveredHomework = studentsDeliveryHomework };

            var courseHomeworkForTeacher = new List<LectureFile>();
            var studentsDeliveredHomeworkForTeacher = _context.Homework.Include(x => x.LectureFile)
                .Include(x => x.Student)
                .Where(x => x.LectureFile.Lecture.CourseId == courseId).OrderByDescending(x => x.LectureFile.Lecture.Number)
                .ThenBy(x => x.Mark).ThenBy(x => x.Student.FirstName).ToList();

            var homeworkSectionVmForTeacher = new HomeworkViewModel { CourseHomework = courseHomeworkForTeacher, StudentsDeliveredHomework = studentsDeliveredHomeworkForTeacher };

            var people = new List<ApplicationUser>();

            people.AddRange(_context.Registrations.Where(x => !x.Canceled).Where(x => x.CourseId == courseId).Select(x => x.Student).ToList());


            //Start of Add Countries 
            var country = new List<Country>();
            country = _courseService.GetCourseCountries(courseId);

            var vm = new CourseAreaViewModel
            {
                Course = course,
                Lectures = lectures,
                Schedules = schedule,
                Files = files,
                HomeworkVm = homeworkVm,
                HomeworkVmForTeacher = homeworkSectionVmForTeacher,
                Videos = videos,
                Feedback = feedback,
                People = people            };
            // End of Add Country
            return View(vm);
        }


        [HttpPost]
        [Route("/Course/AddRating/")]
        [Authorize]
        public IActionResult AddRating(string courseId, int rating)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var course = _courseService.GetCourse(courseId);
            if (course == null || user == null)
                return BadRequest("Something went wrong!");

            if (!_access.CourseViewAccess(User, courseId))
                return BadRequest("You don't have access to the course");

            var rate = new CourseRating();
            if (_context.Ratings.Include(x => x.Course).Include(x => x.User).Where(x => x.Course == course).Any(x => x.User == user))
            {
                rate = _context.Ratings.Include(x => x.Course).Include(x => x.User).Where(x => x.CourseId == course.Id)
                    .Single(x => x.UserId == user.Id);
                rate.Rating = rating;
                _context.Ratings.Update(rate);
                _context.SaveChanges();
                return Ok("Rating updated");

            }

            rate = new CourseRating() { Course = course, User = user, Rating = rating };
            _context.Add(rate);
            _context.SaveChanges();
            return Ok("Rating added");

        }

        [Authorize(Policy = "Admin")]
        public IActionResult EditInfo(string extraDescription, string id)
        {
            //ToDo :: If Not Admin, Return
            var course = _courseService.GetCourse(id);
            if (course == null)
                return BadRequest("Course Not Found");

            course.ExtraDescription = extraDescription;
            _context.Update(course);
            _context.SaveChanges();

            return RedirectToAction("CourseArea", new { courseId = id });
        }

        [HttpGet]
        [Route("/Course/GetRating/")]
        [AllowAnonymous]
        public IActionResult GetRating(string courseId)
        {
            var ratingValues = _courseService.GetCourseRating(courseId);
            var userRatingValue = 0;
            userRatingValue = _courseService.GetUserCourseRating(courseId, _access.GetUserId(User));
            return Ok(new { count = ratingValues[0], average = ratingValues[1], userRating = userRatingValue });
        }




        [Route("/Course/AddFeedback")]
        [Authorize]
        [HttpPost]
        public IActionResult AddFeedback(string courseId, string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Text is empty");
            if (!_access.CourseViewAccess(User, courseId))
                return BadRequest("You don't have access to the course");

            var feedback = new CourseFeedback() { Course = _courseService.GetCourse(courseId), User = _userManager.GetUserAsync(User).Result, Text = text };
            _context.CourseFeedback.Add(feedback);
            _context.SaveChanges();
            return PartialView("CoursePartial/_Feedback", feedback);
        }

        [HttpPost]
        [Authorize]
        [Route("/Course/DeleteFeedback")]
        public IActionResult DeleteFeedback(string courseId, string feedbackId)
        {
            var feedback = _context.CourseFeedback.Include(x => x.User).SingleOrDefault(x => x.Id == feedbackId);
            if (feedback == null)
                return NotFound("Feedback not exists");
            var user = _userManager.GetUserAsync(User).Result;
            if (user.Id != feedback.UserId && !_access.CourseViewAccess(User, courseId))
                return BadRequest("You don't have access to this comment");
            try
            {
                _context.Remove(feedback);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Error: please use the code: DLCOMNT23, to contuct us!");
            }
        }





    }
}
