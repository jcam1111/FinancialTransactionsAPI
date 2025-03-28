using test.domain.DTOs.Test.Domain.DTOs;

namespace test.domain.Interfaces
{
    public interface IFinancialTransactionService
    {
        Task<FinancialTransactionDTO> CreateTransactionAsync(FinancialTransactionDTO transactionDto);
        Task<FinancialTransactionDTO> UpdateTransactionAsync(Guid id, FinancialTransactionDTO transactionDto);
        Task<FinancialTransactionDTO> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<FinancialTransactionDTO>> GetTransactionsByStatusAsync(string status);
    }
}
