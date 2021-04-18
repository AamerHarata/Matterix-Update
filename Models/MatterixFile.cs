using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class MatterixFile
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string WebPath { get; set; }
        public string RootPath { get; set; }
        public DateTime UploadDate { get; set; } = Format.NorwayDateTimeNow();
        public string ContentType { get; set; }
        public decimal MbSize { get; set; }
        
    }
}