using System;

namespace velomax_class
{
    public class Parts{
        private string Supplier_name{get; set;}
        private string Description{get; set;}
        private float Unit_price{get; set;}
        private DateTime Introduction_date{get; set;}
        private DateTime Discontinuation_date{get; set;}
        private int Procurement_delay{get; set;}
        private int Quantity{get; set;}

        public Parts(string supplier_name, string description, float unit_price, DateTime introduction_date, 
        DateTime discontinuation_date, int procurement_delay, int quantity)
        {
            this.Supplier_name = supplier_name;
            this.Description=description;
            this.Unit_price=unit_price;
            this.Discontinuation_date=discontinuation_date;
            this.Introduction_date=introduction_date;
            this.Procurement_delay=procurement_delay;
            this.Quantity=quantity;
        }

    }
}