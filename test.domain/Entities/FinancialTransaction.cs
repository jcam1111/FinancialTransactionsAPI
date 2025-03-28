namespace test.domain.Entities
{
    public class FinancialTransaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
