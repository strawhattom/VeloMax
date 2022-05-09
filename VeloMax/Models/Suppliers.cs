using System;

namespace VeloMax.Models
{
    public class Supplier
    {
        public string Siret { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public int Label { get; set; }

        public Supplier(string siret, string name, string contact, string location, int label){
            this.Siret = siret;
            this.Name = name;
            this.Contact = contact;
            this.Location =location;
            if (label >= 4 && label <= 1){
                this.Label = label;
            }   
        }
        

    }
}