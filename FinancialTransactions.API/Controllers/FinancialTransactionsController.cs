using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace FinancialTransactions.API.Controllers
{
    //public class TransactionsController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    using Microsoft.AspNetCore.Mvc;
    using test.domain.DTOs.Test.Domain.DTOs;
    using test.domain.Interfaces;
    using test.application.Services;
    using test.domain.DTOs;
    using test.domain.Entities;
    using test.infrastructure.Repositories;

    namespace FinancialTransactions.API.Controllers
    {
        /// <summary>
        /// Controlador para manejar las transacciones financieras.
        /// </summary>
        [Route("api/[controller]")]
        [ApiController]
        public class FinancialTransactionsController : ControllerBase
        {
            private readonly IFinancialTransactionService _transactionService;
            private readonly ITransactionLogRepository _transactionLogRepository;

            public FinancialTransactionsController(IFinancialTransactionService transactionService,
                ITransactionLogRepository transactionLogRepository)
            {
                _transactionService = transactionService;
                _transactionLogRepository = transactionLogRepository;
            }

            /// <summary>
            /// Crea una nueva transacción financiera.
            /// </summary>
            /// <param name="transactionDto">Objeto que contiene los detalles de la transacción.</param>
            /// <returns>Retorna el DTO de la transacción creada.</returns>
            /// <response code="200">La transacción fue creada exitosamente.</response>
            /// <response code="400">Si hay un error de validación en los datos proporcionados.</response>

            [HttpPost]
            public async Task<IActionResult> CreateTransaction([FromBody] FinancialTransactionDTO transactionDto)
            {
                var transaction = await _transactionService.CreateTransactionAsync(transactionDto);

                // Insertar log
                var log = new TransactionLog
                {
                    Id = Guid.NewGuid(),
                    TransactionId = transaction.Id.ToString(),
                    Action = "Create",
                    Amount = transaction.Amount.ToString(),
                    Currency = transaction.Currency,
                    Status = transaction.Status,
                    Usuario = User.Identity.Name,  // El nombre del usuario que hace la solicitud
                    IPAddress = HttpContext.Connection.RemoteIpAddress.ToString()
                };
                await _transactionLogRepository.InsertLogAsync(log);
                return Ok(transaction);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTransaction(Guid id, [FromBody] FinancialTransactionDTO transactionDto)
            {
                var transaction = await _transactionService.UpdateTransactionAsync(id, transactionDto);
                // Insertar log
                var log = new TransactionLog
                {
                    Id = Guid.NewGuid(),
                    TransactionId = transaction.Id.ToString(),
                    Action = "Edit",
                    Amount = transaction.Amount.ToString(),
                    Currency = transaction.Currency,
                    Status = transaction.Status,
                    Usuario = User.Identity.Name,  // El nombre del usuario que hace la solicitud
                    IPAddress = HttpContext.Connection.RemoteIpAddress.ToString()
                };
                await _transactionLogRepository.InsertLogAsync(log);
                return Ok(transaction);
            }


            /// <summary>
            /// Obtiene una transacción por su ID.
            /// </summary>
            /// <param name="id">ID de la transacción.</param>
            /// <returns>Retorna la transacción con el ID especificado.</returns>
            /// <response code="200">La transacción fue encontrada.</response>
            /// <response code="404">Si no se encuentra la transacción con ese ID.</response>
            [HttpGet("{id}")]
            public async Task<IActionResult> GetTransactionById(Guid id)
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(id);
                // Insertar log
                var log = new TransactionLog
                {
                    Id = Guid.NewGuid(),
                    TransactionId = transaction.Id.ToString(),
                    Action = "GetById",
                    Amount = transaction.Amount.ToString(),
                    Currency = transaction.Currency,
                    Status = transaction.Status,
                    Usuario = User.Identity.Name,  // El nombre del usuario que hace la solicitud
                    IPAddress = HttpContext.Connection.RemoteIpAddress.ToString()
                };
                await _transactionLogRepository.InsertLogAsync(log);

                return transaction == null ? NotFound() : Ok(transaction);
            }

            [HttpGet("status/{status}")]
            public async Task<IActionResult> GetTransactionsByStatus(string status)
            {
                var transactions = await _transactionService.GetTransactionsByStatusAsync(status);
                return Ok(transactions);
            }
        }
    }

}
