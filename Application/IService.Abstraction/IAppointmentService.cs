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
    }
}
