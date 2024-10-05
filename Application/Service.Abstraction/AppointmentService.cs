using Application.IService.Abstraction;
using Application.Model.AppointmentModel;
using AutoMapper;
using Domain.Entities;
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
            var newAppointment = _mapper.Map<Appointment>(createAppointmentModel);
            var findService=await _unitOfWork.CenterServiceRepository.GetByIdAsync(createAppointmentModel.ServiceId);
            await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
            await _unitOfWork.SaveChangeAsync();
           /* if (findService != null)
            {
                findService.AppointmentId = await _unitOfWork.AppointmentRepository.GetLastSaveAppointmentId();
                _unitOfWork.CenterServiceRepository.Update(findService);
            }
            else
            {
                throw new Exception("Service not found");
            }*/
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
