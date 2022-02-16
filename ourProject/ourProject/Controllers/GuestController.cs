﻿
using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        public IGuestBL iguestbl;
        public IMapper imapper;
        public GuestController(IGuestBL Iguestbl, IMapper imapper)
        {
            iguestbl = Iguestbl;
            this.imapper = imapper;
        }
       // GET: api/<EventController>
        [HttpGet("{EventId}")]
        public async Task<List<Guest>> Get(int EventId)
        {
            return await iguestbl.GetBL(EventId);
        }
        // GET: api/<EventController>
        /*        [HttpGet("{eventId}")]
                public  async Task Get(int eventId)
                {
                  await  iguestbl.sendEmailBL(eventId);
                }*/


        // POST api/<EventController>
        [HttpPost]
        public async Task Post([FromBody] Guest g)
        {

            await iguestbl.PostBL(g);

        }


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Guest g)
        {
            await iguestbl.PutBL(id,g);

        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await iguestbl.DeleteBL(id);
        }



        
    }
}
