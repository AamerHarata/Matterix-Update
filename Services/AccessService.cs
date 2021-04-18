using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class AccessService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CourseService _courseService;

        public AccessService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, CourseService courseService)
        {
            _context = context;
            _userManager = userManager;
            _courseService = courseService;
        }

        public bool IsAdmin(ClaimsPrincipal user){return user != null && user.HasClaim("Role", "Admin");}
        
        public bool IsTeacher(ClaimsPrincipal user){return user!=null && user.HasClaim("Role", "Teacher");}

        public bool IsTeacherOrAdmin(ClaimsPrincipal user){return IsAdmin(user) || IsTeacher(user);}

        public bool IsCourseTeacher(ClaimsPrincipal user, string courseId){return user != null && _courseService.GetCourse(courseId).TeacherId == GetUserId(user);} //ToDo :: I don't know if the teacher Id is already included

        public Registration GetStudentActiveRegistration(ClaimsPrincipal user, string courseId)
        {
            var student = _userManager.GetUserAsync(user).Result;
            if (student == null)
                return null;
            return _context.Registrations.Include(x => x.Course).ToList().Where(x => x.StudentId == student.Id)
                .Where(x => x.IsActive()).SingleOrDefault(x => x.CourseId == courseId);
        }
        
        public Registration GetStudentActiveRegistration(string studentId, string courseId)
        {
            if (string.IsNullOrEmpty(studentId))
                return null;
            return _context.Registrations.Include(x => x.Course).ToList().Where(x => x.StudentId == studentId)
                .Where(x => x.IsActive()).SingleOrDefault(x => x.CourseId == courseId);
        }
        
        public Registration GetStudentExpiredRegistration(ClaimsPrincipal user, string courseId)
        {
            var student = _userManager.GetUserAsync(user).Result;
            if (student == null)
                return null;
            return _context.Registrations.Include(x => x.Course).ToList().Where(x => x.StudentId == student.Id)
                .Where(x => x.Expire && !x.Canceled).SingleOrDefault(x => x.CourseId == courseId);
        }

        public bool CourseViewAccess(ClaimsPrincipal user, string courseId)
        {
            if (!user.Identity.IsAuthenticated)
                return false;
            return CourseEditAccess(user, courseId) || GetStudentActiveRegistration(user, courseId) != null;
        }
        
        public bool CourseViewAccess(string studentId, string courseId)
        {
            return GetStudentActiveRegistration(studentId, courseId) != null;
        }

        public bool CourseEditAccess(ClaimsPrincipal user, string courseId){return IsAdmin(user) || IsCourseTeacher(user, courseId);}

        public bool CourseEndedAccess(ClaimsPrincipal user, string courseId){return GetStudentExpiredRegistration(user, courseId) != null;}
        public string GetUserId(ClaimsPrincipal user){return _userManager.GetUserId(user)?? "";}


        public bool IsLectureOpen(string lectureId, ClaimsPrincipal user)
        {
            var studentId = GetUserId(user);
            return _context.OpenLectures.Where(x => x.StudentId == studentId).Where(x => x.ExpireDate.Date >= Format.NorwayDateTimeNow().Date)
                .Any(x => x.LectureId == lectureId);
        }
    }
}