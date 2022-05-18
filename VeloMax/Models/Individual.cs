using System;

namespace VeloMax.Models
{
    public class Individual : Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FidelityProgram { get; set; }
        public DateTime expiration_date {get; set;}

        public Individual(int id, string firstName, string lastName, string street, string city, string postalCode, string province, string phone, string mail, DateTime expirationDate , int fidelityProgram = 0) : base(id, street, city, postalCode, province, phone, mail)
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

        public string[] attributs()
        {
            string[] attributs = new string[10];
            attributs[0]="Id";
            attributs[1]="first_name";
            attributs[2]="last_name";
            attributs[3]="street";
            attributs[4]="city";
            attributs[5]="postalCode";
            attributs[6]="province";
            attributs[7]="phone";
            attributs[8]="mail";
            attributs[9]="id_fidelity";
            attributs[10]="expiration_date";


            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this.FirstName.ToString();
                case 2:
                    return this.LastName;
                case 3:
                    return this .Street.ToString();
                case 4:
                    return this.City.ToString();
                case 5:
                    return this.PostalCode.ToString();
                case 6:
                    return this.Province.ToString();
                case 7:
                    return this.Phone;
                case 8:
                    return this .Mail.ToString();
                case 9:
                    return this.FidelityProgram.ToString();
                case 10:
                    return this.expiration_date.ToString();
                default:
                    return "";
            }    
        }
    }
}
