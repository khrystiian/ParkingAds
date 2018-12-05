using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Models;

namespace BusinessLogic
{
    public class Cacher
    {

        public static Ad cachedAd = new Ad();
        public static void Start()
        {
            Thread printer = new Thread(new ThreadStart(InvokeMethod));
            printer.Start();
        }

        static void InvokeMethod()
        {
            while (true)
            {
                AdCacher();
                Thread.Sleep(1000 * 60 * 2); // 2 Minutes
                //Have a break condition
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
                        cachedAd = t;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch
                {
                    // If http error or network error
                    // if failure is on first request then put placeholder, otherwise just keeps old one
                    if (cachedAd == null)
                    {
                        cachedAd.ImageData = "imagine this is a placeholder base64 string";
                    }
                }


            }
        }


    }
}
