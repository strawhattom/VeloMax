using System;

namespace VeloMax.Models
{
    public class Part{

        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public DateTime IntroductionDate { get; set;}
        public DateTime DiscontinuationDate{ get; set; }
        public int ProcurementDelay { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        

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

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="description";
            attributs[2]="unit_price";
            attributs[3]="introduction_date";
            attributs[4]="discontinuation_date";
            attributs[5]="procurement_delay";
            attributs[6]="quantity";
            attributs[7]="type";

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return "'"+this.Description+"'";
                case 2:
                    return this.UnitPrice.ToString();
                case 3:
                    return "'"+this.IntroductionDate.ToString("yyyy-MM-dd")+"'";
                case 4:
                    return "'"+this.DiscontinuationDate.ToString("yyyy-MM-dd")+"'";
                case 5:
                    return this.ProcurementDelay.ToString();
                case 6:
                    return this.Quantity.ToString();
                case 7:
                    return "'"+this.Type+"'"; 
                default:
                    return "";
            }    
        }

        public override string ToString()
        {
            return this.at(0) + ", " + this.at(1);
        }

        public string typeC()
        {
            return "parts";
        }
    

    }
}