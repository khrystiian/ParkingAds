using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EmailModels
{
        public class Attachments
        {
        public Attachments()
        {
        }

        public Attachments(string name)
        {
            Name = name;
        }
            public string Name { get; set; }
        }
}
