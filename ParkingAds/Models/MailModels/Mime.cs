using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EmailModels
{
    public class Mime
    {
        public Mime()
        {
        }

        public Mime(string from, string to, string subject, string textVersion, Attachments attachments)
        {
            From = from;
            To = to;
            Subject = subject;
            TextVersion = textVersion;
            Attachments = attachments;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string TextVersion { get; set; }
        public Attachments Attachments { get; set; }
    }
}
