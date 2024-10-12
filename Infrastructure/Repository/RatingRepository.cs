using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.RatingModel;
using Application.IRepository;
using Domain.Entities;
using Application.IService.Common;

namespace Infrastructure.Repository
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly AppDbContext _appDbContext;
        public RatingRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime)
            : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

    }
}
