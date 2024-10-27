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
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedbackRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Feedback> GetByAssociateAppointmentIdAsync(Guid appointmentId)
        {
           var feedback=await _appDbContext.Feedbacks.Where(x=>x.AppointmentId==appointmentId)
                                                     .SingleOrDefaultAsync();
           return feedback;
        }
    }
}
