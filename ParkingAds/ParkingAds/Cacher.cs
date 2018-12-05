using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Models;
using Newtonsoft.Json.Linq;
using ParkingAds.Models;

namespace BusinessLogic
{
    public class Cacher
    {

        public static Ad CachedAd = new Ad();
        public static List<ParkingLocation> CachedParking = new List<ParkingLocation>();


        public static void Start()
        {
            Thread adthread = new Thread(new ThreadStart(InvokeAdCaching));
            Thread parkingthread = new Thread(new ThreadStart(InvokeParkingCaching));

            adthread.Start();
            parkingthread.Start();
        }
        static void InvokeParkingCaching()
        {
            while (true)
            {
                ParkingCacher();
                Thread.Sleep(1000 * 10); // 10 seconds update rate
                //Have a break
            }
        }

        static void ParkingCacher()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetStringAsync(new Uri("http://ucn-parking.herokuapp.com/places.json")).Result;

                    CachedParking = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingLocation>>(response); ;
                }
                catch
                {
                    // If http error or network error or alternative error
                    // if failure is on first request then put placeholder, otherwise just keeps old one
                    if (CachedParking == null)
                    {

                    }
                }


            }
        }

        static void InvokeAdCaching()
        {
            while (true)
            {
                AdCacher();
                Thread.Sleep(1000 * 60 * 2); // 2 Minutes
                //Have a break
            }
        }

        static void AdCacher()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                try
                {
                    var data = httpClient.GetAsync("http://adservice.ws.dm.sof60.dk/api/ad").Result;

                    var ser = new XmlSerializer(typeof(Ad));
                    var t = (Ad)ser.Deserialize(data.Content.ReadAsStreamAsync().Result);

                    //use regexp to see if actually image or weirdly implemented error message
                    if (Regex.IsMatch(t.ImageData, @"^[a-zA-Z0-9\+/]*={0,2}$"))
                    {
                        CachedAd = t;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch
                {
                    // If http error or network error or alternative error
                    // if failure is on first request then put placeholder, otherwise just keeps old one
                    if (CachedAd == null)
                    {
                        CachedAd.ImageData = "imagine this is a placeholder base64 string";
                    }
                }


            }
        }


    }
}
