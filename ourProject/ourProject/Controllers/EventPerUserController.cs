using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPerUserController : ControllerBase
    {

        public IEventPerUserBL ieventperuserbl;
        
        public EventPerUserController(IEventPerUserBL ieventperuserbl)
        {
            this.ieventperuserbl= ieventperuserbl;
           
        }
        // GET: api/<EventPerUser>
        [HttpGet]
        public async Task<List<Event>> Get(int UserId)
        {

            return await ieventperuserbl.GetEventListByUserIdBL(UserId);
        }

        //// GET api/<EventPerUser>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EventPerUser>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EventPerUser>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EventPerUser>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
