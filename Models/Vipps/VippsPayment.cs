namespace Matterix.Models.Vipps
{
    public class VippsPayment
    {
        public merchantInfo merchantInfo { get; set; } = new merchantInfo();
        public customerInfo customerInfo { get; set; }
        public transaction transaction { get; set; }
    }
}