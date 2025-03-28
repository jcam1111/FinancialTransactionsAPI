using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using test.domain.DTOs.Test.Domain.DTOs;
using test.domain.Entities;
using test.domain.Interfaces;

namespace test.application.Services
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _transactionRepository;

        public FinancialTransactionService(IFinancialTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<FinancialTransactionDTO> CreateTransactionAsync(FinancialTransactionDTO transactionDto)
        {
            var transaction = new FinancialTransaction
            {
                Id = Guid.NewGuid(),
                Amount = transactionDto.Amount,
                Currency = transactionDto.Currency,
                Date = DateTime.UtcNow,
                Status = transactionDto.Status
            };

            await _transactionRepository.AddTransactionAsync(transaction);
            return transactionDto;
        }

        public async Task<FinancialTransactionDTO> UpdateTransactionAsync(Guid id, FinancialTransactionDTO transactionDto)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(id);
            if (transaction == null)
                throw new Exception("Transaction not found");

            transaction.Amount = transactionDto.Amount;
            transaction.Currency = transactionDto.Currency;
            transaction.Status = transactionDto.Status;

            await _transactionRepository.UpdateTransactionAsync(transaction);
            return transactionDto;
        }

        public async Task<FinancialTransactionDTO> GetTransactionByIdAsync(Guid id)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(id);
            if (transaction == null)
                return null;

            return new FinancialTransactionDTO
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Currency = transaction.Currency,
                Date = transaction.Date,
                Status = transaction.Status
            };
        }

        public async Task<IEnumerable<FinancialTransactionDTO>> GetTransactionsByStatusAsync(string status)
        {
            var transactions = await _transactionRepository.GetTransactionsByStatusAsync(status);
            return transactions.Select(t => new FinancialTransactionDTO
            {
                Id = t.Id,
                Amount = t.Amount,
                Currency = t.Currency,
                Date = t.Date,
                Status = t.Status
            });
        }
    }
}
