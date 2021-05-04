using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Matterix.Data;
using Microsoft.AspNetCore.Authorization;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Matterix.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly EmailService _email;
        private readonly ApplicationDbContext _context;
        private readonly InformationService _information;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext context,
            EmailService email,
            InformationService information
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _email = email;
            _context = context;
            _information = information;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            
            [Required]
            [Display(Name = "First Name")]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters are not allowed.")]
            public string FirstName { get; set; }
            
            [Display(Name = "Middle Name")]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters are not allowed.")]
            public string MiddleName { get; set; }
            
            [Required]
            [Display(Name = "Last Name")]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters are not allowed.")]
            public string LastName { get; set; }
            
            [Required]
            [Display(Name = "Gender")]
            public EnumList.Gender Gender { get; set; }
            
//            [Required]
//            [Display(Name ="Birth Date")]
//            [DataType(DataType.Date)]
//            public DateTime BirthDate { get; set; }

            [Required]
            public int Day { get; set; }
            [Required]
            public int Month { get; set; }
            [Required]
            public int Year { get; set; }
            
            [Required]
            [Display(Name = "Language")]
            public EnumList.Language Language { get; set; }
            
            [Required]
            [Phone]
            [Display(Name = "Phone Number")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
            
            [Required]
            public string PhoneCode { get; set; }
            
            
            [Required(ErrorMessage = "The Address is required")]
            [Display(Name = "Address")]
            public string Address { get; set; }
            
            [Required(ErrorMessage = "The Zipcode is required")]
            [DataType(DataType.PostalCode)]
            [Display(Name = "Zipcode")]
            public string ZipCode { get; set; }
            
            [Required(ErrorMessage = "The City is required")]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required(ErrorMessage = "The Country is required")]
            [Display(Name = "Country")]
            public string Country { get; set; }

            public string Ip { get; set; }
            public EnumList.DeviceType DeviceType { get; set; }
            public EnumList.OperatingSystem OperatingSystem { get; set; }
            public string AuthCookies { get; set; } 
        }

        public IActionResult OnGetAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if(User.Identity.IsAuthenticated)
                return LocalRedirect(returnUrl);
            
//            var countriesFilePath = Path.Combine(_env.ContentRootPath,"wwwroot", "js", "Countries", "CountriesList.json");
//            var JSON = System.IO.File.ReadAllText(countriesFilePath);
//            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
//            var countries = new List<Country>();
//
//            foreach (var country in jsonObj)
//            {
//                string tempName = country["name"].ToString();
//                if (tempName.Split(",").Length > 0)
//                    tempName = tempName.Split(",")[0];
//                
//                countries.Add(new Country(){Name = tempName, IsoCode = country["isoCode"], DialCode = country["dialCode"]});
//            }
            
//            ViewData["countries"] =
//                new SelectList(from country in countries select new {country.Name, country.DialCode, country.IsoCode, View= $"{country.Name} ({country.DialCode})"},
//                    "DialCode", "View", "+47"); 
            ViewData["countries"] = _information.GetCountries();
            
            ReturnUrl = returnUrl;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ViewData["emailNameValidation"] = "";
            
            if (_context.Users.ToList().Any(x => string.Equals(x.FirstName.Replace(" ", ""), Input.FirstName.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase) && string.Equals(x.LastName.Replace(" ", ""), Input.LastName.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase)))
            {
                ViewData["emailNameValidation"] =
                    "nameIsTaken";
                return Page();
            }
            

            if (_context.Users.ToList().Any(x => string.Equals(x.Email, Input.Email, StringComparison.CurrentCultureIgnoreCase)))
            {
                ViewData["emailNameValidation"] =
                    "emailIsTaken";
                return Page();
            }

            
            if (ModelState.IsValid)
            {
                var firstName = UpperFirstChar(Input.FirstName);
                var lastName = UpperFirstChar(Input.LastName);
                var middleName = UpperFirstChar(Input.MiddleName);
                var street = UpperFirstChar(Input.Address);
                var city = UpperFirstChar(Input.City);
                var country = UpperFirstChar(Input.Country);

                var profileUserName = $"{firstName}.{lastName}{Input.Year}";
                profileUserName = profileUserName.Replace(" ", "");
                var user = new ApplicationUser { 
                    UserName = Input.Email.Trim(), Email = Input.Email.Trim() , FirstName = firstName, MiddleName = middleName, LastName = lastName,
                    Language = Input.Language , BirthDate = new DateTime(Input.Year, Input.Month, Input.Day), Gender = Input.Gender, PhoneNumber = Input.PhoneNumber, PhoneCode = Input.PhoneCode, Role = EnumList.Role.Student,
                    ProfileUserName = profileUserName, CurrentPassword = Input.Password, 
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    
                    var usedPassword = new UsedPassword(){User = user, Password = Input.Password, PlaceCreated = "Register Account"};
                    _context.Add(usedPassword);
                    await _context.SaveChangesAsync();
                    
                    var address = new Address()
                    {
                        Street = street, ZipCode = Input.ZipCode, City = city, User = user, UserId = user.Id
                        ,Country=Input.Country
                    };
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    
                    var device = new UserDevice()
                    {
                        Activity = EnumList.Activity.AccountRegister, Ip = Input.Ip, OperatingSystem = Input.OperatingSystem, DeviceType = Input.DeviceType, AuthCookies = Input.AuthCookies, User = user, New = true, GroupNumber = 1
                    };
                    _context.Add(device);
                    await _context.SaveChangesAsync();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);
                    
                    await _email.RegisterGreetingEmail(user.Id, callbackUrl);
//                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
//                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        
        
        private static string UpperFirstChar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "";
            var tokens = name.Trim().ToLower().Split(" ");
            name = "";
            
            foreach(var token in tokens)
                name+= $"{char.ToUpper(token.First()) + token.Substring(1).ToLower()} ";

            name = name.Trim();

            return name;
        }
    }
}
