using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.AppointmentModel;
using Application.Util;
using Application.Util.UitlModel;
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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public AppointmentService(IUnitOfWork unitOfWork,IMapper mapper,IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
        }

        public async Task<bool> CancelAppointmentAsync(Guid id)
        {
            var findAppintment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if (findAppintment == null)
            {
                throw new Exception("Appiontment have been removed");
            }
            if(findAppintment.AppointmentStatus==nameof(AppointmentStatus.Confirmed)) 
            {
                throw new Exception("Cannot cancel this appointment");
            } else if(findAppintment.AppointmentStatus==nameof(AppointmentStatus.Cancelled))
            {
                throw new Exception("Appointment has already been cancelled");
            }
            findAppintment.AppointmentStatus=nameof(AppointmentStatus.Cancelled);
            _unitOfWork.AppointmentRepository.Update(findAppintment);
            return await _unitOfWork.SaveChangeAsync()>0;
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

        public async Task<List<AppointmentViewModel>> GetCurrentUserAppointments()
        {
            var listAppointment=await _unitOfWork.AppointmentRepository.GetAllAppointmentForCalculate(_claimService.GetCurrentUserId);
            var listVet=await _unitOfWork.AccountRepository.GetAllVeterinaryAccounts();
            decimal travelFee;
            List<AppointmentViewModel> result = new List<AppointmentViewModel>();
            // var listAppointmentModel=await _unitOfWork.AppointmentRepository.GetAllAppointmentByUserId(_claimService.GetCurrentUserId);

            foreach (var appointment in listAppointment)
            {
                Location userLocation = await CalculateLatAndLong.CalculateLatLongByAddressAsync(appointment.Koi.Account.Location);
                Location serviceLocation = await CalculateLatAndLong.CalculateLatLongByAddressAsync(appointment.Service.ServiceType.ServiceLocation);
                if (appointment.Service.ServiceType.ServiceLocation == "Online")
                {
                    travelFee = 0;
                } else
                {
                    var distance = CalculateDistance.CalculateDistanceByLatAndLong(userLocation, serviceLocation);
                    travelFee = (decimal)appointment.Service.ServiceType.TravelExpense.BaseRate * Convert.ToDecimal(distance);
                    if (travelFee < appointment.Service.ServiceType.TravelExpense.MinimumTravelRate)
                    {
                        travelFee = appointment.Service.ServiceType.TravelExpense.MinimumTravelRate;
                    }
                    else if (travelFee > appointment.Service.ServiceType.TravelExpense.MaximumTravelRate)
                    {
                        travelFee = appointment.Service.ServiceType.TravelExpense.MaximumTravelRate;
                    }
                }
                AppointmentViewModel appointmentViewModel = new AppointmentViewModel
                {
                    Description = appointment.Description,
                    Id = appointment.Id,
                    KoiName = appointment.Koi.KoiName,
                    Price = Math.Round(appointment.Service.Price + travelFee, 0),
                    ServiceName = appointment.Service.ServiceName,
                    Status = appointment.AppointmentStatus,
                    VetName = listVet.Where(x => x.Id == appointment.VeterinarianId).Select(x => x.Username).SingleOrDefault(),
                    TravelFee=Math.Round(travelFee,0),
                    ServiceFee=appointment.Service.Price
                };
                result.Add(appointmentViewModel);
            }
            return result;
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
