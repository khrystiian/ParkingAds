using BusinessLogic.EmailImpl;
using BusinessLogic.RabbitMq;
using Models.EmailModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;

namespace BusinessLogic
{
    public class MailImpl
    {
        public void SendMail()
        {            
            #region RabbitMq
            var envelope = new MailLetter();
            var rbImpl = new RabbitMqImpl();
            var connection = RabbitMqService.RabbitMqConnection;
            var channel = RabbitMqService.RabbitMqModel;
            RabbitMqService.SetupInitialTopicQueue(channel);
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                envelope = JsonConvert.DeserializeObject<MailLetter>(message);
               // Thread.Sleep(1000);
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                #region email
                var clientDetails = new SmtpClient
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = new NetworkCredential(envelope.Envelope, "cant give you that")  //2019AdsParking
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(envelope.Mime.From)
                };
                mailMessage.To.Add(envelope.Mime.To);
                mailMessage.Subject = envelope.Mime.Subject;
                mailMessage.Body = envelope.Mime.TextVersion;

                if (envelope.Mime.Attachments.Base64String.Length > 0)
                {
                    var attachement = new Attachment(new MemoryStream(envelope.Mime.Attachments.Base64String), "Receipt.pdf", MediaTypeNames.Application.Pdf);
                    mailMessage.Attachments.Add(attachement);
                }
                try
                {
                    clientDetails.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception caught while sending email: {0}", ex.ToString());
                }
                #endregion
            };
            channel.BasicConsume(RabbitMqService.SerialisationQueueName, autoAck: false, consumer: consumer);
            #endregion
        }
    }
}
