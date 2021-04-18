using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Areas.Identity.Pages.Account.Manage
{
    public class AccountActivity : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountActivity(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public List<UserDevice> Devices { get; set; }
            public string userId { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
                return NotFound();
            Input = new InputModel
            {
                Devices = await _context.UserDevices.Include(x => x.User).Where(x=>x.UserId == user.Id).OrderByDescending(x=>x.DateTime).ToListAsync(),
                userId =  user.Id
                
            };
            
            return Page();
        }
    }
}