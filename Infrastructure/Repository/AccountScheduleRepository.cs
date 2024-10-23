using Application.IRepository;
using Application.IService.Common;
using Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountScheduleRepository : GenericRepository<AccountSchedule>, IAccountScheduleRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountScheduleRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AccountSchedule?> FindAsync(Guid accountId, Guid scheduleId)
        {
            return await _appDbContext.AccountSchedules
                .Include(x => x.WorkingSchedule)
                .FirstOrDefaultAsync(x => x.AccountId == accountId && x.ScheduleId == scheduleId);
        }

        public async Task<IEnumerable<AccountSchedule>> GetSchedulesByAccountIdAsync(Guid accountId)
        {
            return await _appDbContext.AccountSchedules
                    .Include(x => x.WorkingSchedule)
                    .Where(x => x.AccountId == accountId)
                    .ToListAsync();
        }

        public Task<AccountSchedule?> GetByAccountAndScheduleAsync(Guid accountId, Guid scheduleId)
        {
            return _appDbContext.AccountSchedules
                .Include(x => x.WorkingSchedule)
                .FirstOrDefaultAsync(x => x.AccountId == accountId && x.ScheduleId == scheduleId);
        }

        public async Task Add(AccountSchedule accountSchedule)
        {
            await _appDbContext.AccountSchedules.AddAsync(accountSchedule);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AccountSchedule>> GetAllAsync()
        {
            return await _appDbContext.AccountSchedules
                .Include(x => x.WorkingSchedule)
                .ToListAsync();
        }
    }
}