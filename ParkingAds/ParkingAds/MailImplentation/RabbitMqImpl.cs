using BusinessLogic.RabbitMq;
using Models;
using Models.EmailModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace BusinessLogic.EmailImpl
{
    public class RabbitMqImpl
    {
        public void AddMessageToQueue(Payment payment)
        {
            var mImpl = new MailImpl();
            var connection = RabbitMqService.RabbitMqConnection;
            var channel = RabbitMqService.RabbitMqModel;
            RabbitMqService.SetupInitialTopicQueue(channel);
            var basicProperties = channel.CreateBasicProperties();
            basicProperties.DeliveryMode = 2;
            var envelope = new MailLetter
            {
                Envelope = "ParkingAds A/S", //to be replaced with customer email   //parkingads2019@gmail.com
                Recipient = "Customer",      //to be replaced           
                Mime = new Mime
                {
                    From = "a.ciobanu19@gmail.com",
                    To = "kristi_c41@yahoo.com",
                    Subject = "Receipt payment: ", // complete email subject with payment details
                    TextVersion = "Dear customer, "
                     + Environment.NewLine + Environment.NewLine + "Your payment receipment issued "
                     + DateTime.Now + " is attached above. " + Environment.NewLine +
                     "Thank you for your doing business with us ! ", //add payment details
                    Attachments = new Attachments
                    {
                        Base64String = payment.Base64Receipt
                    }
                }
            };
            byte[] customerBuffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(envelope));
            channel.BasicPublish(RabbitMqService.SerialisationExchangeName, RabbitMqService.SerialisationRoutingKey, basicProperties, customerBuffer);
            mImpl.SendMail();
        }
    }
    
}

