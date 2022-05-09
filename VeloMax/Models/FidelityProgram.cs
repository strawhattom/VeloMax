namespace VeloMax.Models
{
    public class FidelityProgram
    {
        public string Label { get; set ;}
        public int Cost { get ; set;}
        public int Duration { get; set;}
        public int Discount { get; set;} //TO CHECK
    

    public FidelityProgram(string label, int cost, int duration, int discount)
    {
        this.Label = label;
        this.Cost = cost;
        this.Duration = duration;
        this.Discount = discount;
    }
    }
}
