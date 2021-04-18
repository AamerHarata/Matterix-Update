using System;
using Matterix.Services;

namespace Matterix.Models
{
    public class UsedPassword
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; } = Format.NorwayDateTimeNow();
        public string PlaceCreated { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}