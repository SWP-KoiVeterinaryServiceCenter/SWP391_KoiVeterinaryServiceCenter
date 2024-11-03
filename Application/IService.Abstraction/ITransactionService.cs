using Application.Model.TransactionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public  interface ITransactionService
    {
        Task<List<ListTransactionViewModel>> GetAllTransaction();
    }
}
