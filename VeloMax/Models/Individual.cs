using System;

namespace VeloMax.Models
{
    public class Individual : Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FidelityProgram { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Individual(int id, string firstName, string lastName, string street, string city, string postalCode, string province, string phone, string mail, int fidelityProgram, DateTime expirationDate) : base(id, street, city, postalCode, province, phone, mail)
        {

            // if not null args are null
            if (lastName is null || firstName is null)
            {
                System.Environment.Exit(0);
            }
            this.LastName = lastName;
            this.FirstName = firstName;
            this.FidelityProgram = fidelityProgram;
            this.ExpirationDate = expirationDate;
        }
        public override string[] Attributs()
        {
            string[] attributs = new string[10];
            attributs[0] = "Id";
            attributs[1] = "street";
            attributs[2] = "city";
            attributs[3] = "postal_code";
            attributs[4] = "province";
            attributs[5] = "phone";
            attributs[6] = "mail";
            attributs[7] = "first_name";
            attributs[8] = "last_name";
            attributs[9] = "id_fidelity";
            attributs[10] = "expiration_date";


            return attributs;
        }

        public override string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.Street.ToString() + "'",
                2 => "'" + this.City.ToString() + "'",
                3 => "'" + this.PostalCode.ToString() + "'",
                4 => "'" + this.Province.ToString() + "'",
                5 => "'" + this.Phone + "'",
                6 => "'" + this.Mail.ToString() + "'",
                7 => "'" + this.FirstName.ToString() + "'",
                8 => "'" + this.LastName + "'",
                9 => this.FidelityProgram.ToString(),
                10 => "'" + this.ExpirationDate.ToString("yyyy-MM-dd") + "'",
                _ => "",
            };
        }

        public override string TypeC()
        {
            return "individuals";
        }
    }
}
