using BusinessLogic;
using BusinessLogic.EmailImpl;
using Models.EmailModels;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace ConsoleAppToTestBL
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RabbitMqImpl rb = new RabbitMqImpl();
            MailImpl es = new MailImpl();
            while (true)
            {
               rb.AddMessageToQueue();
               rb.GetMessageFromQueue();
               // var e = es.SendMail();
            }
        }
    }
}
