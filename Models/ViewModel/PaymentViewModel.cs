using System.Collections.Generic;
using Matterix.Services;

namespace Matterix.Models.ViewModel
{
    public class PaymentViewModel
    {
        public EnumList.PaymentReason Reason { get; set; }
        public Course Course { get; set; }
        
        public ApplicationUser Student { get; set; }
        public Address Address { get; set; }
        public UserDevice Device { get; set; }
        
        public MatterixInvoice InvoiceToPay { get; set; }
        public List<MatterixInvoice> Invoices { get; set; }
    }
}