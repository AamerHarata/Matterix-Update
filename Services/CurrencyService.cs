using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Matterix.Services
{
    public class CurrencyService
    {
        public async Task<decimal> RateAsync(decimal amount, string fromCurrency, string toCurrency)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free.currconv.com/api/v7/convert?q="+fromCurrency+"_"+toCurrency+"&compact=ultra&apiKey=543b360514b19ebdc3ce"),
           
            };
        
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                //dynamic data = Newtonsoft.Json.Linq.JObject.Parse(body);
               

                  Regex regex = new Regex(@":(?<rhs>.+?),");
                  string[] arrDigits = regex.Split(body);
                  decimal rate = Convert.ToDecimal(arrDigits[1]);


                return Convert.ToDecimal(rate * amount);
                
               // Console.WriteLine(body);
            }
        }
    }
}
   
 
