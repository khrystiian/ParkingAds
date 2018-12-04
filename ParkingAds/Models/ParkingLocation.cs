using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace ParkingAds.Models
{
    [XmlRoot(ElementName = "parkinglocation")]
    public class ParkingLocation
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "is-open")]
        public string Isopen { get; set; }
        [XmlElement(ElementName = "is-payment-active")]
        public string Ispaymentactive { get; set; }
        [XmlElement(ElementName = "status-park-place")]
        public string Statusparkplace { get; set; }
        [XmlElement(ElementName = "longitude")]
        public string Longitude { get; set; }
        [XmlElement(ElementName = "latitude")]
        public string Latitude { get; set; }
        [XmlElement(ElementName = "max-count")]
        public string Maxcount { get; set; }
        [XmlElement(ElementName = "free-count")]
        public string Freecount { get; set; }
    }

    [XmlRoot(ElementName = "parkinglocationlist")]
    public class ParkingLocationList
    {
        [XmlElement(ElementName = "object")]
        public List<Object> Object { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

}