using Application.IService.Abstraction;
using Application.Model.TransactionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ListTransactionViewModel>> GetAllTransaction()
        {
            var listTransaction = await _unitOfWork.TransactionRepository.GetAllAsync();
            var listTransactionViewModel =listTransaction.Select(x=>new ListTransactionViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Description = x.Description,
                CreationDate=DateOnly.FromDateTime(x.CreationDate.Value),
                CreationTime=TimeOnly.FromDateTime(x.CreationDate.Value)
            }).ToList();
            return listTransactionViewModel;
        }
    }
}
