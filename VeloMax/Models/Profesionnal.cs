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
    }
}
