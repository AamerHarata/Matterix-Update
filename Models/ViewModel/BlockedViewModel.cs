using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class BlockedViewModel
    {
        public List<UserDevice> Devices { get; set; }
        public List<MatterixInvoice> Invoices { get; set; }
        public ApplicationUser User { get; set; }
        public Address Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int TotalInvoices { get; set; }
    }
}