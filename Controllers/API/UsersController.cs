using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using System.Security.Claims;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Matterix.Areas.Identity.Pages.Account;

namespace Matterix.Controllers.API
{

    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;

        public UsersController(UserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var allUsers = _context.Users.ToList();
            return allUsers;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] ApplicationUser user)
        {
            var userLogin = await _userService.AuthenticateAsync(user.UserName, user.PasswordHash);

            if (userLogin == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName

            });



        }
    }
}
 

