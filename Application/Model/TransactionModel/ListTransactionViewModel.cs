using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.TransactionModel
{
    public class ListTransactionViewModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public TimeOnly CreationTime { get; set; }
    }
}
