using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly EmailService _email;

        public PaymentService(ApplicationDbContext context, UserManager<ApplicationUser> user, EmailService email)
        {
            _context = context;
            _user = user;
            _email = email;
        }
        public List<MatterixInvoice> CreateOnRegisterInvoices(string courseId, ApplicationUser user)
        {
            var course = _context.Courses.Find(courseId);
            
            var firstPayment = (int) (course.Price / 3);
            var secondPayment = (int) ((course.Price - firstPayment) / 2);
            var thirdPayment = (int) course.Price - firstPayment - secondPayment;

            var totalInvoices = firstPayment + secondPayment+thirdPayment;
            if (totalInvoices != course.Price)
            {
                if (totalInvoices > course.Price)
                    thirdPayment -= (int) (totalInvoices - course.Price);
                if (totalInvoices < course.Price)
                    thirdPayment += (int) (totalInvoices - course.Price);
            }
            var invoices = new List<MatterixInvoice>()
            {
                new MatterixInvoice()
                {
                    Course = course, User = user, Amount = firstPayment, CurrentAmount = firstPayment, OriginalDueDate = Format.NorwayDateNow(), CurrentDueDate = Format.NorwayDateNow(), OriginalDeadline = Format.NorwayDateNow().AddDays(15), CurrentDeadline = Format.NorwayDateNow().AddDays(15),
                    Reason = EnumList.InvoiceReason.Registration,
                    ExtraDescription = course.Subject+ "- COURSE REGISTER - betalingen - 1",
                    NextNotification = Format.NorwayDateNow().AddHours(11), InvoiceType = EnumList.InvoiceType.Invoice
                    
                }, 
                new MatterixInvoice()
                {
                    Course = course, User = user, Amount = secondPayment , CurrentAmount = secondPayment,  OriginalDueDate = Format.NorwayDateNow().AddMonths(1), CurrentDueDate = Format.NorwayDateNow().AddMonths(1), OriginalDeadline = Format.NorwayDateNow().AddMonths(1).AddDays(15), CurrentDeadline = Format.NorwayDateNow().AddMonths(1).AddDays(15),
                    Reason = EnumList.InvoiceReason.MonthlyPayment,
                    ExtraDescription = course.Subject+ ", betalingen - 2",
                    NextNotification = Format.NorwayDateNow().AddMonths(1).AddHours(11), InvoiceType = EnumList.InvoiceType.Invoice
                }, 
                new MatterixInvoice()
                {
                    Course = course, User = user, Amount = thirdPayment , CurrentAmount = thirdPayment, OriginalDueDate = Format.NorwayDateNow().AddMonths(2), CurrentDueDate = Format.NorwayDateNow().AddMonths(2), OriginalDeadline = Format.NorwayDateNow().AddMonths(2).AddDays(15), CurrentDeadline = Format.NorwayDateNow().AddMonths(2).AddDays(15),
                    Reason = EnumList.InvoiceReason.MonthlyPayment,
                    ExtraDescription = course.Subject+ ", betalingen - 3",
                    NextNotification = Format.NorwayDateNow().AddMonths(2).AddHours(11), InvoiceType = EnumList.InvoiceType.Invoice
                }
            };


            return invoices;
        }


        public List<MatterixInvoice> GetActiveInvoices(string userId)
        {
            return _context.Invoices.ToList()
                .Where(x => x.UserId == userId)
                .Where(x=>x.ActiveInvoice())
                .OrderBy(x=>x.CurrentDueDate)
                .ToList();
        }

        public MatterixInvoice GetInvoice(int invoiceNumber)
        {
            //ToDo :: Does include really important here? If not, remove it.
            return _context.Invoices.Include(x => x.User)
                .Include(x => x.Course).SingleOrDefault(x => x.Number == invoiceNumber);
        }
        
        // public MatterixInvoice GetActiveInvoice(int invoiceNumber)
        // {
        //     return _context.Invoices.Include(x => x.User)
        //         .Include(x => x.Course).Where(x => x.Number == invoiceNumber).SingleOrDefault(x=>x.ActiveInvoice());
        // }

        
        public decimal InvoiceFullAmount(int invoiceNumber)
        {
            var invoice = GetInvoice(invoiceNumber);
            if (invoice == null)
                return 0;
            
            

            var increments = _context.Increments.Include(x => x.Invoice).Where(x => x.Invoice.Number == invoiceNumber).ToList();
            if (!increments.Any())
                return invoice.Amount;

            var amount = invoice.Amount;

            foreach (var increment in increments)
            {
                amount += increment.Amount;
            }

            return amount;
        }


//        public void Temp(int invoiceNumber, EnumList.IncrementReason reason, int delayDays)
//        {
//            var invoice = _context.Invoices.Find(invoiceNumber);
//            if(invoice == null || invoice.Paid)
//                return;
//            
//            
//            //Values will be modified according to the process down
//            var amount = (decimal) 70; //This variable is the increment amount, so for the invoice this must be added as sum not assign
//            
//            var type = EnumList.IncrementType.Fixed;
//            var phase = invoice.InvoiceType;
//            
//            //Increment object
//            var increment = new InvoiceIncrement
//            {
//                Invoice = invoice, Reason = reason,
//            };
//            
//
//            switch (reason)
//            {
//                case EnumList.IncrementReason.Discount:
//                    //Discount is not in used right now
//                    return;
//                case EnumList.IncrementReason.PaperInvoice:
//                    //Dates, phase and type must not be applied here (must keep the same)
//                    amount = 49; //Define paper cost as 49 kr
//                    delayDays = 0;
//                    break;
//                case EnumList.IncrementReason.Delay:
//                    //ToDo :: Review here if something is missing
//                    
//                    //The invoice dates and next notification has already updated up
//                    //Here is the only place where the delayDays will be used by the parameter value
//                    
//                    amount = 0; //Secure the amount to be 0
//                    break;
//                
//                case EnumList.IncrementReason.Latency:
//
//                    switch (invoice.InvoiceType)
//                    {
//                        case EnumList.InvoiceType.Other:
//                            //Not relevant case
//                            return;
//                        
//                        
//                        case EnumList.InvoiceType.Invoice:
//                            //This is the first latency, the invoice will be converted to purring
//                            phase = EnumList.InvoiceType.Purring;
//                            amount = 70; //This amount defined by the government of purring fees
//                            delayDays = 15;
//                            
//                            //ToDo :: Most of required fields are updated up -- Review if there is something missing
//
//                            
//                            break;
//                        case EnumList.InvoiceType.Purring:
//                            //This is second latency, the invoice will be converted to inkassovarsel
//
//                            phase = EnumList.InvoiceType.Inkassovarsel;
//                            amount = invoice.CurrentAmount * (decimal) 8.5 / 100;
//                            delayDays = 15;
//                            type = EnumList.IncrementType.Percent;
//                            
//                            //ToDo :: Send admin reminder to paper it
//                            //ToDo :: Most of required fields are updated up -- Review if there is something missing
//                            
//                            
//                            break;
//                        case EnumList.InvoiceType.Inkassovarsel:
//                            var oldInkassovarsel = _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber)
//                                .Where(x => x.InvoicePhase == EnumList.InvoiceType.Inkassovarsel);
//
//                            if (oldInkassovarsel.Count() <= 1)
//                            {
//                                phase = EnumList.InvoiceType.Inkassovarsel;
//                                amount = 0;
//                                delayDays = 15;
//                                //ToDo :: Send notification to user
//                            }
//                            else
//                            {
//                                phase = EnumList.InvoiceType.Inkasso;
//                                amount = 0;
//                                delayDays = 0;
//                                
//                                //ToDo :: Send notification to admin for inkasso company sending
//                                //ToDo :: Remove the next notification
//                            }
//                            
//                            break;
//                        case EnumList.InvoiceType.Inkasso:
//                            //This must not be reach because at the last phase we do remove the notification and sending to inkasso
//                            return;
//                        
//                        default:
//                            return;
//                    }
//                    
//                    
//                          
//                    
//                    break;
//                default:
//                    return;
//            }
//            
//            var newDualDate = invoice.CurrentDueDate.AddDays(delayDays);
//            var newDeadline = invoice.CurrentDeadline.AddDays(delayDays);
//            
//            //Update the dates and next notification here
//            invoice.CurrentDueDate = newDualDate;
//            invoice.CurrentDeadline = newDeadline;
//            invoice.NextNotification = invoice.NextNotification.AddDays(delayDays);
//            invoice.CurrentAmount += amount;
//            invoice.InvoiceType = phase;
//            
//            
//            //ToDo :: Update invoice which should has been got new values through the process over
//            increment.InvoicePhase = phase;
//            increment.Amount = amount;
//            increment.Type = type;
//
//
//
//            _context.Update(invoice);
//            _context.Add(increment);
//            _context.SaveChangesAsync(); //ToDo :: Do not forget await here in an async method
//            
//
//
//        }


        
        public async Task AddIncrement(int invoiceNumber, EnumList.IncrementReason reason = EnumList.IncrementReason.Latency, int delayDays = 0)
        {
            
            
            
            var invoice = _context.Invoices.Find(invoiceNumber);
            if(invoice == null || invoice.Paid)
                return;
            
            
            //Values will be modified according to the process down
            //ToDo :: According to the changes Norwegian low, the latency increment must be 35 not 70 plus 8.5% as interest rate.
            var amount = (decimal) 70; //This variable is the increment amount, so for the invoice this must be added as sum not assign
            var type = EnumList.IncrementType.Fixed;
            var phase = invoice.InvoiceType;
            var keepDue = false;
            var notifyAdmin = false;
//            var notifyUser = false;
            var notificationHours = 11;
            
            //Increment object
            var increment = new InvoiceIncrement
            {
                Invoice = invoice, Reason = reason,
            };
            

            switch (reason)
            {
                case EnumList.IncrementReason.Discount:
                    //Discount is not in used right now
                    return;
                case EnumList.IncrementReason.PaperInvoice:
                    //Dates, phase and type must not be applied here (must keep the same)
                    amount = 49; //Define paper cost as 49 kr
                    delayDays = 0;
                    break;
                case EnumList.IncrementReason.Delay:
                    //ToDo :: Review here if something is missing
                    
                    //The invoice dates and next notification has already updated up
                    //Here is the only place where the delayDays will be used by the parameter value
                    
                    amount = 0; //Secure the amount to be 0
                    break;
                
                case EnumList.IncrementReason.Latency:
//                    notifyUser = true;

                    switch (invoice.InvoiceType)
                    {
                        case EnumList.InvoiceType.Other:
                            //Not relevant case
                            return;
                        
                        
                        case EnumList.InvoiceType.Invoice:
                            //This is the first latency, the invoice will be converted to purring
                            phase = EnumList.InvoiceType.Purring;
                            amount = 70; //This amount defined by the government of purring fees
                            delayDays = 15;
                            
                            //ToDo :: Most of required fields are updated up -- Review if there is something missing

                            
                            break;
                        case EnumList.InvoiceType.Purring:
                            //This is second latency, the invoice will be converted to inkassovarsel

                            phase = EnumList.InvoiceType.Inkassovarsel;
                            amount = invoice.CurrentAmount * (decimal) 8.5 / 100;
                            delayDays = 15;
                            type = EnumList.IncrementType.Percent;

                            notifyAdmin = true;
                            //ToDo :: Most of required fields are updated up -- Review if there is something missing
                            
                            
                            break;
                        case EnumList.InvoiceType.Inkassovarsel:
                            var oldInkassovarsel = _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber)
                                .Where(x => x.InvoicePhase == EnumList.InvoiceType.Inkassovarsel);

                            if (oldInkassovarsel.Count() <= 1)
                            {
                                phase = EnumList.InvoiceType.Inkassovarsel;
                                amount = 0;
                                delayDays = 15;
                                keepDue = true;
                                //ToDo :: Notify user last time for inkassovarsel
                            }
                            else
                            {
                                phase = EnumList.InvoiceType.Inkasso;
                                amount = 0;
                                delayDays = 0;
                                notificationHours = 0;
                                invoice.NextNotification = DateTime.MaxValue;

                                notifyAdmin = true;
//                                notifyUser = false;
                            }
                            
                            break;
                        case EnumList.InvoiceType.Inkasso:
                            //This must not be reach because at the last phase we do remove the notification and sending to inkasso
                            return;
                        
                        default:
                            return;
                    }
                    
                    
                          
                    
                    break;
                default:
                    return;
            }
            
            var newDualDate = invoice.CurrentDueDate;
            if (!keepDue)
                newDualDate = newDualDate.AddDays(delayDays);
            
            var newDeadline = invoice.CurrentDeadline.AddDays(delayDays);
            
            //Update the dates and next notification here
            invoice.CurrentDueDate = newDualDate;
            invoice.CurrentDeadline = newDeadline;
            
            if(invoice.NextNotification.Date != DateTime.MaxValue.Date)
                invoice.NextNotification = invoice.NextNotification.AddDays(delayDays).AddHours(notificationHours);
            invoice.CurrentAmount += amount;
            invoice.InvoiceType = phase;
            
            
            increment.InvoicePhase = phase;
            increment.Amount = amount;
            increment.Type = type;
            increment.NewDueDate = newDualDate;
            increment.NewDeadline = newDeadline;



            _context.Update(invoice);
            _context.Add(increment);
            await _context.SaveChangesAsync();
            
            if(notifyAdmin)
                await _email.NotifyAdminForInvoice(invoiceNumber);


            //ToDo :: Notify user could be needed here
            //ToDo :: Check if the user email notification will be created from here or from somewhere else






//            var invoice = _context.Invoices.Find(invoiceNumber);
//            if(invoice == null)
//                return;
//            
//            //Add only a delay for the invoice
//            if (reason == EnumList.IncrementReason.Delay)
//            {
//                invoice.CurrentDueDate = invoice.CurrentDueDate.AddDays(delayDays);
//                invoice.CurrentDeadline = invoice.CurrentDeadline.AddDays(delayDays);
//                
//                var delay = new InvoiceIncrement()
//                {
//                    Invoice = invoice, NewDueDate = invoice.CurrentDueDate, NewDeadline = invoice.CurrentDeadline, InvoicePhase = invoice.InvoiceType, Amount = 0,
//                    Delay = delayDays, Reason = EnumList.IncrementReason.Delay, 
//                };
//
//
//                _context.Update(invoice);
//                _context.Add(delay);
//                _context.SaveChanges();
//                return;
//            }
//            
//            //ToDo :: If invoice is already inkassovarsel then it will be inkasso and Contact Us message will be send to admin
//
//
//            delayDays = 15;
//            var amount = (decimal) 70;
//            var type = EnumList.IncrementType.Fixed;
//            var newDualDate = invoice.CurrentDueDate.AddDays(delayDays);
//            var newDeadline = invoice.CurrentDeadline.AddDays(delayDays);
//            var phase = EnumList.InvoiceType.Invoice;
//            
//            if(invoice.IsPostpaid())
//                return;
//            if (invoice.IsOverDue())
//            {
//                
//                
//            }
//            else
//            {
//                type = EnumList.IncrementType.Percent;
//                amount = invoice.CurrentAmount * (decimal) 8.5 / 100;
//                phase = EnumList.InvoiceType.Inkassovarsel;
//                delayDays = 30;
//            }
//            
//            
//            
//
//            if (type == EnumList.IncrementType.Percent)
//            {
//                var oldAmount = invoice.CurrentAmount;
//                var percentIncrement = oldAmount * amount / 100;
//                amount = percentIncrement;
//            }
//
//
//            invoice.CurrentDueDate = newDualDate;
//            invoice.CurrentDeadline = newDualDate.AddDays(15);
//            invoice.CurrentAmount += amount;
//            _context.Update(invoice);
//
//            var increment = new InvoiceIncrement
//            {
//                Amount = amount,
//                Invoice = invoice,
//                NewDueDate = newDualDate,
//                NewDeadline = newDualDate.AddDays(15),
//                Type = type,
//                InvoicePhase = phase,
//                Reason = reason
//            };
//
//
//            _context.Add(increment);
//            _context.SaveChanges();

        }

        public List<InvoiceIncrement> GetIncrementsList(int invoiceNumber)
        {
            var invoice = GetInvoice(invoiceNumber);
            return invoice == null ? new List<InvoiceIncrement>() : _context.Increments.Where(x => x.InvoiceNumber == invoice.Number).Include(x=>x.Invoice).OrderBy(x=>x.Date).ToList();
        }

        public DateTime GetDueDate(int invoiceNumber)
        {
            var invoice = GetInvoice(invoiceNumber);
            if(invoice == null)
                return DateTime.MinValue;
            var increments = _context.Increments.Where(x => x.InvoiceNumber == invoice.Number).Include(x=>x.Invoice).OrderByDescending(x=>x.NewDueDate).ToList();
            return increments.Any() ? increments[0].NewDueDate.Date : invoice.OriginalDueDate.Date;
        }
        
        public DateTime GetDeadline(int invoiceNumber)
        {
            var invoice = GetInvoice(invoiceNumber);
            if(invoice == null)
                return DateTime.MinValue;
            var increments = _context.Increments.Where(x => x.InvoiceNumber == invoice.Number).Include(x=>x.Invoice).OrderByDescending(x=>x.NewDeadline).ToList();
            return increments.Any() ? increments[0].NewDeadline.Date : invoice.OriginalDeadline.Date;
            
        }

        public MatterixPayment GetActivePayment(int invoiceNumber)
        {
            //Active means the payment which was not refunded :: It is possible to have one old refunded payment for the same invoice
            return _context.Payments.Where(x=>!x.Refunded).SingleOrDefault(x => x.InvoiceNumber == invoiceNumber);
        }

        private List<MatterixInvoice> GetCourseInvoices(ClaimsPrincipal user, string courseId)
        {
            var userId = GetUserId(user);
            return _context.Invoices.Where(x => x.CourseId == courseId)
                .Where(x => x.UserId == userId)
                .Where(x=>!x.Canceled && !x.Moved)
                .ToList()
                .Where(x=>!x.IsPlus())
                .OrderBy(x=>x.OriginalDueDate)
                .ToList();
        }

        public List<MatterixInvoice> GetCoursePaidInvoices(ClaimsPrincipal user, string courseId)
        {
            return GetCourseInvoices(user, courseId).Where(x=>!x.Canceled && x.Paid).Where(x=>!x.IsPlus()).ToList();
        }

        public List<MatterixInvoice> GetCourseRemainingInvoices(ClaimsPrincipal user, string courseId)
        {
            return GetCourseInvoices(user, courseId).Where(x=>!x.Paid).Where(x=>!x.IsPlus()).ToList();
        }

        private string GetUserId(ClaimsPrincipal user)
        {
            return _user.GetUserId(user);
        }

        public bool IsInvoiceOverLate(int invoiceNumber)
        {
            //Add hours (1) is to make over late invoices shows on 01:00 not 00:00
            return GetDeadline(invoiceNumber) <= Format.NorwayDateTimeNow().Date.AddHours(1);
        }

        public bool IsInvoiceOverDue(int invoiceNumber)
        {
            return GetDueDate(invoiceNumber) <= Format.NorwayDateTimeNow();
        }
        
        
    }
}