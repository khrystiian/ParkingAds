using Models.EmailModels;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;

namespace BusinessLogic
{
    public class EmailSetup
    {
        public static bool SendMail(string json)
        {
            var ok = false;
            var envelope = LoadJson(json);
            SmtpClient clientDetails = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential("a.ciobanu19@gmail.com", "password")
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
                // System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(envelope.Mime._Attachment.Name);
                //mailMessage.Attachments.Add(attachment);
            }
            try
            {
                clientDetails.Send(mailMessage); //goes to rabbitmq
                Console.WriteLine("Message sent");

                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while sending email: {0}", ex.ToString());
            }
            return ok;
        }

        private static EmailLetter LoadJson(string json)
        {
            var _jsonDeserialized = JsonConvert.DeserializeObject<EmailLetter>(json);

            var attachment = new Attachments(_jsonDeserialized.Mime.Attachments.Name);
            var mime = new Mime(_jsonDeserialized.Mime.From, _jsonDeserialized.Mime.To, _jsonDeserialized.Mime.Subject, _jsonDeserialized.Mime.TextVersion, attachment);
            var emailLetter = new EmailLetter(_jsonDeserialized.Envelope, _jsonDeserialized.Recipient, mime);

            return emailLetter;
        }
    }
}
