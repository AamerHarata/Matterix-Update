using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class InitiatedOrder
    {
        [Key]
        public string Id { get; set; }
        
        
        public string CourseId { get; set; }
        public bool PayAllNow { get; set; }
        public decimal Amount { get; set; }

        public DateTime Created { get; set; } = Format.NorwayDateTimeNow();
        
        public EnumList.PaymentReason Reason { get; set; }
        public int InvoiceNumber { get; set; }
        public string Ip { get; set; }
        public string AuthCookies { get; set; }
        public EnumList.OperatingSystem OperatingSystem { get; set; }
        public EnumList.DeviceType DeviceType;
        
        
        public EnumList.OrderStatus Status { get; set; }
        public EnumList.PaymentMethod PaymentMethod { get; set; }






        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        
    }
}