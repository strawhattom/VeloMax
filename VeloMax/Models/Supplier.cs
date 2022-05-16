using System;

namespace VeloMax.Models
{
    public class Supplier
    {
        public string? Siret { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Location { get; set; }
        public int Label { get; set; }
        public int Id {get; set;}

        public Supplier(int id, string siret, string name, string contact, string location, int label){
            if (siret is null || name is null || contact is null | location is null)
            {
                Console.WriteLine("ERROR : at least one arg is null");
                System.Environment.Exit(0);
            }
            if (!FidelityProgram.PROGRAMS.Contains(label.ToString()))
            {
                Console.WriteLine("ERROR : incorrect label in enum (1,2,3,4)");
                System.Environment.Exit(0);
            }
            this.Id = id;
            this.Siret = siret;
            this.Name = name;
            this.Contact = contact;
            this.Location = location;
            this.Label = label;
        }
        

    }
}