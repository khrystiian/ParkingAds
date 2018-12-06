using System;
using System.Collections.Generic;
using System.Text;
using ParkingAds.Models;

namespace BusinessLogic
{
    public class ParkingLogic : IParkingLogic
    {
        public List<ParkingLocation> GetAllParking()
        {
            return Cacher.CachedParking;
        }

        public ParkingLocation GetParking(string name)
        {

            var temp = Cacher.CachedParking;
            foreach (ParkingLocation pl in temp)
            {
                if (pl.Name == name)
                {
                    return pl;
                }
            }
            //webapi, deal with it
            throw new Exception();
        }




    }
}
