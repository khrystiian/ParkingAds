using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EmailModels
{
    public class Mime
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string TextVersion { get; set; }
        public Attachments Attachments { get; set; }
    }
}
