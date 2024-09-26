﻿using Application.IRepository;
using Application.IService.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
        }
    }
}
