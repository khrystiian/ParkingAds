using BusinessLogic.RabbitMq;
using Models.EmailModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace BusinessLogic.EmailImpl
{
    public class RabbitMqImpl
    {
        public void AddMessageToQueue(string json)
        {
            RabbitMqService commonService = new RabbitMqService();
            var connection = commonService.GetRabbitMqConnection();
            var channel = connection.CreateModel();
            commonService.SetupInitialTopicQueue(channel);
            var basicProperties = channel.CreateBasicProperties();
            basicProperties.DeliveryMode = 2;
            MailImpl es = new MailImpl();
            //var json = "";
            //using (StreamReader r = new StreamReader("C:\\Users\\andyc\\Desktop\\envelope.json"))
            //{
            //    json = r.ReadToEnd();
            //}
            byte[] customerBuffer = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(RabbitMqService.SerialisationExchangeName, RabbitMqService.SerialisationRoutingKey, basicProperties, customerBuffer);
            Thread.Sleep(1000);
            Console.WriteLine("Message added");  //TO DO
        }

        public MailLetter GetMessageFromQueue() //TO DO
        {
            RabbitMqService commonService = new RabbitMqService();
            IConnection connection = commonService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            var deserialized = new MailLetter();

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (custumer, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                deserialized = JsonConvert.DeserializeObject<MailLetter>(message);
                Console.WriteLine("Received popped:  {0} and {1}", deserialized.Mime.TextVersion, deserialized.Recipient);
                Thread.Sleep(1000);
                model.BasicAck(ea.DeliveryTag, false); 
            };
            model.BasicConsume(queue: RabbitMqService.SerialisationQueueName, autoAck: false, consumer: consumer);
            return deserialized;
        }
    }
}
