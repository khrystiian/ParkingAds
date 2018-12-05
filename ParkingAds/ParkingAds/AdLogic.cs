﻿using Models;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using BusinessLogic;

namespace ParkingAds.BusinessLogic
{
    public class AdLogic : IAdLogic
    {
        public Ad cachedAd = new Ad();
        public string GetAd()
        {
            return Cacher.cachedAd.ImageData;
        }

        public string CacheAd()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                try
                {
                    var data = httpClient.GetAsync("http://adservice.ws.dm.sof60.dk/api/ad").Result;

                    var ser = new XmlSerializer(typeof(Ad));
                    var t = (Ad)ser.Deserialize(data.Content.ReadAsStreamAsync().Result);

                    t.TimeStamp = DateTime.Now;
                    cachedAd = t;
                    return t.ImageData;
                }
                catch
                {
                    if (cachedAd==null)
                    {
                        return "imagine this is a placeholder base64 string";
                    }
                    return cachedAd.ImageData;
                }


            }
        }

    }
}
