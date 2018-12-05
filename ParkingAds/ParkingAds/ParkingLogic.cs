using System;
using System.Collections.Generic;
using System.Text;
using ParkingAds.Models;

namespace BusinessLogic
{
    public class ParkingLogic : IParkingLogic
    {
        public List<ParkingLocation> GetParking()
        {
            return Cacher.CachedParking;
        }






    }
}
