using System;

namespace VeloMax.Models
{
     public class Bike
    {
        public string Name { get; set;}
        public string Target { get; set; }
        public double UnitPrice { get; set; }
        public string Type { get; set; } //enum
        public DateTime IntroducedDate { get; set;}
        public DateTime DiscontinuationDate { get; set;}

        public Bike(string name, string target, double unitPrice, string type, DateTime iDate, DateTime dDate)
        {
            this.Name = name;
            this.Target = target;
            this.UnitPrice = unitPrice;
            this.Type = type;
            this.IntroducedDate = iDate;
            this.DiscontinuationDate = dDate;
        }
    }
}