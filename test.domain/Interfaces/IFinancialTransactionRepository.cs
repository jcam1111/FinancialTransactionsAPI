using test.domain.Entities;

namespace test.domain.Interfaces
{
    public interface IFinancialTransactionRepository
    {
        Task<FinancialTransaction> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<FinancialTransaction>> GetTransactionsByStatusAsync(string status);
        Task AddTransactionAsync(FinancialTransaction transaction);
        Task UpdateTransactionAsync(FinancialTransaction transaction);
    }
}
