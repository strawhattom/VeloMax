using System;

namespace VeloMax.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? Siret { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Location { get; set; }
        public string Label { get; set; }

        public Supplier(int id, string siret, string name, string contact, string location, string label){
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
        
        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="siret";
            attributs[2]="name";
            attributs[3]="contact";
            attributs[4]="location";
            attributs[5]="label";
            

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this.Siret;
                case 2:
                    return this.Name.ToString();
                case 3:
                    return this .Contact.ToString();
                case 4:
                    return this.Location.ToString();
                case 5:
                    return this.Label.ToString();
                default:
                    return null;
            }    
        }


    }
}