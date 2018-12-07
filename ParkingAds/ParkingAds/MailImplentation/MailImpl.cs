using BusinessLogic.EmailImpl;
using Models.EmailModels;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;

namespace BusinessLogic
{
    public class MailImpl
    {
        public bool SendMail()
        {
            var ok = false;
            RabbitMqImpl rbImpl = new RabbitMqImpl();

            var envelope = rbImpl.GetMessageFromQueue();
            SmtpClient clientDetails = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential("a.ciobanu19@gmail.com", "pwd")
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("a.ciobanu19@gmail.com")
            };
            mailMessage.To.Add(envelope.Mime.To);
            mailMessage.Subject = envelope.Mime.Subject;
            mailMessage.Body = envelope.Mime.TextVersion;


            if (envelope.Mime.Attachments.Name.Length > 0)
            {
                Attachment attachment = new Attachment(envelope.Mime.Attachments.Name);
                mailMessage.Attachments.Add(attachment);
            }
            try
            {
                clientDetails.Send(mailMessage);
                ok = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception caught while sending email: {0}", ex.ToString());
            }
            return ok;
        }

        public MailLetter LoadJson(string json)
        {
            var _jsonDeserialized = JsonConvert.DeserializeObject<MailLetter>(json);
            var attachment = new Attachments(_jsonDeserialized.Mime.Attachments.Name);
            var mime = new Mime(_jsonDeserialized.Mime.From, _jsonDeserialized.Mime.To, _jsonDeserialized.Mime.Subject, _jsonDeserialized.Mime.TextVersion, attachment);
            var emailLetter = new MailLetter(_jsonDeserialized.Envelope, _jsonDeserialized.Recipient, mime);

            return emailLetter;
        }
    }
}
