using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceRecognitionController : ControllerBase
    {

        [HttpPost]
        public string Post(int eventId)
        {
            //string img,
            //img =img.Replace("data:image/jpeg;base64,", "");
            //byte[] bytes = Convert.FromBase64String(img);
            //var folderName = Path.Combine("Resources", "Test");
            //var directory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //Directory.CreateDirectory(directory);
            //string ImageFullPath = Path.Combine(folderName, eventId.ToString() + ".jpg");
            //System.IO.File.WriteAllBytes(ImageFullPath, bytes);
            string trainPath = "C:\\פרוייקט גמר\\project20_6\\ourProject\\ourProject\\Resources\\GuestFaces" + eventId;
            //string testPath = "C:\\Users\\1\\Desktop\\אפרת לימודים 2022\\פרויקט גמר\\projectServer\\ourProject\\ourProject\\" + ImageFullPath;
            string testPath = "C:\\פרוייקט גמר\\project20_6\\ourProject\\ourProject\\Resources\\Test\\125.jpg";
            ////התחברות לשרת פייתון
            WebRequest request;
            string str = "from c#";
            string queryStr = "train=" + trainPath + "&test=" + testPath;
            request = WebRequest.Create("http://127.0.0.1:9007/sentiment?"+queryStr);
              
            WebResponse response = request.GetResponse();
            string responseFromServer = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);

            }
            //טיפול בתשובה שחזרה מהשרת
            response.Close();
            return responseFromServer;


        }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    WebRequest request2;
        //    request2 = WebRequest.Create("http://127.0.0.1:9007/my_face_recognition/"+id);

        //    return request2.GetResponse().ToString();
        //}




        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    //using WebRequest
        //    WebRequest request;
        //    request = WebRequest.Create("http://127.0.0.1:9007/my_face_recognition/do_POST");

        //    //
        //    request.ContentType = "application/json";
        //    request.Method = "POST";

        //    string responseFromServer = string.Empty;
        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        string json = JsonSerializer.Serialize("311");

        //        streamWriter.Write(json);
        //    }
        //    WebResponse response = request.GetResponse();
        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        // Open the stream using a StreamReader for easy access.
        //        StreamReader reader = new StreamReader(dataStream);
        //        // Read the content.
        //        reader.ToString();
        //        responseFromServer = reader.ReadToEnd();
        //        // Display the content.
        //        Console.WriteLine(responseFromServer);

        //    }
        //    //טיפול בתשובה שחזרה מהשרת
        //    response.Close();
        //}

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
