using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAccountRepository:IGenericRepository<Account>
    {
        Task<Account> FindAccountByEmail(string email);
        Task<List<Account>> GetAllAccountsForAdmin();
        Task<Account> GetBannedAccount(Guid accountId);
    }
}
