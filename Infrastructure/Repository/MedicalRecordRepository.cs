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
    public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
    {
        private readonly AppDbContext _appDbContext;
        public MedicalRecordRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> GetLastSaveMedicalRecordId()
        {
            var lastSaveMedicalRecord = await _appDbContext.MedicalRecords.Where(x => x.IsDelete == false)
                                                                        .OrderBy(x => x.CreationDate)
                                                                        .LastOrDefaultAsync();
            return lastSaveMedicalRecord.Id;
        }
    }
}
