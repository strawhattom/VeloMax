using System;

namespace VeloMax.Models
{
    public class Bike
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public double UnitPrice { get; set; }
        public string Type { get; set; } //enum
        public DateTime IntroductionDate { get; set; }
        public DateTime DiscontinuationDate { get; set; }

        public int Id { get; set; }

        public Bike()
        {
            Name = Target = Type = "";
            UnitPrice = 0.0;
            IntroductionDate = DiscontinuationDate = DateTime.Now;
        }

        public Bike(int id, string name, string target, double unitPrice, string type, DateTime iDate, DateTime dDate)
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

        public static string[] Attributs()
        {
            string[] attributs = new string[7];
            attributs[0] = "Id";
            attributs[1] = "name";
            attributs[2] = "target";
            attributs[3] = "unit_price";
            attributs[4] = "type";
            attributs[5] = "introduction_date";
            attributs[6] = "discontinuation_date";

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.Name + "'",
                2 => "'" + this.Target + "'",
                3 => this.UnitPrice.ToString(),
                4 => "'" + this.Type + "'",
                5 => "'" + this.IntroductionDate.ToString("yyyy-MM-dd") + "'",
                6 => "'" + this.DiscontinuationDate.ToString("yyyy-MM-dd") + "'",
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "bikes";
        }
    }
}