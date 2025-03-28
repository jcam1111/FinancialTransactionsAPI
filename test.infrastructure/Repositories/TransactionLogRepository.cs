using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.domain.Entities;
using test.domain.Interfaces;

namespace test.infrastructure.Repositories
{
    public class TransactionLogRepository : ITransactionLogRepository
    {
        private readonly string _connectionString;

        public TransactionLogRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        public async Task InsertLogAsync(TransactionLog log)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO TransactionLogs
                          (Id, TransactionId, Action, Date, Observaciones, Amount, Currency, Status, Usuario, IPAddress)
                          VALUES (@Id, @TransactionId, @Action, @Date, @Observaciones, @Amount, @Currency, @Status, @Usuario, @IPAddress)";

                var parameters = new
                {
                    Id = log.Id,
                    TransactionId = log.TransactionId,
                    Action = log.Action,
                    Date = log.Date,
                    Observaciones = log.Observaciones,
                    Amount = log.Amount,
                    Currency = log.Currency,
                    Status = log.Status,
                    Usuario = log.Usuario,
                    IPAddress = log.IPAddress
                };

                await connection.ExecuteAsync(query, parameters);
            }
        }
    }

}
