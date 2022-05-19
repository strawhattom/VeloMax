namespace VeloMax.Models
{
    public class Professional : Client
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public int OrderCount { get; set; }

        public Professional() : base()
        {
            CompanyName = ContactName = "";
            OrderCount = 0;
        }
        public Professional(int id, string companyName, string contact, string street, string city, string postalCode, string province, string phone, string mail, int orderCount = 0) : base(id, street, city, postalCode, province, phone, mail)
        {
            // if not null args are null
            if (companyName is null || contact is null)
            {
                System.Environment.Exit(0);
            }

            this.Type = "Professional";
            this.CompanyName = companyName;
            this.ContactName = contact;
            this.OrderCount = orderCount;
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
            attributs[7] = "company_name";
            attributs[8] = "contact_name";
            attributs[9] = "order_count";

            return attributs;
        }

        public override string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => '"' + this.Street.ToString() + '"',
                2 => '"' + this.City.ToString() + '"',
                3 => "'" + this.PostalCode.ToString() + "'",
                4 => '"' + this.Province.ToString() + '"',
                5 => "'" + this.Phone + "'",
                6 => "'" + this.Mail.ToString() + "'",
                7 => '"' + this.CompanyName.ToString() + '"',
                8 => '"' + this.ContactName + '"',
                9 => this.OrderCount.ToString(),
                _ => "",
            };
        }

        public override string TypeC()
        {
            return "professionals";
        }
    }
}