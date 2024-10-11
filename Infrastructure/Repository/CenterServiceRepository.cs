using Application.IRepository;
using Application.IService.Common;
using Application.Model.KoiServiceModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CenterServiceRepository : GenericRepository<CenterService>, ICenterServiceRepository
    {
        private readonly AppDbContext _appDbContext;
        public CenterServiceRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ListCenterServiceModel>> GetAllCenterService()
        {
            return await _appDbContext.CenterServices.Where(x => x.IsDelete == false)
                                                     .Select(x => new ListCenterServiceModel
                                                     {
                                                         Description = x.Description,
                                                         Id = x.Id,
                                                         Name=x.ServiceName,
                                                         Price = x.Price,
                                                         TypeName=x.ServiceType.TypeName
                                                     }).ToListAsync();
        }
    }
}
