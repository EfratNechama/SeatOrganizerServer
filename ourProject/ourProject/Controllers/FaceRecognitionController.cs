using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceRecognitionController : ControllerBase
    {
        public IFaceRecognitionBL ifacerecognitionbl;


        public FaceRecognitionController(IFaceRecognitionBL ifacerecognitionbl)
        {
            this.ifacerecognitionbl = ifacerecognitionbl;

        }

        [HttpPost]
        public async Task<RecognizedGuest> Post(int eventId , string img)
        {
    
        string startupPath = System.IO.Directory.GetCurrentDirectory();

            img = img.Replace("data:image/jpeg;base64,", "");
            byte[] bytes = Convert.FromBase64String(img);
            var folderName = Path.Combine("Resources", "Test");
            var directory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            Directory.CreateDirectory(directory);
            string ImageFullPath = Path.Combine(folderName, eventId.ToString() + ".jpg");
            System.IO.File.WriteAllBytes(ImageFullPath, bytes);
            string trainPath = startupPath+"\\Resources\\GuestFaces\\" + eventId;
            string testPath =startupPath + ImageFullPath;
            string queryStr = "train=" + trainPath + "&test=" + testPath;
            RecognizedGuest rg = await ifacerecognitionbl.postBl(queryStr, eventId);
            return rg;


        }
  
       



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
