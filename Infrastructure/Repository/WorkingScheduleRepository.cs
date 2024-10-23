using Application.IRepository;
using Application.IService.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class WorkingScheduleRepository : GenericRepository<WorkingSchedule>, IWorkingScheduleRepository
    {
        private readonly AppDbContext _appDbContext;
        public WorkingScheduleRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> GetLastSaveScheduleId()
        {
            var lastSaveSchedule = await _appDbContext.WorkingSchedules.Where(x => x.IsDelete == false)
                                                                     .OrderBy(x => x.CreationDate)
                                                                     .LastOrDefaultAsync();
            return lastSaveSchedule.Id;
        } 
    }
}
