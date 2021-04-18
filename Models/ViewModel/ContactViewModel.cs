using System;
using Matterix.Services;
using Microsoft.AspNetCore.Http;

namespace Matterix.Models.ViewModel
{
    public class ContactViewModel
    {
        public ApplicationUser User { get; set; }
        public UserDevice Device { get; set; }
        public string FullName { get; set; }
        public IFormFile File { get; set; }
        public EnumList.Contact Reason { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}