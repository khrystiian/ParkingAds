using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EmailModels
{
    public class MailLetter
    {
        public MailLetter()
        {
        }
        public string Envelope { get; set; }
        public string Recipient { get; set; }
        public Mime Mime { get; set; }
    }
}
