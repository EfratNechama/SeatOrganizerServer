
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

            await iguestbl.PostBL(g);
            if (sendEmail)
            {
                await iguestbl.sendEmailByGuestId(g);
            }

        }

        [HttpPut("sendEmail")]
        public async Task Put([FromBody] Guest g)
        {
            await iguestbl.sendEmailByGuestId(g);
        }
        // PUT api/<EventController>/5
        //[HttpPut("image/{id}"), DisableRequestSizeLimit]
        //public async Task Put(int id, [FromBody] Guest g, [FromForm] IFormFile image)
        //{
        //    await iguestbl.PutBL(id, g);

        //}

        [HttpPut("image/{guestId}/{base64}"), DisableRequestSizeLimit]
        public  void Put(int guestId, object base64)
        {

            string str = base64.ToString();

            //Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            //var base64File = regex.Replace(data.Base64Image, string.Empty);
            //var x = 1;


            //    byte[] bytes = Convert.FromBase64String(base64);
            //    Image image;
            //    using (MemoryStream ms = new MemoryStream(bytes))
            //    {
            //        image = Image.FromStream(ms);
            //    }
            //}
            //   var folderName = Path.Combine("Resources", "GuestFaces", g.EventId.ToString(),g.Id.ToString());
            //  var directory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //  Directory.CreateDirectory(directory);
            //  string ImageFullPath = Path.Combine(folderName, g.Id.ToString());
            //string filePath = Path.Combine(directory, g.Id.ToString());
            //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    var iformbase = iFormFile(base64);
            //    base64.CopyTo(fileStream);
            //}
            //    try
            //    {

            //       
            //        //var bytes = Convert.FromBase64String(base64.);
            //        using (var imageFile = new FileStream(filePath, FileMode.Create))
            //        {
            //            //imageFile.Write(str, 0, str.Length);
            //            imageFile.Flush();
            //        }
            //    }
            //    catch(Exception e)
            //    {
            //        var ex = e;
            //    }

        
        //}
        //// DELETE api/<EventController>/5
        //[HttpDelete("{id}")]
        //public async Task DeleteAsync(int id)
        //{
        //    await iguestbl.DeleteBL(id);
        //
        // byte[] bytes = Convert.FromBase64String(base64);
}


    }


}
