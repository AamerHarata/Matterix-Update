using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Matterix.Data;
using Microsoft.AspNetCore.Authorization;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matterix.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly InformationService _info;

        public ResetPasswordModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context, InformationService info)
        {
            _userManager = userManager;
            _context = context;
            _info = info;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }


            public string Ip { get; set; }
            public EnumList.OperatingSystem OperatingSystem { get; set; }
            public EnumList.DeviceType DeviceType { get; set; }
            public string AuthCookies { get; set; }
        }

        public IActionResult OnGet(string email, string code = null)
        {
            if (code == null || string.IsNullOrEmpty(email))
            {
                return BadRequest("A code and email must be supplied for password reset.");
            }
            else
            {
                Input = new InputModel
                {
                    Code = code,
                    Email = email
                };
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
            if (result.Succeeded)
            {
                
                
                //Add used password and activity
                var usedPassword = new UsedPassword()
                {
                    User = user, Password = Input.Password, PlaceCreated = "Reset Password"
                };

                _context.Add(usedPassword);
                await _context.SaveChangesAsync();

                var isNew = _info.IsDeviceNew(user.Id, Input.AuthCookies, Input.Ip);
                var groupNumber = _info.GetDeviceGroupNumber(user.Id, Input.AuthCookies, Input.Ip);
            
                var usedDevice = new UserDevice()
                {
                    Activity = EnumList.Activity.PasswordChange, User = user, AuthCookies = Input.AuthCookies, DeviceType = Input.DeviceType, OperatingSystem = Input.OperatingSystem, Ip = Input.Ip,
                    New = isNew, GroupNumber = groupNumber
                };

                _context.Add(usedDevice);
                await _context.SaveChangesAsync();
                
                user.CurrentPassword = Input.Password;
                _context.Update(user);
                await _context.SaveChangesAsync();
                
                return new EmptyResult();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return new NotFoundResult();
        }
    }
}
