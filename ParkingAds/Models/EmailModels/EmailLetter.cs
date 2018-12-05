using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EmailModels
{
    public class EmailLetter
    {
        public EmailLetter()
        {
        }

        public EmailLetter(string envelope, string recipient, Mime mime)
        {
            Envelope = envelope;
            Recipient = recipient;
            Mime = mime;
        }

        public string Envelope { get; set; }
        public string Recipient { get; set; }
        public Mime Mime { get; set; }
    }
}
