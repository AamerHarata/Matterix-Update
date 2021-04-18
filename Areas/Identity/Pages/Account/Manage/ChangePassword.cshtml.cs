using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace Matterix.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly InformationService _info;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger,
            ApplicationDbContext context,
            InformationService info)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _info = info;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword")]
            public string ConfirmPassword { get; set; }
            
            
            public string Ip { get; set; }
            public EnumList.DeviceType DeviceType { get; set; }
            public EnumList.OperatingSystem OperatingSystem { get; set; }
            public string AuthCookies { get; set; } 
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

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

            if (Input.OldPassword != user.CurrentPassword)
            {
                ModelState.AddModelError("wrongOldPassword", "{{$t('message.wrongPassword')}}");
                return Page();
            }

            if (Input.NewPassword != Input.ConfirmPassword)
            {
                ModelState.AddModelError("noMatch", "{{$t('message.passwordDoesNotMatch')}}");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                ModelState.AddModelError("error", "{{$t('message.errorRefresh')}}");
                return Page();
            }
            
            
            //Add used password and activity
            var usedPassword = new UsedPassword()
            {
                User = user, Password = Input.NewPassword, PlaceCreated = "Change Password"
            };

            _context.Add(usedPassword);
            _context.SaveChanges();
            
            var isNew = _info.IsDeviceNew(user.Id, Input.AuthCookies, Input.Ip);
            var groupNumber = _info.GetDeviceGroupNumber(user.Id, Input.AuthCookies, Input.Ip);
            
            var usedDevice = new UserDevice()
            {
                Activity = EnumList.Activity.PasswordChange, User = user, AuthCookies = Input.AuthCookies, DeviceType = Input.DeviceType, OperatingSystem = Input.OperatingSystem, Ip = Input.Ip,
                New = isNew, GroupNumber = groupNumber
            };

            _context.Add(usedDevice);
            _context.SaveChanges();

            user.CurrentPassword = Input.NewPassword;
            _context.Update(user);
            _context.SaveChanges();
            
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "{{$t('message.passwordChanged')}}";

            return RedirectToPage();
        }
    }
}
