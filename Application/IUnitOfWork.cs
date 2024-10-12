using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IKoiRepository KoiRepository { get; }
        public ICenterTankRepository CenterTankRepository { get; }
        public ICenterServiceRepository CenterServiceRepository { get; }
        public IServiceTypeRepository ServiceTypeRepository { get; }
        public IWorkingScheduleRepository WorkingScheduleRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
