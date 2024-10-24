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
        Task<AccountScheduleResponse> AddAccountToScheduleAsync(AddAccountScheduleRequest addAccountScheduleRequest);
        Task<IEnumerable<AccountScheduleResponse>> GetSchedulesByAccountIdAsync(Guid accountId);
        Task<AccountScheduleResponse?> GetAccountScheduleByIdAsync(Guid id);
        Task<IEnumerable<AccountScheduleResponse>> GetAccountScheduleByCurrentUserAsync();
        Task<AccountScheduleResponse> UpdateAccountScheduleAsync(Guid id, UpdateAccountScheduleRequest request);
        Task DeleteAccountScheduleAsync(Guid id);
        Task<List<AccountScheduleResponse>> GetAllAccountSchedulesAsync();
    }
}