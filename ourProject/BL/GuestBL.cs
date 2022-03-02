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

        public GuestBL(IGuestDL iguestdl)
        {
            this.iguestdl = iguestdl;
        }
       
        public async Task<List<Guest>> GetBL(int id)  
        {
            return await iguestdl.GetDL(id);
        }
        public async Task PostBL(Guest g)
        {
            await iguestdl.PostDL(g);
        }
        public async Task PutBL(int id, Guest g)
        {
            try { await iguestdl.PutDL(id, g); }
            catch (Exception e)
            {
                var d = 5;
            }
         
        }

        public async Task DeleteBL(int id)
        {
            await iguestdl.DeleteDL(id);
        }

        //    public async Task sendMail(int eventId)
        //    {
        //       string name = "email" xsi: type = "Mail"

        //subject = "Sent From The Logger!"

        //to = "324861285@mby.co.il"

        //from = "siteloggermail@gmail.com"

        //body = "${message}${newline}"

        //smtpUserName = "siteloggermail@gmail.com"

        //smtpAuthentication = "Basic"

        //secureSocketOption = "SslOnConnect"

        //enableSsl = "true"

        //smtpPassword = "lovewebapi"

        //smtpServer = "smtp.gmail.com"

        //smtpPort = "587"

        public async Task sendEmailByEventIdBL(int eventId)
        {

            List<Guest> guestList = await iguestdl.GetDL(eventId);
            for (int i = 0; i < guestList.Count; i++)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("324861285@mby.co.il");
                message.To.Add(new MailAddress(guestList[i].Email));
               //////// message.Attachments.Add(new Attachment("M:\\q.jpg"));
                string mailbody = "You are invited to a big party!!!!!!!!!!!!!!!!!!!!!! \n";
                //string link = "<a href= https://localhost:44369/swagger/index.html > enter to match  </a>";
                message.Subject = "Hello "+ guestList[i].FirstName;
                // message.Attachments.Add(new Attachment("M:\\q.jpg"));

                message.Body = mailbody;// + link;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("324861285@mby.co.il", "Student@264");
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



        }
        public async Task sendEmailByGuestId(Guest g)
        {

            
            
                MailMessage message = new MailMessage();
                message.From = new MailAddress("neproject2@gmail.com");
                message.To.Add(new MailAddress("efrat48347@gmail.com"));
                //message.Attachments.Add(new Attachment("M:\\q.jpg"));
                string mailbody = "You are invited to a big party!!!!!!!!!!!!!!!!!!!!!! \n";
            //  string link = "<a href= https://localhost:44369/swagger/index.html > enter to match  </a>";
            message.Subject = "Hello ";//+ g.FirstName;
            //message.Attachments.Add(new Attachment("M:\\q.jpg"));

            message.Body = mailbody;
                //+ link;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("neproject2@gmail.com", "35363536");
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



        }






    }

