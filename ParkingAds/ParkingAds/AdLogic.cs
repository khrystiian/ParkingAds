using Models;
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
        public string GetAd()
        {
            return Cacher.CachedAd.ImageData;
        }


    }
}
