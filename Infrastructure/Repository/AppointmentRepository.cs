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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _context = appDbContext;
        }

        public async Task<Guid> GetLastSaveAppointmentId()
        {
            var appointment = await _context.Appointments.OrderBy(x=>x.CreationDate).LastAsync();
            return appointment.Id;
        }
    }
}
