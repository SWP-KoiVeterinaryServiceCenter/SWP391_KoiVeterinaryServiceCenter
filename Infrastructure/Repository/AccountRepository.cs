using Application.IRepository;
using Application.IService.Common;
using Application.Model.AccountModel;
using Application.Model.KoiModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CustomerAccountAmount()
        {
            return await _appDbContext.Accounts.Where(x=>x.RoleId==4).CountAsync();
        }

        public async Task<Account> FindAccountByEmail(string email)
        {
           return await _appDbContext.Accounts.Where(x=>x.Email==email).Include(x=>x.Role).SingleOrDefaultAsync();  
        }

        public async Task<AccountDetailViewModel> GetAccountDetail(Guid accountId)
        {
            var accountDetail=await _appDbContext.Accounts.Where(x=>x.Id==accountId)
                                                          .Select(x=>new AccountDetailViewModel
                                                          {
                                                              Email=x.Email,
                                                              Location=x.Location,
                                                              PhoneNumber=x.Phonenumber,
                                                              Username=x.Username,
                                                              OwnedKoi= _appDbContext.Kois.Where(koi=>koi.AccountId== accountId)
                                                                                          .Select(koi=>new KoiOwner
                                                                                          {
                                                                                              Age=koi.Age,
                                                                                              Gender=koi.Gender,
                                                                                              KoiName=koi.KoiName,
                                                                                              Varieties= koi.Varieties,
                                                                                              Weight = koi.Weight
                                                                                          }).Single()
                                                          }).SingleOrDefaultAsync();
            return accountDetail;
        }

        public async Task<List<Account>> GetAllAccountsForAdmin()
        {
           return await _appDbContext.Accounts.Where(x=>x.RoleId!=1).Include(x=>x.Role).ToListAsync();
        }

        public async Task<List<Account>> GetAllVeterinaryAccounts()
        {
            return await _appDbContext.Accounts.Where(x => x.RoleId == 3).Include(x => x.Role).ToListAsync();
        }

        public async Task<Account> GetBannedAccount(Guid accountId)
        {
            return await _appDbContext.Accounts.Where(x => x.Id == accountId && x.IsDelete == true).SingleOrDefaultAsync();
        }

        public async Task<int> StaffAccountAmount()
        {
            return await _appDbContext.Accounts.Where(x => x.RoleId == 2&&x.IsDelete==false).CountAsync();
        }

        public async Task<int> VeterinaryAccountAmount()
        {
            return await _appDbContext.Accounts.Where(x => x.RoleId == 3&&x.IsDelete==false).CountAsync();
        }
    }
}
