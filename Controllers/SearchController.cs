using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Matterix.Models.Objects;
using Matterix.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matterix.Controllers
{
    public class SearchController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly CourseService _course;
        private readonly AccessService _access;

        public SearchController(ApplicationDbContext context, CourseService course, AccessService access)
        {
            _context = context;
            _course = course;
            _access = access;
        }

        public IActionResult GetAllCourses()
        {
//            var courses = _course.GetAllCourses().Where(x=>!x.Hidden);
//            var userId = _access.GetUserId(User);
//            
//            var courseObjects = courses.Select(course => _course.CourseObject(course.Id, userId)).ToList();
//
            return Ok();
        }
        
    }
}