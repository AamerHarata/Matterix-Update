using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Matterix.Services
{
    public class InformationService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CourseService _courseService;
        private readonly IWebHostEnvironment _env;

        public InformationService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, CourseService courseService, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _courseService = courseService;
            _env = env;
        }
        
        public string ProfilePicture(ApplicationUser user)
        {
            if (user == null)
                return "~/Images/DefaultImages/DefaultMan.jpg";

            if (!string.IsNullOrEmpty(user.ProfilePicture)) return $"~/Files/ProfilePictures/{user.ProfilePicture}";
            if (user.Gender == EnumList.Gender.Female || user.Gender == EnumList.Gender.Other)
                return "~/Images/DefaultImages/DefaultWoman.jpg";

            return "~/Images/DefaultImages/DefaultMan.jpg";

        }
        
        public string ProfilePicture(ClaimsPrincipal User)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
                return "~/Images/DefaultImages/DefaultMan.jpg";

            if (!string.IsNullOrEmpty(user.ProfilePicture)) return $"~/Files/ProfilePictures/{user.ProfilePicture}";
            if (user.Gender == EnumList.Gender.Female || user.Gender == EnumList.Gender.Other)
                return "~/Images/DefaultImages/DefaultWoman.jpg";

            return "~/Images/DefaultImages/DefaultMan.jpg";

        }


        public string GetProfileLink(ClaimsPrincipal owner)
        {
            var user = _userManager.GetUserAsync(owner).Result;
            return $"/{user.ProfileUserName}";
        }

//        public string GetProfileLink(ApplicationUser other)
//        {
//            var user = _userManager.GetUserAsync().Result;
//        }

        public string CoursePicture(string courseId)
        {
//            var course = _courseService.GetCourse(courseId);
//            if (course == null)
//                return "";
//            return course.Picture == "" ? "~/Images/DefaultImages/DefaultCourse.png" : $"~/Files/CoursePictures/{course.Picture}";
            //ToDo :: Remove Course Picture from model and the files from the system + database then remove this function
            return CourseBackground(courseId);
        }
        
        public string CourseBackground(string courseId)
        {
            var course = _courseService.GetCourse(courseId);
            if (course == null)
                return "";
            return string.IsNullOrEmpty(course.Background) ? "~/Images/DefaultImages/DefaultCourseBackground.jpg" : $"~/Files/CourseBackgrounds/{course.Background}";
        }
        
        public string FullName(ApplicationUser user)
        {
            return user.ShowFullName ? user.FirstName + " " + user.LastName : user.ProfileUserName;
        }
        
        public string FullName(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return "";
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            return user == null ? "" : FullName(user);
        }

        public string AdminDashFullName(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            return user == null ? "" : $"{user.FirstName}-{user.LastName}";
        }
        public string AdminDashFullName(ApplicationUser user)
        {
            return user == null ? "" : $"{user.FirstName}-{user.LastName}";
        }
        
        public string AdminFullName(ApplicationUser user)
        {
            return user == null ? "" : $"{user.FirstName} {user.LastName}";
        }

        public string ScreenName(ClaimsPrincipal User)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
                return "";

            var firstName = user.FirstName;
            var lastName = user.LastName;

            var lastScreenName = lastName.ToCharArray();

            if (lastScreenName.Length < 3)
                lastName = "ZZZZ";

            return $"{firstName} {lastName[0]}{lastName[1]}{lastName[2]}";

        }

        public string GetDiscordLink()
        {
            var link = _context.DiscordLink.SingleOrDefault();

            return link == null ? "" : link.Path;
        }



        public bool IsDeviceNew(string userId, string authCookies, string ip)
        {
            //ToDo :: Make this function more effective to determine whether if the device is new / Generalize this function / Eventually send admin notification that there is an abuse of using account be several people here
            var userDevices = _context.UserDevices.Where(x => x.UserId == userId).ToList();
            
            if (userDevices.Any(x => x.AuthCookies == authCookies) || userDevices.Any(x => x.Ip == ip))
                return false;
            
            return true;
        }

        public int GetDeviceGroupNumber(string userId, string authCookies, string ip)
        {
            
            var userDevices = _context.UserDevices.Where(x => x.UserId == userId).ToList();
            var maxGroupNumber = 0;
            
            if (userDevices.Any()){
               
                maxGroupNumber = userDevices.Max(x => x.GroupNumber);
            }
            else
                return 1;

            foreach (var device in userDevices)
            {
                if (device.AuthCookies == authCookies || device.Ip == ip)
                {
                    return device.GroupNumber;
                }

            }
            


            


            maxGroupNumber += 1;
            return maxGroupNumber;
        }


        public Address GetAddress(ApplicationUser user)
        {
            return _context.Addresses.SingleOrDefault(x => x.UserId == user.Id);
        }




        public SelectList GetCountries()
        {
            var countriesFilePath = Path.Combine(_env.ContentRootPath,"wwwroot", "js", "Countries", "CountriesList.json");
            var JSON = System.IO.File.ReadAllText(countriesFilePath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            var countries = new List<Country>();

            foreach (var country in jsonObj)
            {
                string tempName = country["name"].ToString();
                if (tempName.Split(",").Length > 0)
                    tempName = tempName.Split(",")[0];
                
                countries.Add(new Country(){Name = tempName, IsoCode = country["isoCode"], DialCode = country["dialCode"]});
            }
            
            return 
                new SelectList(from country in countries select new {country.Name, country.DialCode, country.IsoCode, View= $"{country.Name} ({country.DialCode})"},
                    "DialCode", "View", "+47"); 
        }
        
        

//        public int[] GetCourseRating(string courseId)
//        {
//            if (_courseService.GetCourse(courseId) == null)
//                return new[] {0,0};
//            var rating = _context.Ratings.Where(x=>x.CourseId == courseId); //ToDo :: Maybe I have to include the course
//            return rating.Any() ? new[] {rating.Count(), (int) rating.Average(x => x.Rating)} : new[] {rating.Count(), 0};
//        }
//        
//        public int GetUserRating(string courseId, ClaimsPrincipal user)
//        {
//            if (!user.Identity.IsAuthenticated)
//                return 0;
//            var userId= _userManager.GetUserId(user);
//            var rating = _context.Ratings.Include(x => x.User).SingleOrDefault(x=>x.UserId == userId);
//            return rating?.Rating ?? 0;
//        }
    }
}