using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Matterix.Models.ViewModel
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Schedule> Schedules { get; set; }
        public IFormFile Picture { get; set; }

        public IFormFile Background { get; set; }
    }
}