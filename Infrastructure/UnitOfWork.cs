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
        private readonly IKoiRepository _koiRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository, IKoiRepository koiRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _koiRepository = koiRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IKoiRepository KoiRepository => _koiRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
