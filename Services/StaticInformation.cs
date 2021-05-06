using System;

namespace Matterix.Services
{
    public class StaticInformation
    {
        public static string ContactEmail { get; } = "support@matterix.no";
        public static string ContactNumber { get; } = "+47 - 482 700 30";
        public static string Website { get; } = "www.arabiskeskole.no";
        public static string FullWebsite { get; } = "https://arabiskeskole.no";
        public static string FacebookPage { get; } = "https://www.facebook.com/norske.fag.paa.arabisk";
        public static string FacebookGroup { get; } = "https://www.facebook.com/groups/norkse.fag.paa.arabisk/";
        public static string SecondName { get; } = "Norske Fag på Arabisk";
        public static string FirstName { get; } = "Matterix";
        public static string OrgNumber { get; } = "921498411";
        public static string Address { get; } = "Søgne 4640";

        public static string EmailSender { get; } = "test@matterix.no";
        public static string EmailSenderPassword { get; } = "Mmmm4444****";

        //ToDo :: Make this as a list of all admins
        public static string AdminMatterixId { get; } = "daf08f3a-e910-4cfe-b71f-26f4ea581ad3";
        public static string AccountNumber { get; } = "3209.16.13513";

        //ToDo :: Remove this field and get all Twilio settings from Json files
        public static string TwilioVerificationServiceSid { get; } = "VAbbfc4055fd2fc0a3bd10d15639c82557";
        
        //ToDo :: This variable must be removed | No summer time is required to convert from UTC to local
        public static bool NorwaySummerTime { get; } = DateTime.Now.Date <= new DateTime(DateTime.Now.Year, 10, 25)
            && DateTime.Now.Date > new DateTime(DateTime.Now.Year, 3, 21);

        public static bool AdvancedDevelopment { get; } = true;

        public static bool DeveloperTiming { get; } = false; //ToDo :: WHENEVER push to server this should be FALSE
        
        //This value used when you want edit the server main database from the localhost. MAKE IT FALSE BEFORE YOU DO ANYTHING
        public static bool AdvancedLive { get; } = true; //ToDo :: THIS SHOULD ALWAYS BE FALSE SPECIALLY ON DEVELOPMENT
    }
}