using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAds.BusinessLogic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        IAdLogic _ad = new AdLogic();
        // GET: api/Ad
        [HttpGet]
        public string Get()
        {
            var a = _ad.GetAd();
            return a;

        }

        
    }
}
