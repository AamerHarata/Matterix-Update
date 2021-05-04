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
using Matterix.Areas.Identity.Pages.Account;

namespace Matterix.Services
{
 
    public class UserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EmailService _email;
        private readonly ApplicationDbContext _context;
        private readonly InformationService _information;
        private readonly ILogger<LoginModel> _logger;
        

        public UserService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext context,
        EmailService email,
        InformationService information,
        ILogger<LoginModel> logger
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _email = email;
            _context = context;
            _information = information;
            _logger = logger;
        }

        // need to check
        public async Task<ApplicationUser> AuthenticateAsync(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            // check if username exists
            if (user == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(username, password,true, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return  user;
            }
            return null;
        }
       
        public ApplicationUser Create(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser user, string password = null)
        {
            throw new NotImplementedException();
        }
     
    }
}
