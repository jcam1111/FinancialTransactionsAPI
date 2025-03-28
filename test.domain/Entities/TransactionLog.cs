namespace test.domain.Entities
{
    public class TransactionLog
    {
        public Guid Id { get; set; }
        public string TransactionId { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Observaciones { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string Usuario { get; set; }
        public string IPAddress { get; set; }
    }

}
