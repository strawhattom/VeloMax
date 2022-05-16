namespace VeloMax.Models
{
    public class Individual : Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FidelityProgram { get; set; }

        public Individual(int id, string firstName, string lastName, string street, string city, string postalCode, string province, string phone, string mail,  int fidelityProgram = 0) : base(id, street, city, postalCode, province, phone, mail)
        {
            
            // if not null args are null
            if (lastName is null || firstName is null)
            {
                System.Environment.Exit(0);
            }
            this.LastName = lastName;
            this.FirstName = firstName;
            this.FidelityProgram = fidelityProgram;
        }
    }
}
