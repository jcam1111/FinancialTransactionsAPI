using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using test.domain.Entities;
using test.domain.Interfaces;

namespace test.infrastructure.Repositories
{
    public class TransactionMongoRepository : IFinancialTransactionRepository
    {
        private readonly IMongoCollection<FinancialTransaction> _transactionCollection;

        public TransactionMongoRepository(IMongoDatabase database)
        {
            _transactionCollection = database.GetCollection<FinancialTransaction>("Transactions");
        }

        public async Task<FinancialTransaction> GetTransactionByIdAsync(Guid id)
        {
            return await _transactionCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FinancialTransaction>> GetTransactionsByStatusAsync(string status)
        {
            return await _transactionCollection.Find(t => t.Status == status).ToListAsync();
        }

        public async Task AddTransactionAsync(FinancialTransaction transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction);
        }

        public async Task UpdateTransactionAsync(FinancialTransaction transaction)
        {
            await _transactionCollection.ReplaceOneAsync(t => t.Id == transaction.Id, transaction);
        }
    }
}
