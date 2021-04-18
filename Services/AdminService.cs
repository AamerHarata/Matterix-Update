using System.Collections.Generic;
using System.Linq;
using Matterix.Data;
using Matterix.Models;
using Microsoft.EntityFrameworkCore;


namespace Matterix.Services
{
    public class AdminService
    {
        //ToDo :: Only Admins Can Access Here
        
        private readonly ApplicationDbContext _context;
        private readonly PaymentService _payment;

        public AdminService(ApplicationDbContext context, PaymentService payment)
        {
            _context = context;
            _payment = payment;

        }
        public int DifferentDevices(string userId)
        {
            return _context.UserDevices.Where(x=>x.UserId == userId).Count(x => x.New);

        }

        public int NotPaidAmount(string userId)
        {
            
            var notPaidInvoices = _context.Invoices.ToList().Where(x => x.UserId == userId)
                .Where(x => x.ActiveInvoice()).ToList();

            var notPaid = 0;
            foreach (var inv in notPaidInvoices)
                notPaid += (int) inv.CurrentAmount;
            
            return notPaid;
        }
        
        public int LateAmount(string userId)
        {
            var lateInvoices = _context.Invoices.Where(x => x.UserId == userId)
                .Where(x => x.IsLate()).ToList();

            var late = 0;
            foreach (var inv in lateInvoices)
                late += (int) inv.CurrentAmount;
            
            return late;
        }
        
        
        public int TotalPaidAmount(string userId)
        {
            var sum= _context.Payments.Where(x => x.UserId == userId).Where(x=>!x.Refunded).Sum(x => x.Amount);
            return (int) sum;

        }

        public int CourseTakenCount(string userId)
        {
            return _context.Registrations.Where(x=> !x.Canceled).Count(x => x.StudentId == userId);
        }

        public double UserRatingAverage(string userId)
        {
            if (!_context.Ratings.Any(x => x.UserId == userId))
                return 0;
            return _context.Ratings.Where(x => x.UserId == userId).Average(x=>x.Rating);
        }

        public int UserFeedbackCount(string userId)
        {
            return _context.CourseFeedback.Count(x => x.UserId == userId);
        }

        public Address GetUserAddress(string userId)
        {
            var address = _context.Addresses.SingleOrDefault(x => x.UserId == userId);
            return address;
        }
    }
}