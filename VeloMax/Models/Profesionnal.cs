namespace VeloMax.Models
{
    public class Professional : Client
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public int OrderCount { get; set; }

        public Professional(int id, string companyName, string contact, string street, string city, string postalCode, string province, string phone, string mail,  int orderCount = 0) : base(id, street, city, postalCode, province, phone, mail)
        {
            
            // if not null args are null
            if (companyName is null || contact is null)
            {
                System.Environment.Exit(0);
            }
            this.CompanyName = companyName;
            this.ContactName = contact;
            this.OrderCount = orderCount;
        }

        public override string[] attributs()
        {
            string[] attributs = new string[10];
            attributs[0]="Id";
            attributs[1]="street";
            attributs[2]="city";
            attributs[3]="postal";
            attributs[4]="province";
            attributs[5]="phone";
            attributs[6]="mail";
            attributs[7]="company_name";
            attributs[8]="contact_name";
            attributs[9]="order_count";

            return attributs;
        }

        public override string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return "'"+this.Street.ToString()+"'";
                case 2:
                    return "'"+this.City.ToString()+"'";
                case 3:
                    return "'"+this.PostalCode.ToString()+"'";
                case 4:
                    return "'"+this.Province.ToString()+"'";
                case 5:
                    return "'"+this.Phone+"'";
                case 6:
                    return "'"+this.Mail.ToString()+"'";
                case 7:
                    return "'"+this.CompanyName.ToString()+"'";
                case 8:
                    return "'"+this.ContactName+"'";
                case 9:
                    return this.OrderCount.ToString();
                default:
                    return "";
            }    
        }

        public override string typeC()
        {
            return "professionals";
        }
    }
}
