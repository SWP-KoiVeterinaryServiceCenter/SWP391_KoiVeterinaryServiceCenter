using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAccountScheduleRepository : IGenericRepository<AccountSchedule>
    {
        Task<AccountSchedule?> FindAsync(Guid accountId, Guid scheduleId);
        Task Add(AccountSchedule accountSchedule);
        Task<IEnumerable<AccountSchedule>> GetSchedulesByAccountIdAsync(Guid accountId);
        Task<AccountSchedule?> GetByAccountAndScheduleAsync(Guid accountId, Guid scheduleId);
        Task<IEnumerable<AccountSchedule>> GetAllAsync();
    }
}