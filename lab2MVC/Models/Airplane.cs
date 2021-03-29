using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2MVC.Models
{
    
    public enum Usage
    {
        PASSENGER, TRANSPORT, MILITARY, UNKNOWN
    }
    public class Airplane
    {
        public  Airplane() {}
        public Airplane(String country, String manufacturer, String model, 
            Usage usage, bool isRetired, int introductionYear, String link)
        {
            Country = country;
            Manufacturer = manufacturer;
            Model = model;
            Usage = usage;
            IsRetired = isRetired;
            IntroductionYear = introductionYear;
            Link = link;
        }
        public  String Link { get; set; }
        public String Country { get; set; }
        public String Manufacturer { get; set; }
        public String Model { get; set; }
        public Usage Usage { get; set; }
        public bool IsRetired { get; set; }
        public int IntroductionYear { get; set; }


    }
}
