using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class MatterixPayment
    {
        public string Id { get; set; }
        public EnumList.PaymentReason Reason { get; set; }
        public EnumList.PaymentMethod Method { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = Format.NorwayDateTimeNow();
        public decimal Amount { get; set; }
        public string ExtraDescription { get; set; } = "";
        public string PaymentServiceRef { get; set; } = "";
        public bool Refunded { get; set; }
        public DateTime RefundedAt { get; set; }
        
        
        
        
        
        //Can be null
        public int InvoiceNumber { get; set; }
        public MatterixInvoice Invoice { get; set; }
        
        //Can be null
        public string CourseId { get; set; }
        public Course Course { get; set; }
        
        //Not null
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }




    }
}