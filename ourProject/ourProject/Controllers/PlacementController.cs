using AutoMapper;
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
    public class PlacementController : ControllerBase
    {
        IPlacementBL iplacementbl;
        IMapper imapper;

        public PlacementController(IPlacementBL iplacementbl, IMapper imapper)
        {

            this.iplacementbl = iplacementbl;
            this.imapper = imapper;
        }
        // GET: api/<ValuesController>
        [HttpGet("{eventId}")]
        public async Task<List<GuestSeat>> Get(int eventId)
        {
            return await iplacementbl.getBl(eventId);
        }

        // GET api/<ValuesController>/5
        [HttpPost()]
        public async Task Post([FromBody]Event eve)
        {
           
            try
                {
                await this.iplacementbl.place(eve.Id);
                }
            catch(Exception  e)
            {
                var x = 5;
            }
            }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
