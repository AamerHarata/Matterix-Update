using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class UserDevice
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; } = Format.NorwayDateTimeNow();
//        public string Activity { get; set; }
        public EnumList.Activity Activity { get; set; }
//        public string DeviceType { get; set; }
        public EnumList.DeviceType DeviceType { get; set; }
//        public string OperatingSystem { get; set; }
        public EnumList.OperatingSystem OperatingSystem { get; set; }
        public string Ip { get; set; } = "";
        public string AuthCookies { get; set; }= "";
        
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Connection { get; set; }
        
        public bool New { get; set; }
        
        public int GroupNumber { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}