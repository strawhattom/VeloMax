using System;

namespace VeloMax.Models
{
    public class Part{
        private string SupplierName{ get; set; }
        private string Description { get; set; }
        private float UnitPrice { get; set; }
        private DateTime IntroductionDate { get; set;}
        private DateTime DiscontinuationDate{ get; set; }
        private int ProcurementDelay { get; set; }
        private int Quantity { get; set; }

        public Part(string supplier_name, string description, float unit_price, DateTime introduction_date, 
        DateTime discontinuation_date, int procurement_delay, int quantity)
        {
            this.Supplier_name = supplier_name;
            this.Description = description;
            this.UnitPrice = unit_price;
            this.DiscontinuationDate = discontinuation_date;
            this.IntroductionDate = introduction_date;
            this.ProcurementDelay = procurement_delay;
            this.Quantity = quantity;
        }

    }
}