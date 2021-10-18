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
    public class CarriersLogController : ControllerBase
    {
        private readonly CargoDeliveryDBContext _CargoDeliveryDBContext;

        public CarriersLogController(CargoDeliveryDBContext CargoDeliveryDBContext)
        {
            _CargoDeliveryDBContext = CargoDeliveryDBContext;
        }

        // GET: api/<CarriersLogController>
        [HttpGet]
        public IEnumerable<CarriersLog> Get()
        {
            return _CargoDeliveryDBContext.CarriersLogs;
        }

        // GET api/<CarriersLogController>/5
        [HttpGet("{id}")]
        public CarriersLog Get(int id)
        {
            return _CargoDeliveryDBContext.CarriersLogs.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<CarriersLogController>
        [HttpPost]
        public void Post([FromBody] CarriersLog carriersLog)
        {
            _CargoDeliveryDBContext.CarriersLogs.Add(carriersLog);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // PUT api/<CarriersLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarriersLog carriersLog)
        {
            carriersLog.Id = id;
            _CargoDeliveryDBContext.CarriersLogs.Update(carriersLog);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // DELETE api/<CarriersLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CargoDeliveryDBContext.CarriersLogs.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _CargoDeliveryDBContext.CarriersLogs.Remove(item);
                _CargoDeliveryDBContext.SaveChanges();
            }
        }
    }
}
