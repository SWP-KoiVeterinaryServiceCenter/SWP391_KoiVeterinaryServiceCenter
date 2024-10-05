using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.IRepository;
using Infrastructure.Repository;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IKoiRepository _koiRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly ICenterTankRepository _centerTankRepository;
        private readonly ICenterServiceRepository _centerServiceRepository;
        private readonly IWorkingScheduleRepository _workingScheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository, 
            IKoiRepository koiRepository, IServiceTypeRepository serviceTypeRepository, 
            ICenterTankRepository centerTankRepository, ICenterServiceRepository centerServiceRepository, 
            IWorkingScheduleRepository workingScheduleRepository,IAppointmentRepository appointmentRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _koiRepository = koiRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _centerTankRepository = centerTankRepository;
            _centerServiceRepository = centerServiceRepository;
            _workingScheduleRepository = workingScheduleRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IKoiRepository KoiRepository => _koiRepository;

        public ICenterTankRepository CenterTankRepository => _centerTankRepository;

        public ICenterServiceRepository CenterServiceRepository => _centerServiceRepository;

        public IServiceTypeRepository ServiceTypeRepository => _serviceTypeRepository;
        public IWorkingScheduleRepository WorkingScheduleRepository => _workingScheduleRepository;

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
