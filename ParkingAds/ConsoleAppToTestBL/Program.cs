using BusinessLogic;
using BusinessLogic.EmailImpl;
using BusinessLogic.RabbitMq;
using Models;
using Models.EmailModels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace ConsoleAppToTestBL
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateBccTestMessage();
        }

        public static void CreateBccTestMessage()
        {
            MailAddress from = new MailAddress("a.ciobanu19@gmail.com", "sender");
            MailAddress to = new MailAddress("kristi_c41@yahoo.com", "receiver");
            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Using the SmtpClient class.",
                Body = @"Using this feature, you can send an email message from an application very easily."
            };
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential("a.ciobanu19@gmail.com", "bla bla")
            };
            Console.WriteLine("Sending an email message from {0} to {1}.", from.DisplayName,
                to.DisplayName);
            Console.ReadLine();
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}",
                            ex.ToString());
                Console.ReadLine();

            }
        }
    }
}