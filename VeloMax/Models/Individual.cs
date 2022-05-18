using System;

namespace VeloMax.Models
{
    public class Individual : Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FidelityProgram { get; set; }
        public DateTime expiration_date {get; set;}

        public Individual(int id, string firstName, string lastName, string street, string city, string postalCode, string province, string phone, string mail , int fidelityProgram = 0,  DateTime expirationDate = new DateTime()) : base(id, street, city, postalCode, province, phone, mail)
        {
            
            // if not null args are null
            if (lastName is null || firstName is null)
            {
                System.Environment.Exit(0);
            }
            this.LastName = lastName;
            this.FirstName = firstName;
            this.FidelityProgram = fidelityProgram;
            if(this.FidelityProgram==5)
            {
                expiration_date= new DateTime(0001,1,1);
            }
            else{
                this.expiration_date=expiration_date;
            }
        }

        public override string[] attributs()
        {
            string[] attributs = new string[10];
            attributs[0]="Id";
            attributs[1]="street";
            attributs[2]="city";
            attributs[3]="postalCode";
            attributs[4]="province";
            attributs[5]="phone";
            attributs[6]="mail";
            attributs[7]="first_name";
            attributs[8]="last_name";
            attributs[9]="id_fidelity";
            attributs[10]="expiration_date";


            return attributs;
        }

        public override string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this .Street.ToString();
                case 2:
                    return this.City.ToString();
                case 3:
                    return this.PostalCode.ToString();
                case 4:
                    return this.Province.ToString();
                case 5:
                    return this.Phone;
                case 6:
                    return this .Mail.ToString();
                case 7:
                    return this.FirstName.ToString();
                case 8:
                    return this.LastName;
                case 9:
                    return this.FidelityProgram.ToString();
                case 10:
                    return this.expiration_date.ToString();
                default:
                    return "";
            }    
        }

        public override string typeC()
        {
            return "individuals";
        }
    }
}
