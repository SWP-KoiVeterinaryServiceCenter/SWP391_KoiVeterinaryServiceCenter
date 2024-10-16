using Application.Model.AppointmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IAppointmentService
    {
        Task<bool> CreateAppointmentAsync(CreateAppointmentModel createAppointmentModel);
        Task<List<AppointmentViewModel>> GetAllAsync();
        Task<bool> UpdateAppointment(Guid id, UpdateAppointmentModel updateAppointmentModel);
        Task<bool> DeleteAppointmentAsync(Guid id);
        Task<AppointmentViewModel> GetAppointmentByIdAsync(Guid id);
        Task<List<AppointmentViewModel>> GetCurrentUserAppointments();
        Task<bool> CancelAppointmentAsync(Guid id);  
    }
}
