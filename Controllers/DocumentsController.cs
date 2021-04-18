using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.Objects;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Matterix.Controllers
{
    public class DocumentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly PdfService _pdf;
        private readonly UserManager<ApplicationUser> _user;
        private readonly AccessService _access;

        public DocumentsController(ApplicationDbContext context, PdfService pdf, UserManager<ApplicationUser> user, AccessService access)
        {
            _context = context;
            _pdf = pdf;
            _user = user;
            _access = access;
        }


        public FileResult MatterixPlusRegistrationsConfirmation(string applicationId)
        {
            var application = _context.PlusApplications.Find(applicationId);
            if (application == null)
                return null;

            var courseIds = application.CoursesIds.Split(",").ToList();

            return RegistrationsConfirmation(courseIds, application.StudentId);
        }
        

        

        [Authorize]
        public FileResult RegistrationsConfirmation(List<string> courseIds, string studentId = "")
        {
            if(string.IsNullOrEmpty(studentId))
                studentId = _user.GetUserId(User);
            if (courseIds.Count == 0)
            {
                courseIds.AddRange(_context.Registrations.ToList()
                    .Where(x => x.StudentId == studentId)
                    .Where(x => x.IsActive()).Select(x => x.CourseId));
            }
            
            
            return _pdf.RegistrationsConfirmationPdfFile(courseIds, studentId);
        }

        public FileResult AboutSchool()
        {
            return _pdf.GetMatterixApplicationFile("", EnumList.MatterixPlusRegDocument.AboutSchool);
        }


        [Authorize(Policy = "Admin")]
        public FileResult CourseDescriptionNoApplication(string courseIds)
        {
            var coursesIds = courseIds.Split(",").ToList();
            
            return _pdf.GetCourseDescriptionWithNoApplicationFile(coursesIds);
        }
        
        
        
        
        
        
        
        
    }
}