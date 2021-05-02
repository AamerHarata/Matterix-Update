using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class MatterixInvoice
    {
        public int Number { get; set; } = new Random().Next(10000000, 99999999);
        
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = Format.NorwayDateTimeNow();
        [DataType(DataType.Date)]
        public DateTime OriginalDueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime OriginalDeadline { get; set; }
        [DataType(DataType.Date)]
        public DateTime CurrentDueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CurrentDeadline { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime LastNotification { get; set; }
        [DataType(DataType.Date)]
        public DateTime NextNotification { get; set; }
        public decimal Amount { get; set; }
        public int CIDNumber { get; set; } = new Random().Next(10000000, 99999999);
        public EnumList.InvoiceType InvoiceType { get; set; } = EnumList.InvoiceType.Invoice;
        public bool Paid { get; set; }
        public string PaymentId { get; set; } = "";
        public EnumList.InvoiceReason Reason { get; set; }
        public bool Moved { get; set; }
        public string MovedTo { get; set; }= "";
        public string ExtraDescription { get; set; } = "";
        public bool Canceled { get; set; }
        
        public string ApplicationId { get; set; }
        public MatterixPlusApplication Application { get; set; }
        
        
        
        
        
        
        
        //Can be null
        public string CourseId { get; set; }
        public Course Course { get; set; }
        
        //Not null
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }



        public bool ActiveInvoice(){return !Paid && !Canceled && string.IsNullOrEmpty(ApplicationId);}

        
        public bool IsPostponed()
        {
            return ActiveInvoice() && Format.NorwayDateTimeNow() < OriginalDueDate;
        }

        public bool IsOverDue()
        {
            return ActiveInvoice() && Format.NorwayDateTimeNow() >= CurrentDueDate && Format.NorwayDateTimeNow() < CurrentDeadline;
        }
        
        public bool IsLate()
        {
            return ActiveInvoice() && Format.NorwayDateTimeNow() >= CurrentDeadline.AddHours(2);
        }

        public bool IsOriginallyLate()
        {
            return ActiveInvoice() && !IsPostponed() && !(Format.NorwayDateNow() < OriginalDeadline);
        }

        public bool IsOriginallyOverdue()
        {
            return ActiveInvoice() && !IsPostponed() && !IsOriginallyLate();
        }

        public string StatusString()
        {
            if (!ActiveInvoice())
                return "error";
            if (IsPostponed())
                return "postponed";
            return IsOriginallyLate() ? "late": "overDue";
        }

        public bool IsPlus()
        {
            return !string.IsNullOrEmpty(ApplicationId);
        }


    }
}