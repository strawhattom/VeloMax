using System;

namespace VeloMax.Models
{
    public class Bike
    {
        public string Name { get; set;}
        public string Target { get; set; }
        public double UnitPrice { get; set; }
        public string Type { get; set; } //enum
        public DateTime IntroductionDate { get; set;}
        public DateTime DiscontinuationDate { get; set;}

        public int Id {get; set;}

        public Bike(int id,string name, string target, double unitPrice, string type, DateTime iDate, DateTime dDate)
        {
            // if args are null
            if (name is null || target is null || unitPrice is double.NaN || type is null)
            {
                System.Environment.Exit(0);
            }
            this.Id = id;
            this.Name = name;
            this.Target = target;
            this.UnitPrice = unitPrice;
            this.Type = type;
            this.IntroductionDate = iDate;
            this.DiscontinuationDate = dDate;
        }

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="name";
            attributs[2]="target";
            attributs[3]="unit_price";
            attributs[4]="type";
            attributs[5]="introduction_date";
            attributs[6]="discontinuation_date";

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return "'"+this.Name+"'";
                case 2:
                    return "'"+this.Target+"'";
                case 3:
                    return this.UnitPrice.ToString();
                case 4:
                    return "'"+this.Type+"'";
                case 5:
                    return "'"+this.IntroductionDate.ToString("yyyy-MM-dd")+"'";
                case 6:
                    return "'"+this.DiscontinuationDate.ToString("yyyy_MM_dd")+"'"; 
                default:
                    return "";
            }    
        }
    }
}