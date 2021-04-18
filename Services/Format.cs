using System;
using System.Linq;
using Microsoft.AspNetCore.Html;

namespace Matterix.Services
{
    public class Format
    {
        private static DateTime ToNorwayTime(DateTime dateTime)
        {
            //ToDo :: Create Enum for countries / Then pass country as parameter to use this function as time converting in the whole app
            if (StaticInformation.DeveloperTiming)
                return dateTime;
            
            
            //ToDo :: converting from UTC to Norway timing will always be the same | Summer / winter timing is not important
            // return StaticInformation.NorwaySummerTime ? dateTime.AddHours(2) : dateTime.AddHours(2);
            
            //The value 2 is because Norway is UTC + 2
            return dateTime.AddHours(2);
        }
        
//        public static TimeSpan ToNorwayTime(TimeSpan dateTime)
//        {
//            var summerTime = DateTime.Now.Date < new DateTime(DateTime.Now.Year, 10, 25)
//                             && DateTime.Now.Date > new DateTime(DateTime.Now.Year, 3, 21);
//            
//            return summerTime ? dateTime.Add(TimeSpan.FromHours(2)) : dateTime.Add(TimeSpan.FromHours(1));
//        }

        public static DateTime NorwayDateTimeNow()
        {
            return ToNorwayTime(DateTime.Now);
        }

        public static DateTime NorwayDateNow()
        {
            return ToNorwayTime(DateTime.Now).Date;
        }

        public static TimeSpan NorwayTimeNow()
        {
            return ToNorwayTime(DateTime.Now).TimeOfDay;
        }
        
        public static string TimeFormat(TimeSpan time){return time.ToString(@"hh\:mm");}

        public static string TimeFormat(DateTime date){return date.ToString(@"hh\:mm");}
        
        public static string DateFormat(DateTime date){return date.ToString("dd.MM.yyy");}
        public static int NumberFormat(decimal num){return (int) Math.Round(num);}
        public static HtmlString Translate(string key){key = key.First().ToString().ToLower() + string.Join("", key.Skip(1));return new HtmlString("{{$t('message."+key+"')}}");}

        public static int GetPlusPrice(decimal num)
        {
            return (int) Math.Round((double)num*20.0/9.0);
        }

        public static string TranslateDay(EnumList.Days day, EnumList.Language language)
        {
            switch (day)
            {
                case EnumList.Days.Saturday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Lørdag";
                        case EnumList.Language.English:
                            return "Saturday";
                        case EnumList.Language.Arabic:
                            return "السبت";
                        default:
                            return "";
                    }
                
                
                
                
                
                
                
                
                
                case EnumList.Days.Sunday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Søndag";
                        case EnumList.Language.English:
                            return "Sunday";
                        case EnumList.Language.Arabic:
                            return "الأحد";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Monday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Mandag";
                        case EnumList.Language.English:
                            return "Monday";
                        case EnumList.Language.Arabic:
                            return "الاثنين";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Tuesday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Tirsdag";
                        case EnumList.Language.English:
                            return "Tuesday";
                        case EnumList.Language.Arabic:
                            return "الثلاثاء";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Wednesday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Onsdag";
                        case EnumList.Language.English:
                            return "Wednesday";
                        case EnumList.Language.Arabic:
                            return "الأربعاء";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Thursday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Torsdag";
                        case EnumList.Language.English:
                            return "Thursday";
                        case EnumList.Language.Arabic:
                            return "الخميس";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Friday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Fredag";
                        case EnumList.Language.English:
                            return "Friday";
                        case EnumList.Language.Arabic:
                            return "الجمعة";
                        default:
                            return "";
                    }
                default:
                    return "";
            }
            
        }
        
    }
}