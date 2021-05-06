using System.Collections.Generic;
using Matterix.Services;
using Microsoft.AspNetCore.Http;

namespace Matterix.Models.ViewModel
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Schedule> Schedules { get; set; }
        public IFormFile Picture { get; set; }
        public List<Country> Countries { get; set; }
        public bool isAvailable { get; set; }
        public IFormFile Background { get; set; }
        //Add New Countries
        public List<CountryViewModel> CountriesViewModel { get; set; }
    }
}