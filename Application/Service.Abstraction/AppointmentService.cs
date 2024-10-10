using Application.IService.Abstraction;
using Application.Model.AppointmentModel;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAppointmentAsync(CreateAppointmentModel createAppointmentModel)
        {
           var newAppointment=_mapper.Map<Appointment>(createAppointmentModel);
            newAppointment.AppointmentStatus = nameof(AppointmentStatus.Pending);
            await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteAppointmentAsync(Guid id)
        {
           var findAppointment=await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if(findAppointment == null)
            {
                throw new Exception("Appointment not found");
            }
            _unitOfWork.AppointmentRepository.SoftRemove(findAppointment);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<AppointmentViewModel>> GetAllAsync()
        {
           return await _unitOfWork.AppointmentRepository.GetAllAppointment();
        }

        public async Task<AppointmentViewModel> GetAppointmentByIdAsync(Guid id)
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointment();
            var appointmentDetail = listAppointment.Where(x => x.Id == id).SingleOrDefault();
            return appointmentDetail;
        }

        public async Task<bool> UpdateAppointment(Guid id, UpdateAppointmentModel updateAppointmentModel)
        {
            var findAppointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if (findAppointment == null)
            {
                throw new Exception("Appointment not found");
            }
            _mapper.Map(updateAppointmentModel, findAppointment, typeof(UpdateAppointmentModel), typeof(Appointment));
            _unitOfWork.AppointmentRepository.Update(findAppointment);
            return await _unitOfWork.SaveChangeAsync()>0;
        }
    }
}
