using System;

namespace VeloMax.Models
{
    public class Part{
        private string Description { get; set; }
        private double? UnitPrice { get; set; }
        private DateTime IntroductionDate { get; set;}
        private DateTime DiscontinuationDate{ get; set; }
        private int ProcurementDelay { get; set; }
        private int Quantity { get; set; }
        private string Type { get; set; }

        public Part(string description, double unit_price, DateTime introduction_date, 
        DateTime discontinuation_date, int procurement_delay, int quantity, string type)
        {

            // if not null args are null
            if (description is null || type is null || unit_price is double.NaN)
            {
                System.Environment.Exit(0);
            }

            this.Description = description;
            this.UnitPrice = unit_price;
            this.DiscontinuationDate = discontinuation_date;
            this.IntroductionDate = introduction_date;
            this.ProcurementDelay = procurement_delay;
            this.Quantity = quantity;
            this.Type = type;
        }

    }
}