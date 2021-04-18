using System;
using System.Collections.Generic;

namespace Matterix.Models.ViewModel
{
    public class InvoiceViewModel
    {
        public MatterixInvoice Invoice { get; set; }
        public ApplicationUser User { get; set; }
        public Course Course { get; set; }
        public Address Address { get; set; }
        public List<InvoiceIncrement> Increments { get; set; }
        public Registration Registration { get; set; }
        public decimal FullAmount { get; set; }
        
        public DateTime DueDate { get; set; }
        
        public DateTime Deadline { get; set; }
        
        public decimal Payments { get; set; }
    }
}