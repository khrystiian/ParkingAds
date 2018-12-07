using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Mapping;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        PaymentLogic paymentLogic = new PaymentLogic();
        // GET: api/Payment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value payment" };
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "GetPayment")]
        public PaymentViewModel Get(int id)
        {
            return new PaymentViewModel
            {
                base64StringReceipt = ""
            };
        }

        // POST: api/Payment
        [HttpPost]
        public void Post([FromBody] PaymentViewModel payment)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (payment != null)
            {
                paymentLogic.Base64Image(payment);
            }
        }

        // PUT: api/Payment/5
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
