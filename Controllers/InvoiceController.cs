using System.Linq;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.ViewModel;
using Matterix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Controllers
{
    public class InvoiceController : Controller
    {

        private readonly PaymentService _payment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CourseService _courseService;
        private readonly PdfService _pdf;


        public InvoiceController(PaymentService payment, ApplicationDbContext context, UserManager<ApplicationUser> userManager, CourseService courseService, PdfService pdf)
        {
            _payment = payment;
            _context = context;
            _userManager = userManager;
            _courseService = courseService;
            _pdf = pdf;
        }

        

        



        [Route("/Invoice/{invoiceNumber}")]
        [Authorize]
        public IActionResult Index(int invoiceNumber)
        {
            var invoice = _payment.GetInvoice(invoiceNumber);
            
            if (invoice == null)
                return RedirectToAction("Error", "Home");
            
            var user = _context.Users.Find(invoice.UserId);
            if(user == null)
                return RedirectToAction("Error", "Home");


            if (!User.HasClaim("Role", "Admin"))
                if(user.Id != invoice.UserId)
                    return RedirectToAction("Error", "Home");

            if (invoice.Paid)
                return RedirectToAction("Receipt", new{invoiceNumber = invoiceNumber});

            var course = _courseService.GetCourse(invoice.CourseId) ?? new Course();

            var increments = _payment.GetIncrementsList(invoiceNumber);

            var fullAmount = invoice.CurrentAmount;

            var address = _context.Addresses.SingleOrDefault(x => x.UserId == user.Id);

            var registration = _context.Registrations.Where(x => x.StudentId == user.Id)
                .SingleOrDefault(x => x.CourseId == course.Id);

            var payments = _context.Invoices.Where(x => x.UserId == user.Id).Where(x => x.CourseId == course.Id)
                .Where(x => x.Paid).ToList();

            
            
            

            var vm = new InvoiceViewModel
            {
                Course = course, User = user, Increments = increments, FullAmount = fullAmount, 
                Address = address, Invoice = invoice, Registration = registration, Payments = payments.Sum(x=>x.Amount),
                DueDate = invoice.CurrentDueDate, Deadline = invoice.CurrentDeadline
            };


            if (!increments.Any()) return View(vm);
            {
                var maxDate = increments.OrderByDescending(x => x.NewDueDate).Take(1).SingleOrDefault();

                if (maxDate == null) return View(vm);
                vm.DueDate = maxDate.NewDueDate;
                vm.Deadline = maxDate.NewDeadline;
            }
            
            
            

            return View(vm);
        }



        [Route("/Receipt/{invoiceNumber}")]
        [Authorize]
        public IActionResult Receipt(int invoiceNumber)
        {
            var invoice = _payment.GetInvoice(invoiceNumber);
            
            if (invoice == null)
                return RedirectToAction("Error", "Home");
            
            var user = _context.Users.Find(invoice.UserId);
            if(user == null)
                return RedirectToAction("Error", "Home");
            
            
            
            if (!User.HasClaim("Role", "Admin"))
                if(user.Id != invoice.UserId)
                    return RedirectToAction("Error", "Home");
            
            
            if (!invoice.Paid)
                return RedirectToAction("Index", new{invoiceNumber = invoiceNumber});

            var course = _courseService.GetCourse(invoice.CourseId) ?? new Course();

            var increments = _payment.GetIncrementsList(invoiceNumber);

            var fullAmount = invoice.CurrentAmount;

            var address = _context.Addresses.SingleOrDefault(x => x.UserId == user.Id);

            var registration = _context.Registrations.Where(x => x.StudentId == user.Id)
                .SingleOrDefault(x => x.CourseId == course.Id);

            var payments = _context.Invoices.Where(x => x.UserId == user.Id).Where(x => x.CourseId == course.Id)
                .Where(x => x.Paid).ToList();

            
            
            

            var vm = new InvoiceViewModel
            {
                Course = course, User = user, Increments = increments, FullAmount = fullAmount, 
                Address = address, Invoice = invoice, Registration = registration, Payments = payments.Sum(x=>x.Amount),
                DueDate = invoice.CurrentDueDate, Deadline = invoice.CurrentDeadline
            };


            if (!increments.Any()) return View(vm);
            {
                var maxDate = increments.OrderByDescending(x => x.NewDueDate).Take(1).SingleOrDefault();

                if (maxDate == null) return View(vm);
                vm.DueDate = maxDate.NewDueDate;
                vm.Deadline = maxDate.NewDeadline;
            }
            
            
            



            return View(vm);

        }

        [Authorize]
        [Route("/Invoice/History")]
        public IActionResult History()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Error", "Home");
            
            var invoices = _context.Invoices.Include(x=>x.Course).Where(x => x.UserId == userId);
            return View(invoices);
        }

        [Authorize]
        [Route("/Invoice/DownloadInvoice")]
        public IActionResult DownloadInvoice(int invoiceNumber)
        {
            //ToDo :: Need more security to check if the authorized user is the owner of this invoice. (for now it is pretty fine)
            var pdfFile = _pdf.GetInvoicePdfFile(invoiceNumber);
            if (pdfFile != null)
                return pdfFile;
            return RedirectToAction("Error", "Home");
        }
        
        
        
    }
}