using System;

namespace Matterix.Models
{
    public class PlusApplicationFile
    {
        public string Id { get; set; }
        
        public string FileId { get; set; }
        public MatterixFile File { get; set; }
        
        public string ApplicationId { get; set; }
        public MatterixPlusApplication Application { get; set; }
    }
}