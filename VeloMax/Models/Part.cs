using System;

namespace VeloMax.Models
{
    public class Part
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public DateTime IntroductionDate { get; set; }
        public DateTime DiscontinuationDate { get; set; }
        public int ProcurementDelay { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Part()
        {
            Id = Quantity = ProcurementDelay = 0;
            Description = Type = "";
            IntroductionDate = DiscontinuationDate = DateTime.Now;
        }
        
        public Part(int id, string description, double unit_price, DateTime introduction_date,
        DateTime discontinuation_date, int procurement_delay, int quantity, string type)
        {

            // if not null args are null
            if (description is null || type is null || unit_price is double.NaN)
            {
                System.Environment.Exit(0);
            }

            this.Id = id;
            this.Description = description;
            this.UnitPrice = unit_price;
            this.DiscontinuationDate = discontinuation_date;
            this.IntroductionDate = introduction_date;
            this.ProcurementDelay = procurement_delay;
            this.Quantity = quantity;
            this.Type = type;
        }

        public void SetFields(int id, string description, double unit_price, DateTime introduction_date,
            DateTime discontinuation_date, int procurement_delay, int quantity, string type)
        {
            if (description is null || type is null || unit_price is double.NaN)
            {
                System.Environment.Exit(0);
            }

            this.Id = id;
            this.Description = description;
            this.UnitPrice = unit_price;
            this.DiscontinuationDate = discontinuation_date;
            this.IntroductionDate = introduction_date;
            this.ProcurementDelay = procurement_delay;
            this.Quantity = quantity;
            this.Type = type;
        }

        public static string[] Attributs()
        {
            string[] attributs = new string[8];
            attributs[0] = "Id";
            attributs[1] = "description";
            attributs[2] = "unit_price";
            attributs[3] = "introduction_date";
            attributs[4] = "discontinuation_date";
            attributs[5] = "procurement_delay";
            attributs[6] = "quantity";
            attributs[7] = "type";

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.Description + "'",
                2 => this.UnitPrice.ToString(),
                3 => "'" + this.IntroductionDate.ToString("yyyy-MM-dd") + "'",
                4 => "'" + this.DiscontinuationDate.ToString("yyyy-MM-dd") + "'",
                5 => this.ProcurementDelay.ToString(),
                6 => this.Quantity.ToString(),
                7 => "'" + this.Type + "'",
                _ => "",
            };
        }

        public override string ToString()
        {
            return this.At(0) + ", " + this.At(1);
        }

        public static string TypeC()
        {
            return "parts";
        }


    }
}