using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
//using FluentEmail.Core;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace Matterix.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _email;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService email,
            ApplicationDbContext context,
            IWebHostEnvironment env,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _email = email;
            _context = context;
            _env = env;
            _config = config;
        }

//        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "User Name")]
            
            [RegularExpression(@"^[a-zA-Z0-9]{1,20}[.-]{0,1}[a-zA-Z0-9]{1,20}$", 
                ErrorMessage = "Characters are not allowed.")]
//            [RegularExpression(@"^[a-zA-Z''-']{1,10}[a-zA-Z.\-]{1}[a-zA-Z]{1,10}[a-zA-Z0-9]{1,4}$", 
//                ErrorMessage = "Username should start with letters, can contain one '.' or '-' and 4 numbers at the end.\nExample: Firstname.lastname9999")]

            public string UserName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Required(ErrorMessage = "The phone is required")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string PhoneCode { get; set; }
            
            [Required]
            [MinLength(3)]
            [Display(Name = "First Name")]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters or numbers are not allowed.")]
            public string FirstName { get; set; }
            
            [Display(Name = "Middle Name")]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters or numbers are not allowed.")]
            public string MiddleName { get; set; }
            
            [Required]
            [Display(Name = "Last Name")]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-ZÅåØøÆæ\s]{1,40}$", 
                ErrorMessage = "Characters or numbers are not allowed.")]
            public string LastName { get; set; }
            
            
            [Required]
            [Display(Name ="Birth Date")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
            
            [Required]
            [Display(Name = "Language")]
            public EnumList.Language Language { get; set; }
            
            [Required]
            [Display(Name = "Gender")]
            public EnumList.Gender Gender { get; set; }
            
            
            [Required(ErrorMessage = "The Address is required")]
            public string Address { get; set; }
            
            [Required(ErrorMessage = "The Zipcode is required")]
            [DataType(DataType.PostalCode)]
            public string ZipCode { get; set; }
            
            [Required(ErrorMessage = "The City is required")]
            public string City { get; set; }
            
            [Display(Name = "Login Username")]
            public string LoginUserName { get; set; }
            [Required(ErrorMessage = "The Country is required")]
            public string Country { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            
            var user = await _userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ViewData["countries"] = new List<string>();
            if (!user.PhoneNumberConfirmed)
            {
                var countriesFilePath = Path.Combine(_env.ContentRootPath,"wwwroot", "js", "Countries", "CountriesList.json");
                var JSON = await System.IO.File.ReadAllTextAsync(countriesFilePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
                var countries = new List<Country>();

                if (jsonObj != null)
                    foreach (var country in jsonObj)
                    {
                        string tempName = country["name"].ToString();
                        if (tempName.Split(",").Length > 0)
                            tempName = tempName.Split(",")[0];

                        countries.Add(new Country()
                            {Name = tempName, IsoCode = country["isoCode"], DialCode = country["dialCode"]});
                    }

                ViewData["countries"] =
                    new SelectList(from country in countries select new {country.Name, country.DialCode, country.IsoCode, View= $"{country.Name} ({country.DialCode})"},
                        "DialCode", "View", "+47"); 
            }
            
            
            
            var address = await _context.Addresses.Include(x => x.User).Where(x => x.UserId == user.Id).SingleAsync();
            

//            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            
            Input = new InputModel
            {
                UserName = user.ProfileUserName,
                Email = email,
                PhoneNumber = phoneNumber,
                Gender = user.Gender,
                Language = user.Language,
                BirthDate = user.BirthDate,
                Address = address.Street,
                ZipCode = address.ZipCode,
                City = address.City,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                LoginUserName = user.UserName,
                PhoneCode = user.PhoneCode,
                Country=address.Country
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            IsPhoneConfirmed = user.PhoneNumberConfirmed;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (_context.Users.ToList().Where(x=>x.Id != user.Id).Any(x => string.Equals(x.FirstName.Replace(" ", ""), Input.FirstName.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase) && string.Equals(x.LastName.Replace(" ", ""), Input.LastName.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase)))
            {
                ModelState.AddModelError("nameTaken", "{{$t('message.nameIsTaken')}}");
                return Page();
            }
            
            
            

            if (_context.Users.ToList().Where(x=>x.Id != user.Id).Any(x => string.Equals(x.ProfileUserName, Input.UserName, StringComparison.CurrentCultureIgnoreCase)))
            {
                ModelState.AddModelError("usernameTaken", "{{$t('message.usernameIsTaken')}}");
                return Page();
            }

            if (_context.Users.ToList().Where(x => x.Email != user.Email).Any(x =>
                string.Equals(x.Email, Input.Email, StringComparison.CurrentCultureIgnoreCase)))
            {
                ModelState.AddModelError("emailTaken", "{{$t('message.emailIsTaken')}}");
                return Page();
            }

            var address = await _context.Addresses.Include(x => x.User)
                              .Where(x => x.UserId == user.Id).SingleAsync();

            var email = await _userManager.GetEmailAsync(user);
            if (!user.EmailConfirmed && Input.Email != email)
            {
                var setUsernameResult = await _userManager.SetUserNameAsync(user, Input.Email);
                if (!setUsernameResult.Succeeded)
                {
//                    var userId = await _userManager.GetUserIdAsync(user);
//                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                    ViewData["uniqueEmail"] =
                        "This Email is already taken, please try a different one or contact us!";
                    return Page();
                }
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
            }

//            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
//            if (Input.PhoneNumber != phoneNumber)
//            {
//                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
//                if (!setPhoneResult.Succeeded)
//                {
//                    var userId = await _userManager.GetUserIdAsync(user);
//                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
//                }
//                else
//                {
//                    user.PhoneNumberConfirmed = false;
//                }
//            }

//            if (Input.BirthDate != user.BirthDate)
//                user.BirthDate = Input.BirthDate;
            
            if (Input.Language != user.Language)
                user.Language = Input.Language;
            
//            if (Input.FirstName != user.FirstName)
//                user.FirstName = Input.FirstName;
            
//            if (Input.LastName != user.LastName)
//                user.LastName = Input.LastName;
            
            if (string.IsNullOrEmpty(user.MiddleName) && Input.MiddleName != user.MiddleName)
                user.MiddleName = Input.MiddleName;
            
            if (Input.UserName != user.ProfileUserName)
                user.ProfileUserName = Input.UserName;

            if (Input.Gender != user.Gender)
                user.Gender = Input.Gender;
         

            if (address == null)
            {
                address = new Address()
                {
                    User = user, Street = Input.Address, City =  Input.City, ZipCode = Input.ZipCode
                };

                _context.Add(address);
                await _context.SaveChangesAsync();
            }

            if (!user.PhoneNumberConfirmed)
            {
                if (Input.PhoneNumber != user.PhoneNumber)
                    user.PhoneNumber = Input.PhoneNumber;
                
                if(Input.PhoneCode != user.PhoneCode)
                    user.PhoneCode = Input.PhoneCode;
            }
            
            
            
//            else
//            {
//                if (Input.Address != address.Street)
//                    address.Street = Input.Address;
//                if (Input.City != address.City)
//                    address.City = Input.City;
//                if (Input.ZipCode != address.ZipCode)
//                    address.ZipCode = Input.ZipCode;
//                
//                _context.Update(address);
//                await _context.SaveChangesAsync();
//                
//            }



            _context.Update(user);
            await _context.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "{{$t('message.profileUpdated')}}";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new {userId = userId, code = code },
                protocol: Request.Scheme);

            await _email.EmailVerificationEmail(userId, callbackUrl);

            StatusMessage = "{{$t('message.verificationSent')}}";
            return RedirectToPage();
        }
        
        //In this method the model is not valid because it is called from outside the related page (Home/Index)
        public async Task<IActionResult> OnPostSendVerificationEmailFromOutSideAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new {userId = userId, code = code },
                protocol: Request.Scheme);

            await _email.EmailVerificationEmail(userId, callbackUrl);

            StatusMessage = "{{$t('message.verificationSent')}}";
            return RedirectToPage();
        }
    }
}
