using Matterix.Services;

namespace Matterix.Models
{
    public class NoNotification
    {
        public string UserId { get; set; }
        public EnumList.Notifications NotificationType { get; set; }
        public ApplicationUser User { get; set; }
        public EnumList.NotifyMethod Method { get; set; }
    }
}