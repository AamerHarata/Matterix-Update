using Matterix.Services;

namespace Matterix.Models.Vipps
{
    public class merchantInfo
    {
        //ToDo :: Change Values on production
        
        //ToDo :: Test
//        public string merchantSerialNumber { get; set; } = "211087";
        
        
        //ToDo :: Live
        public string merchantSerialNumber { get; set; } = "211087";
        
        public string fallBack { get; set; } = $"{StaticInformation.FullWebsite}/VippsCallBack/";
        public string callbackPrefix { get; set; } = $"{StaticInformation.FullWebsite}/VippsCallBack/";
        public string paymentType { get; set; } = "eComm Regular Payment";
        public bool isApp { get; set; } = false;
    }
}