using Application.Model.AccountModel;
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
        Task<AccountDetailViewModel> GetAccountDetail(Guid accountId);
        Task<int> VeterinaryAccountAmount();
        Task<int> StaffAccountAmount();
        Task<int> CustomerAccountAmount();
        Task<List<Account>> GetAllVeterinaryAccounts();
        Task<List<Account>> GetAllVeterinaryAccountsForAppointment();
    }
}
