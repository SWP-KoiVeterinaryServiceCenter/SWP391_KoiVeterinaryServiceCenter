using Application.IRepository;
using Application.IService.Common;
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

        public async Task<Account> FindAccountByEmail(string email)
        {
           return await _appDbContext.Accounts.Where(x=>x.Email==email).Include(x=>x.Role).SingleOrDefaultAsync();  
        }
    }
}
