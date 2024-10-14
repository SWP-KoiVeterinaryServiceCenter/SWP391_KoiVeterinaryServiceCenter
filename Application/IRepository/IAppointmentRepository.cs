using Application.Model.AppointmentModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<Guid> GetLastSaveAppointmentId();
        Task<List<AppointmentViewModel>> GetAllAppointment();
        Task<List<AppointmentViewModel>> GetAllAppointmentByUserId(Guid userId);
        Task<List<Appointment>> GetAllAppointmentForCalculate(Guid userId);
    }
}
