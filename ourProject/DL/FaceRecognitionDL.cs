using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DL
{
    public class FaceRecognitionDL:IFaceRecognitionDL
    {
        SeatOrganizerContext _myDB;
        public FaceRecognitionDL(SeatOrganizerContext SeatOrganizerContext)
        {
            _myDB = SeatOrganizerContext;
        }


        public int goToPython(string queryStr)
        {
            WebRequest request;
            request = WebRequest.Create("http://127.0.0.1:9007/sentiment?" + queryStr);
            WebResponse response = request.GetResponse();
            int guestId;
            string responseFromServer = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                string[] responsearr = responseFromServer.Split("\n");
                guestId = Int32.Parse(responsearr.LastOrDefault());

            }
            //טיפול בתשובה שחזרה מהשרת
            response.Close();
            return guestId;
        }
    }
}
