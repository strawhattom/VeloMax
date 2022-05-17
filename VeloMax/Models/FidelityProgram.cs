using System.Collections.Generic;

namespace VeloMax.Models
{
    public class FidelityProgram
    {
        public string Label { get; set ;}
        public int Cost { get ; set;}
        public int Duration { get; set;}
        public int Discount { get; set;} //TO CHECK

        public static readonly List<string> PROGRAMS = new List<string> { "1", "2", "3", "4"};
        public int Id {get; set;}

        public FidelityProgram(int id, string label, int cost, int duration, int discount)
        {
            if (label is null || !PROGRAMS.Contains(label))
            {
                System.Environment.Exit(0);
            }
            this.Id = id;
            this.Label = label;
            this.Cost = cost;
            this.Duration = duration;
            this.Discount = discount;
        }

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="label";
            attributs[2]="cost";
            attributs[3]="duration";
            attributs[4]="discount";;

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this.Label;
                case 2:
                    return this.Cost.ToString();
                case 3:
                    return this .Duration.ToString();
                case 4:
                    return this.Discount.ToString();
 
                default:
                    return "";
            }    
        }
    }
}
