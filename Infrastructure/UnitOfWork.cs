using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.IRepository;
using Infrastructure.Repository;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
        }

        public IAccountRepository AccountRepository =>_accountRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
