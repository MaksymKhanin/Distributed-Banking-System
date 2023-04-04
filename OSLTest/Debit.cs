namespace OSLTest
{
    public class Debit
    {
        public double Amount { get; set; } = 1.00;
        public string? Currency { get; set; } = "ETH";
        public string Description { get; set; } = "Grocery shopping";

    }

    public record SendDebitRequest(double Amount, string Currency, string Description);
}
