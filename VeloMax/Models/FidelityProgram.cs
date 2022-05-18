using System.Collections.Generic;

namespace VeloMax.Models
{
    public class FidelityProgram
    {
        public string Label { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        public int Discount { get; set; } //TO CHECK

        public static readonly List<string> PROGRAMS = new() { "1", "2", "3", "4" };
        public int Id { get; set; }

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

        public static string[] Attributs()
        {
            string[] attributs = new string[5];
            attributs[0] = "Id";
            attributs[1] = "label";
            attributs[2] = "cost";
            attributs[3] = "duration";
            attributs[4] = "discount"; ;

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.Label + "'",
                2 => this.Cost.ToString(),
                3 => this.Duration.ToString(),
                4 => this.Discount.ToString(),
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "fidelity_programs";
        }
    }

}