using BusinessLogic;
using BusinessLogic.EmailImpl;
using BusinessLogic.RabbitMq;
using Models;
using Models.EmailModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace ConsoleAppToTestBL
{
    class Program
    {
        private static MailLetter deserialized;

        static void Main(string[] args)
        {
            var rbImpl = new RabbitMqImpl();
            using (var connection = RabbitMqService.RabbitMqConnection)
            {
                using (var channel = RabbitMqService.RabbitMqModel)
                {
                    RabbitMqService.SetupInitialTopicQueue(channel);
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        deserialized = JsonConvert.DeserializeObject<MailLetter>(message);
                        Thread.Sleep(1000);

                        Console.WriteLine("have a break " + deserialized.Mime.TextVersion);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(RabbitMqService.SerialisationQueueName,
                                         autoAck: false,
                                         consumer: consumer);

                }
            }
        }
    }
}