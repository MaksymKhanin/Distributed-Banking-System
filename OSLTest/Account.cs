using System.Security.Principal;

namespace OSLTest
{
    public class Account
    {
        public string AccountId { get; set; } = "123456789";
        public string? AccountType { get; set; } = "savings";
        public double Balance { get; set; } = 1500.00;
        public string? Currency { get; set; } = "USD";
        public AccountHolder AccountHolder { get; set; } = new AccountHolder();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

    public class AccountHolder
    {
        public string Name { get; set; } = "123456789";
        public string? Email { get; set; } = "savings";
        public Address Address { get; set; } = new Address();
        public string? PhoneNumber { get; set; } = "555-555-5555";

    }

    public class Address
    {
        public string Line1 { get; set; } = "123 Main St.";
        public string? Line2 { get; set; } = "";
        public string? City { get; set; } = "Anytown";
        public string? State { get; set; } = "CA";
        public string? ZipCode { get; set; } = "12345";
        public string? Country { get; set; } = "USA";
    }


    enum Currencies
    {
        USD = 0,
        EUR = 1,
        HKD = 2
    };
}
