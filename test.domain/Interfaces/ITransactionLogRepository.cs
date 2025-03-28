using test.domain.Entities;

namespace test.domain.Interfaces
{
    public interface ITransactionLogRepository
    {
        Task InsertLogAsync(TransactionLog log);
    }

}
