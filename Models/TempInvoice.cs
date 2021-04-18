using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matterix.Models
{
    public class TempInvoice
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string InvoiceNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set;}
        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; }
        public string StudentNumber { get; set; }
        public List<TempInvoiceDescription> Descriptions { get; set; } = new List<TempInvoiceDescription>();
        public string CidNumber { get; set; }
    }
}