using Models;
using System;
using System.Data;
using System.Net.Http;
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

                var doc = XDocument.Parse(response);


                var test = doc.Root.Elements("ImageData");
                return "lol";

                
            }
        }


    }
}
