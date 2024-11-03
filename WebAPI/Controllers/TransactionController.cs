using Application.IService.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TransactionController :BaseController
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<IActionResult> Transactions()
        {
            var listTransaction=await _transactionService.GetAllTransaction();
            return Ok(listTransaction);
        }
    }
}
