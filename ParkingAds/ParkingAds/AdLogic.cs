using Models;
using System;
using System.Data;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ParkingAds.BusinessLogic
{
    public class AdLogic : IAdLogic
    {
        public string GetAd()
        {
            return CacheAd();
        }

        public string CacheAd()
        {
            using (var httpClient = new HttpClient())
            {

                var response = httpClient.GetStringAsync(new Uri("http://adservice.ws.dm.sof60.dk/api/ad")).Result;
                var a = response.Remove(1, 13).Replace("{", "").Replace("}", "").Replace("\"", "");

                //var doc = XDocument.Parse(response.Substring(14, response.Length-1));

                // var test = doc.Root.Elements("ImageData");

                return a;
            }
        }


    }
}
