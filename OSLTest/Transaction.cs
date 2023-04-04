namespace OSLTest
{
    public class Transaction
    {
        public string TransactionId { get; set; } = "12345678";
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; } = 5.00;
        public string Type { get; set; } = "credit";
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
