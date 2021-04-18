using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Microsoft.AspNetCore.Authorization;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Matterix.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly InformationService _info;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, ApplicationDbContext context, InformationService info)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _info = info;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

//            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; } = true;
            
            public string Ip { get; set; }
            public EnumList.DeviceType DeviceType { get; set; }
            public EnumList.OperatingSystem OperatingSystem { get; set; }
            public string AuthCookies { get; set; } 
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            Input = new InputModel {RememberMe = true};
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            
            if(User.Identity != null && User.Identity.IsAuthenticated)
                return LocalRedirect(returnUrl);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {

                    var userId = "";
                    var user = _context.Users.ToList().SingleOrDefault(x => string.Equals(x.UserName , Input.Email, StringComparison.CurrentCultureIgnoreCase));

                    if (user != null)
                        userId = user.Id;
                    
                    
                    
                    
                    if(user!=null && user.Blocked)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Blocked", "Home", new {userId = user.Id});
                    }

                    var isNew = _info.IsDeviceNew(userId, Input.AuthCookies, Input.Ip);
                    var groupNumber = _info.GetDeviceGroupNumber(userId, Input.AuthCookies, Input.Ip);

                    Console.WriteLine(user != null
                        ? $"User logged: {user.FirstName} {user.LastName}, IP: {Input.Ip} -------------------------------------"
                        : $"User logged: is null, IP: {Input.Ip} -------------------------------------");

                    var device = new UserDevice()
                    {
                        Activity = EnumList.Activity.LoginActivity, Ip = Input.Ip, OperatingSystem = Input.OperatingSystem, DeviceType = Input.DeviceType, AuthCookies = Input.AuthCookies, User = user,
                        New = isNew, GroupNumber = groupNumber
                        
                    };
                    
                    _context.Add(device);
                    await _context.SaveChangesAsync();
                    
                    
                    
                    
                    
                    
                    
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError("wrongPassword", "{{$t('message.wrongPassword')}}");
                    Console.WriteLine($"User:{Input.Email}. With wrong password: ({Input.Password}) -------------------------------------");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("wrongPassword", "{{$t('message.errorRefresh')}}");
            return Page();
        }
    }
}
