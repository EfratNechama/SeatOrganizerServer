using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace BL
{
    public class GuestBL :IGuestBL
    {
        IGuestDL iguestdl;
        IEventDL ieventdl;

        public GuestBL(IGuestDL iguestdl, IEventDL ieventdl)
        {
            this.iguestdl = iguestdl;
            this.ieventdl = ieventdl;
        }
       
        public async Task<List<Guest>> GetBL(int id)  
        {
            return await iguestdl.GetDL(id);
        }
        public async Task<Guest> GetGuestByGuestIdBL(int gId)
        {
            return await iguestdl.GetGuestByGuestIdDL(gId);
        }
        public async Task PostBL(Guest g)
        {
            await iguestdl.PostDL(g);
        }
        public async Task PutBL(int id, Guest g)
        {
            await iguestdl.PutDL(id, g); 
         
        }

        public async Task DeleteBL(int id)
        {
            await iguestdl.DeleteDL(id);
        }

        public void sendEmail(Guest g,Event e)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("neproject2@gmail.com");
            message.To.Add(new MailAddress(g.Email));
            try
            {
                message.Attachments.Add(new Attachment(e.InvitationImagePath));

            }
            catch (Exception e1)
            {
                int a = 1;
            }
            string mailbody = "You are invited to" + e.Name + "\n";
            int id = g.Id;
            string link = "<a href= https://www.diginet.co.il/  > Confirm arrival here</a>";

            //string link = "<a href= http://localhost:4200/#/guest-confirm/?id=" + g.Id + ">Confirm arrival here</a>";
            message.Subject = "Hi " + g.FirstName;
            message.Body = mailbody + link;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            client.Timeout = Int32.MaxValue;
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("neproject2@gmail.com", "wjufhbicsrzjyful");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task sendEmailByEventIdBL(int eventId)
        {
            Event ourEvent = await ieventdl.getEventByEventIdDL(eventId);

            List<Guest> guestList = await iguestdl.GetDL(eventId);
            for (int i = 0; i < guestList.Count; i++)
            {
                sendEmail(guestList[i], ourEvent);
            }



        }
        public async Task sendEmailByGuestId(Guest g)
        {
            Event ourEvent = await ieventdl.getEventByEventIdDL(g.EventId);
            sendEmail(g, ourEvent);
        }



    }






    }

