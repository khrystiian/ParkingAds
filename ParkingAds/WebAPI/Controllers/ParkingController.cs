using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAds.Models;
using ParkingAds.BusinessLogic;
using BusinessLogic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        IParkingLogic _park = new ParkingLogic();

        // GET: api/Parking
        [HttpGet]
        public List<ParkingLocation> Get()
        {
            return _park.GetParking();
        }

        // GET: api/Parking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get1(int id)
        {
            return "value";
        }

        // POST: api/Parking
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Parking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
