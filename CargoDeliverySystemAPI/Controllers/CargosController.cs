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
    public class CargosController : ControllerBase
    {
        private readonly CargoDeliveryDBContext _CargoDeliveryDBContext;

        public CargosController(CargoDeliveryDBContext CargoDeliveryDBContext)
        {
            _CargoDeliveryDBContext = CargoDeliveryDBContext;
        }



        // GET: api/<CargosController>
        [HttpGet]
        public IEnumerable<Cargo> Get()
        {
            return _CargoDeliveryDBContext.Cargos;
        }

        // GET api/<CargosController>/5
        [HttpGet("{id}")]
        public Cargo Get(int id)
        {
            return _CargoDeliveryDBContext.Cargos.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<CargosController>
        [HttpPost]
        public void Post([FromBody] Cargo cargo)
        {
            _CargoDeliveryDBContext.Cargos.Add(cargo);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // PUT api/<CargosController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Cargo cargo)
        {
            cargo.Id = id;
            _CargoDeliveryDBContext.Cargos.Update(cargo);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // DELETE api/<CargosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CargoDeliveryDBContext.Cargos.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                _CargoDeliveryDBContext.Cargos.Remove(item);
                _CargoDeliveryDBContext.SaveChanges();
            }
        }
    }
}
