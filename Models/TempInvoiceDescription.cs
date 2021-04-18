using System;
using System.ComponentModel.DataAnnotations;

namespace Matterix.Models
{
    public class TempInvoiceDescription
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        public int Price { get; set; }
        public int Paid { get; set; }
        
        public int Remain { get; set; }
    }
}