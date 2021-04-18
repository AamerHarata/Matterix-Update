using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Matterix.Models.ViewModel
{
    public class MatterixPlusViewModel
    {
        public MatterixPlusApplication Application { get; set; }
        
        public List<Course> Courses { get; set; } = new List<Course>(); //Courses to be registered in
        
        public List<MatterixFile> Files { get; set; } = new List<MatterixFile>(); //Could be needed to upload multiple files to the application
        
        public List<MatterixInvoice> Invoices { get; set; }
    }
}