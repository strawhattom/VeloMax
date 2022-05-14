namespace VeloMax.Models
{
     public class Client
    {
        public string Type { get; set; } //ENUM
        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        //DEFAULT 0
        public int FidelityProgram { get; set; }
        public int OrderCount { get; set; }
        public bool Member { get; set; }

        public Client(string type, string company, string lastName, string firstName, string street, string city, string postalCode, string province, string phone, string mail, int fidelityProgram = 0, bool member = false, int orderCount = 0){
            this.Type = type;
            this.CompanyName = company;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Mail = mail;
            this.FidelityProgram = fidelityProgram;
            this.Member = member;
            this.OrderCount = orderCount;
        }
    }
}
