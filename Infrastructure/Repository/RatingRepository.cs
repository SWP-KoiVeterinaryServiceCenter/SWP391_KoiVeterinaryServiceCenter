using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.RatingModel;
using Application.IRepository;
using Domain.Entities;
using Application.IService.Common;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Rating>> GetAllByAccountIdAsync(Guid accountId)
        {
            return await _appDbContext.Ratings
                .Where(r => r.RaterId == accountId)
                .ToListAsync();
        }

        public async Task<Rating> GetAssociateAppointmentId(Guid appoitnmentId)
        {
            var rating = await _appDbContext.Ratings.Where(x => x.AppointmentId == appoitnmentId)
                                                  .SingleOrDefaultAsync();
            return rating;
        }
    }
}