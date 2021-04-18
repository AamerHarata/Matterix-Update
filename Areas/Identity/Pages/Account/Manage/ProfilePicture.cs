using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Matterix.Areas.Identity.Pages.Account.Manage
{
    public partial class ProfilePictureModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostEnv;


        public ProfilePictureModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IHostingEnvironment hostEnv)
        {
            _userManager = userManager;
            _context = context;
            _hostEnv = hostEnv;
        }

        public string PicturePath { get; set; }
        public IFormFile PictureFile { get; set; }
        public ApplicationUser CurrentUser { get; set; }

        public IActionResult OnGetAsync()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile pictureFile)
        {
            if (!User.Identity.IsAuthenticated)
                return NotFound("You are not logged in!");

            if (pictureFile == null || pictureFile.Length == 0)
            {
                ModelState.AddModelError("picError", "{{$t('message.noFileSelected')}}");
                return Page();

            }
            
            if (pictureFile.Length > 25 * 1024 * 1024){
                ModelState.AddModelError("picError", "{{$t('message.largeFileMax25')}}");
                return Page();
                
            }

            var user = _userManager.GetUserAsync(User).Result;
            var random = Guid.NewGuid().ToString();

            
            var randomSegments = random.Split("-");
            var fileName="";

            if (pictureFile.FileName.Length > 150)
            {
                var partOfName = pictureFile.FileName.Substring(Math.Max(0, pictureFile.FileName.Length - 50));
                fileName = randomSegments[0] + randomSegments[1]+partOfName;

            }
            else
            {
                fileName = randomSegments[0] + randomSegments[1] + pictureFile.FileName;
            }
            
            var acceptedFiles = new List<string>(){"image/png", "image/jpeg", "image/jpeg"};

            if (!acceptedFiles.Contains(pictureFile.ContentType)){
                ModelState.AddModelError("picError", "{{$t('message.allowedPicFiles')}}");
                return Page();
            }
            
            var envRoot = _hostEnv.ContentRootPath;
            var root = "wwwroot";
            const string fileFolder = "Files";
            const string profilePictures = "ProfilePictures";
            
            var pictureTargetPath = Path.Combine(envRoot, root, fileFolder, profilePictures, fileName);
            
            Console.WriteLine($"ENV ROOT IS: {envRoot}");

            var oldPicturePath = "none";
            if (!string.IsNullOrEmpty(user.ProfilePicture))
                oldPicturePath = Path.Combine(envRoot, root, fileFolder, profilePictures, user.ProfilePicture);
            
            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            
            if (Directory.GetDirectories(envRoot+"/"+root+"/"+ fileFolder, profilePictures).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+profilePictures));
            
            
            if (Directory.GetFiles(envRoot+"/" + root + "/" + fileFolder + "/" + profilePictures, fileName).Length !=
                0)
                return BadRequest("Files Exists"); //ToDo :: a file with the same name exists, replace it and delete the old
            
            
            try
            {
                using (var stream = new FileStream(pictureTargetPath, FileMode.Create))
                {
                    Console.WriteLine($"PICTURE TARGET PATH IS: {pictureTargetPath}");
                    await pictureFile.CopyToAsync(stream);
                }

                if (oldPicturePath != "none")
                {
                    try
                    {
                        System.IO.File.Delete(oldPicturePath);
                    }
                    catch
                    {
                        ModelState.AddModelError("picError", "{{$t('message.errorHappened')}}");
                        return Page();
                    }
                }

                
                user.ProfilePicture = fileName;
                
                _context.Update(user);
                _context.SaveChanges();
                
                return RedirectToPage();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("picError", "{{$t('message.errorHappened')}}");
                return Page();
            }
            
            
            
            
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var user = await  _userManager.GetUserAsync(User);

            var picToDelete = user.ProfilePicture;
            if (picToDelete == "" || !User.Identity.IsAuthenticated)
                return NotFound();

            user.ProfilePicture ="";
            
            var envRoot = _hostEnv.ContentRootPath;
            var root = "wwwroot";
            const string fileFolder = "Files";
            const string profilePictures = "ProfilePictures";
            
            var picToDeletePath = Path.Combine(envRoot, root, fileFolder, profilePictures, picToDelete);

            try
            {
                System.IO.File.Delete(picToDeletePath);
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToPage();

            }
            catch
            {
                ModelState.AddModelError("picError", "{{$t('message.errorHappened')}}");
                return RedirectToPage();
            }
            
        }


    }
}
