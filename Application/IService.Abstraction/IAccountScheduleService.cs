using Application.Model.AccountSchedule;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IAccountScheduleService
    {
        Task AddAccountToScheduleAsync(AddAccountScheduleRequest addAccountScheduleRequest);
        Task<IEnumerable<AccountScheduleResponse>> GetSchedulesByAccountIdAsync(Guid accountId);
        Task<AccountScheduleResponse?> GetAccountScheduleByIdAsync(Guid accountId, Guid scheduleId);
        Task UpdateAccountScheduleAsync(Guid accountId, Guid scheduleId, UpdateAccountScheduleRequest request);
        Task DeleteAccountScheduleAsync(Guid accountId, Guid scheduleId);
        Task<IEnumerable<AccountScheduleResponse>> GetAllAccountSchedulesAsync();
    }
}