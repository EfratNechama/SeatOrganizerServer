
using BL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using AutoMapper;
using System.IO;
using System.Web;
using System.IO;



using System;
using DTO;

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
        [HttpGet("all/{EventId}")]
        public async Task<List<Guest>> Get(int EventId)
        {
            return await iguestbl.GetBL(EventId);
        }

        [HttpGet("one/{GuestId}")]
        public async Task<Guest> Get(int GuestId, int x)
        {
            return await iguestbl.GetGuestByGuestIdBL(GuestId);
        }
        ////GET: api/<EventController>
        //[HttpGet("{eventId}")]
        //public async Task Get(int eventId)
        //{
        //    await iguestbl.sendEmailByEventIdBL(eventId);
        //}


        // POST api/<EventController>
        [HttpPost("{sendEmail}")]
        public async Task Post(bool sendEmail, [FromBody] Guest g)
        {
            try { 
            await iguestbl.PostBL(g);
            if (sendEmail)
            {
                await iguestbl.sendEmailByGuestId(g);
            }
}
            catch(Exception e)
            {
                var x = 4;
            }
        }

        [HttpPut("sendEmail")]
        public async Task Put([FromBody] Guest g)
        {
            await iguestbl.sendEmailByGuestId(g);
        }
        [HttpDelete("sendEmailToAll/{eventId}")]
        public async Task Delete(int eventId)
        {
            List<Guest> l =await iguestbl.GetBL(eventId);
            for(int i=0; i<l.Count; i++)
            {
                await iguestbl.sendEmailByGuestId(l[i]);

            }
            return;
        }
        // PUT api/<EventController>/5
        //[HttpPut("image/{id}"), DisableRequestSizeLimit]
        //public async Task Put(int id, [FromBody] Guest g, [FromForm] IFormFile image)
        //{
        //    await iguestbl.PutBL(id, g);

        //}

        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] Guest g)
        {
            await iguestbl.PutBL(id, g);
       

            g.DataUrl=g.DataUrl.Replace("data:image/jpeg;base64,","");
            byte[] bytes = Convert.FromBase64String(g.DataUrl);
            var folderName = Path.Combine("Resources", "GuestFaces", g.EventId.ToString());
            var directory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            Directory.CreateDirectory(directory);
            string ImageFullPath = Path.Combine(folderName, g.Id.ToString() + ".jpg");
            string filePath = Path.Combine(directory, g.Id.ToString() + ".jpg");
            System.IO.File.WriteAllBytes(filePath, bytes);

        }

 
        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await iguestbl.DeleteBL(id);
        }

    }


}
