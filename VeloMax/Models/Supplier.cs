using System;

namespace VeloMax.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Siret { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public string Label { get; set; }

        public Supplier()
        {
            Id = 0;
            Siret = Name = Contact = Location = Label = "";
        }
        public Supplier(int id, string siret, string name, string contact, string location, string label)
        {
            if (siret is null || name is null || contact is null || location is null)
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

        public static string[] Attributs()
        {
            string[] attributs = new string[6];
            attributs[0] = "Id";
            attributs[1] = "siret";
            attributs[2] = "name";
            attributs[3] = "contact";
            attributs[4] = "location";
            attributs[5] = "label";


            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.Siret + "'",
                2 => "'" + this.Name.ToString() + "'",
                3 => "'" + this.Contact.ToString() + "'",
                4 => "'" + this.Location.ToString() + "'",
                5 => "'" + this.Label.ToString() + "'",
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "suppliers";
        }


    }
}