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


        public FidelityProgram(string label, int cost, int duration, int discount)
        {
            if (label is null || !PROGRAMS.Contains(label))
            {
                System.Environment.Exit(0);
            }
            this.Label = label;
            this.Cost = cost;
            this.Duration = duration;
            this.Discount = discount;
        }
    }
}
