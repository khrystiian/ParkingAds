using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [XmlRoot(ElementName = "Ad", Namespace = "http://schemas.datacontract.org/2004/07/PSUNCAdService.Models")]
    public class Ad
    {
        [XmlElement(ElementName = "ImageData", Namespace = "http://schemas.datacontract.org/2004/07/PSUNCAdService.Models")]
        public string ImageData { get; set; }
        [XmlAttribute(AttributeName = "i", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string I { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        public DateTime TimeStamp { get; set; }
    }

}
