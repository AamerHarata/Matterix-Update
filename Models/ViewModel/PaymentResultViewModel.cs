using Matterix.Services;

namespace Matterix.Models.ViewModel
{
    public class PaymentResultViewModel
    {
        public ApplicationUser Student { get; set; }
        public Course Course { get; set; }
        public MatterixInvoice Invoice { get; set; }
        public EnumList.PaymentReason Reason { get; set; }
        public EnumList.PaymentResult Result { get; set; }
        public string message { get; set; }
    }
}