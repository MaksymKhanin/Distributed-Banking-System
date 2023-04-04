namespace OSLTest
{
    public class Credit
    {
        public double Amount { get; set; } = 1.00;
        public string? Currency { get; set; } = "ETH";
        public string Description { get; set; } = "Grocery shopping";
    }
    public record SendCreditRequest(double Amount, string Currency, string Description);
}
