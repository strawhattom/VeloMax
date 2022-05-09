using System;

namespace velomax_class
{
    public class Suppliers
    {
        public string Siret{get; set;}
        public string Name{get; set;}
        public string Contact{get; set;}
        public string Location{get; set;}
        public int Label{get; set;}

        public Suppliers(string siret, string name, string contact, string location, int label){
            this.Siret=siret;
            this.Name=name;
            this.Contact=contact;
            this.Location=location;
            if(label>=4 && label<=1){
                this.Label=label;
            }   
        }
        

    }
}