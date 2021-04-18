using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class InvoiceIncrement
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public EnumList.IncrementType Type { get; set; }
        public EnumList.IncrementReason Reason { get; set; }
        public DateTime Date { get; set; } = Format.NorwayDateTimeNow();

        public int Delay { get; set; } = 15;

        public EnumList.InvoiceType InvoicePhase { get; set; } = EnumList.InvoiceType.Invoice;
        
        public DateTime NewDueDate { get; set; }
        public DateTime NewDeadline { get; set; }
        
        public int InvoiceNumber { get; set; }
        public MatterixInvoice Invoice { get; set; }
    }
}