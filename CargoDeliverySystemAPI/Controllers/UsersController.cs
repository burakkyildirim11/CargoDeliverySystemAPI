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
    public class UsersController : ControllerBase
    {

        private readonly CargoDeliveryDBContext _CargoDeliveryDBContext;

        public UsersController(CargoDeliveryDBContext CargoDeliveryDBContext)
        {
            _CargoDeliveryDBContext = CargoDeliveryDBContext;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _CargoDeliveryDBContext.Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _CargoDeliveryDBContext.Users.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _CargoDeliveryDBContext.Users.Add(user);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.Id = id;
            _CargoDeliveryDBContext.Users.Update(user);
            _CargoDeliveryDBContext.SaveChanges();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CargoDeliveryDBContext.Users.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _CargoDeliveryDBContext.Users.Remove(item);
                _CargoDeliveryDBContext.SaveChanges();
            }
        }
    }
}
