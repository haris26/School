using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmailInput
    {
        public string EmailId { get; set; }
    }

    public class EMailHelper
    {
        public static readonly string EMAIL_SENDER = "leyladzeko@gmail.com";
        public static readonly string EMAIL_CREDENTIALS = "superwoofer"; 
        public static readonly string SMTP_CLIENT = "smtp.gmail.com";       
        public static readonly string EMAIL_BODY = "Deadline for inserting your time logs has passed. Please do it ASAP";
        public static readonly string EMAIL_SUBJECT = "Time logs";

        private string senderAddress;
        private string clientAddress;
        private string netPassword;
        public EMailHelper(string sender, string Password, string client)
        {
            senderAddress = sender;
            netPassword = Password;
            clientAddress = client;
        }

        public bool SendEMail(string recipient, string subject, string message)
        {

            bool isMessageSent = false;
            //Intialise Parameters
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(clientAddress);
            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(senderAddress, netPassword);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new System.Net.Mail.MailMessage(senderAddress.Trim(), recipient.Trim());
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                //System.Net.Mail.Attachment attachment;
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");
                //mail.Attachments.Add(attachment);

                client.Send(mail);
                isMessageSent = true;
            }
            catch (Exception ex)
            {
                isMessageSent = false;
            }

            return isMessageSent;
        }
        public class SendMailController : ApiController
        {
            [System.Web.Http.HttpPost]
            public async Task<IHttpActionResult> SendEmailNotification(EmailInput data)
            {
                ResponseBase updateResponse = new ResponseBase();
                var updateRequest = new RequestBase<EmailInput>(data);
                try
                {
                    EMailHelper mailHelper = new EMailHelper(EMailHelper.EMAIL_SENDER, EMailHelper.EMAIL_CREDENTIALS, EMailHelper.SMTP_CLIENT);
                    var emailBody = String.Format(EMailHelper.EMAIL_BODY);
                    if (mailHelper.SendEMail(data.EmailId, EMailHelper.EMAIL_SUBJECT, emailBody))
                    {
                        
                    }
                }
                catch (Exception ex)
                {

                }
                return Ok(updateResponse);
            }
        }
    }
}