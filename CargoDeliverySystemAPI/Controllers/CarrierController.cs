using CargoDeliverySystemAPI.Data;
using CargoDeliverySystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CargoDeliverySystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly CargoDeliveryDBContext _CargoDeliveryDBContext;
        public CarrierController(CargoDeliveryDBContext CargoDeliveryDBContext)
        {
            _CargoDeliveryDBContext = CargoDeliveryDBContext;
        }


        // GET: api/<CarrierController>
        [HttpGet]
        public IEnumerable<Carrier> Get()
        {
            return _CargoDeliveryDBContext.Carrier;
        }

        // GET api/<CarrierController>/5
        [HttpGet("{id}")]
        public Carrier Get(int id)
        {
            return _CargoDeliveryDBContext.Carrier.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<CarrierController>
        [HttpPost]
        public void Post([FromBody] Carrier carrier)
        {
            _CargoDeliveryDBContext.Carrier.Add(carrier);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // PUT api/<CarrierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Carrier carrier)
        {
            carrier.Id = id;
            _CargoDeliveryDBContext.Carrier.Update(carrier);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // DELETE api/<CarrierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CargoDeliveryDBContext.Carrier.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _CargoDeliveryDBContext.Carrier.Remove(item);
                _CargoDeliveryDBContext.SaveChanges();
            }
        }
    }
}
