using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebAPI.Helpers
{
    public static class Mail
    {
        

        public static void SendMail(string emailTo, string subject, string body)
        {
            //string subject = "Email Subject";
           // string body = BodyBuilder();
            string FromMail = "procurementmistral@gmail.com";
            //string emailTo = emailReciver;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body + "\n\n\n" + "<img src='https://media.licdn.com/media/AAEAAQAAAAAAAAIQAAAAJDE5YTc1NzFhLTJlNTgtNDFiYi05MTlmLTM0YTJlOTY3MzlhOQ.png'>";
            mail.IsBodyHtml = true;
            string userName = System.Configuration.ConfigurationManager.AppSettings["emailUsername"];
            string password = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];

            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(userName, password);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        //private static string BodyBuilder()
        //{
        //    string email = "You have a new request";
        //    //email += "\n\n\n"+AppDomain.CurrentDomain.FriendlyName;
            
        //    return email;
        //}

    }
}