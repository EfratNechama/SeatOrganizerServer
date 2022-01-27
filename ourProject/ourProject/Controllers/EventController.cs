using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DTO;
using Entities;
//using NLog;
using Microsoft.Extensions.Logging;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        
         IEventBL ieventbl;
         IMapper imapper;

      /*  public IMapper Imapper { get => imapper; set => imapper = value; }*/

        public EventController(IEventBL Ieventbl, IMapper imapper)
        {
           
            ieventbl = Ieventbl;
            this.imapper = imapper;
        }
        // GET: api/<EventController>
        [HttpGet("eventByEventId/{id}")]
        public async Task<Event> Get(int id )
        {
            Event e = await ieventbl.getEventByEventIdBL(id);
            //EventDTO eDTO = imapper.Map<Event, EventDTO>(e);
            return e;
        }

        // GET api/<EventController>/5
        [HttpGet("allEventsByUserId/{id}")]
        public async Task<List<Event>> GetEventsList(int id)
        {
            List<Event> eventList = await ieventbl.getEventByUserIdBL(id);
            //List<EventDTO> eventListDTO = imapper.Map<List<Event>, List<EventDTO>>(eventList);
            return eventList;
        }

        // POST api/<EventController>
        [HttpPost]
        public async Task Post([FromBody] Event e, int userId)
        {
            //Event e = imapper.Map<EventDTO, Event>(edto);
            await ieventbl.PostBL(e , userId);
          

        }


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Event e)
        {
            //Event e = imapper.Map<EventDTO, Event>(edto);
            
            await ieventbl.PutBL(id, e);

        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await ieventbl.DeleteBL(id);
        }
    }
}
