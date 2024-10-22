using Application.Model.WorkingScheduleModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IWorkingScheduleService
    {
        Task<IEnumerable<WorkingScheduleResponse>> GetAllAsync();
        Task<WorkingScheduleResponse> GetByIdAsync(Guid id);
        Task<WorkingScheduleResponse> CreateAsync(AddWorkingScheduleRequest request);
        Task UpdateAsync(Guid id, UpdateWorkingScheduleRequest request);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<WorkingScheduleResponse>> GetAllByAccountIdAsync(Guid accountId);
    }
}