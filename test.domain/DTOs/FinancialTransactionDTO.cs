namespace test.domain.DTOs
{
    namespace Test.Domain.DTOs
    {
        public class FinancialTransactionDTO
        {
            public Guid Id { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }
    }

}
