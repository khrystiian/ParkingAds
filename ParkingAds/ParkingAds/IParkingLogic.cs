using System.Collections.Generic;
using ParkingAds.Models;

namespace BusinessLogic
{
    public interface IParkingLogic
    {
        List<ParkingLocation> GetParking();
    }
}