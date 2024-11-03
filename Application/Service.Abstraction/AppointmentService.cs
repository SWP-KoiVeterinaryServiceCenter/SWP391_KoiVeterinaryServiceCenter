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
using System.Reflection.Metadata.Ecma335;
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
            var koiList = await _unitOfWork.KoiRepository.FindAsync(k => k.AccountId == _claimService.GetCurrentUserId);
            var vetList = await _unitOfWork.AccountRepository.GetAllVeterinaryAccounts();
            if (createAppointmentModel.VeterinarianId != null)
            {
                if (!vetList.Where(x => x.Id == createAppointmentModel.VeterinarianId).Any())
                {
                    throw new Exception("Vet account does not exist");
                }
            }
          
            if(koiList.Where(x=>x.Id==createAppointmentModel.KoiId).Any())
            {
                var newAppointment = _mapper.Map<Appointment>(createAppointmentModel);
                newAppointment.AppointmentStatus = nameof(AppointmentStatus.Pending);
                await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
            }
            else
            {
                throw new Exception("You do not own this Koi");
            }
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

        public async Task<bool> FinishedAppointment(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(_claimService.GetCurrentUserId, x => x.Role);
            var findAppointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if (account == null || findAppointment == null)
            {
                throw new Exception("Error");
            }
            if (account.RoleId == 3)
            {
                if (account.Id != findAppointment.VeterinarianId)
                {
                    throw new Exception("You do not meet the patient");
                }
                if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Finished))
                {
                    throw new Exception("Appontment have been lable as finished");
                } else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Cancelled))
                {
                    throw new Exception("The appointment have been cancelled");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Missed))
                {
                    throw new Exception("The patient have miss this appointment");
                }

                findAppointment.AppointmentStatus = nameof(AppointmentStatus.Finished);
                _unitOfWork.AppointmentRepository.Update(findAppointment);

            }
            if (account.RoleId == 2)
            {
                if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Finished))
                {
                    throw new Exception("Appontment have been lable as finished");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Cancelled))
                {
                    throw new Exception("The appointment have been cancelled");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Missed))
                {
                    throw new Exception("The patient have miss this appointment");
                }
                findAppointment.AppointmentStatus = nameof(AppointmentStatus.Finished);
                _unitOfWork.AppointmentRepository.Update(findAppointment);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<AppointmentWithCustName>> GetAllAsync()
        {
           return await _unitOfWork.AppointmentRepository.GetAllAppointment();
        }

        public async Task<AppointmentViewModel> GetAppointmentByIdAsync(Guid id)
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointment();
            var appointmentDetail = listAppointment.Where(x => x.Id == id)
                                                   .Select(x=>new AppointmentViewModel
                                                   {
                                                       Id = x.Id,
                                                       Description = x.Description,
                                                       KoiName=x.KoiName,
                                                       Price = x.Price,
                                                       ServiceFee = x.ServiceFee,
                                                       ServiceName = x.ServiceName,
                                                       Status = x.Status,
                                                       TravelFee = x.TravelFee,
                                                       VetName = x.VetName
                                                   }).SingleOrDefault();
            return appointmentDetail;
        }

        public async Task<List<AppointmentWithCustName>> GetAppointmentByVetId()
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointmentByVetId(_claimService.GetCurrentUserId);
            return listAppointment;

        }

        public async Task<List<AppointmentViewModel>> GetCurrentUserAppointments()
        {
            var listAppointment=await _unitOfWork.AppointmentRepository.GetAllAppointmentForCalculate(_claimService.GetCurrentUserId);
            var listVet=await _unitOfWork.AccountRepository.GetAllVeterinaryAccounts();
            decimal travelFee;
            List<AppointmentViewModel> result = new List<AppointmentViewModel>();
            foreach (var appointment in listAppointment)
            {
                Location userLocation = await CalculateLatAndLong.CalculateLatLongByAddressAsync(appointment.Koi.Account.Location);
                Location serviceLocation = await CalculateLatAndLong.CalculateLatLongByAddressAsync(appointment.Service.ServiceLocation);
                if (appointment.Service.ServiceLocation == nameof(LocationEnum.Online)||appointment.Service.ServiceLocation==nameof(LocationEnum.Center))
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

        public async Task<bool> MissedAppointment(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(_claimService.GetCurrentUserId,x=>x.Role);
            var findAppointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if (account == null||findAppointment==null)
            {
                throw new Exception("Error");
            }
            if (account.RoleId == 3)
            {
                if(account.Id!=findAppointment.VeterinarianId)
                {
                    throw new Exception("You do not meet the patient");
                }
                if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Missed))
                {
                    throw new Exception("Appontment have been lable as missed");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Cancelled))
                {
                    throw new Exception("The appointment have been cancelled");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Finished))
                {
                    throw new Exception("The appoinment is finished");
                }
                findAppointment.AppointmentStatus=nameof(AppointmentStatus.Missed);
                _unitOfWork.AppointmentRepository.Update(findAppointment);
                
            }
            if(account.RoleId == 2) 
            {
                if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Missed))
                {
                    throw new Exception("Appontment have been lable as missed");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Cancelled))
                {
                    throw new Exception("The appointment have been cancelled");
                }
                else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Finished))
                {
                    throw new Exception("The appoinment is finished");
                }
                findAppointment.AppointmentStatus = nameof(AppointmentStatus.Missed);
                _unitOfWork.AppointmentRepository.Update(findAppointment);
            }
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<TotalAppointmentAmountViewModel> TotalAppointmentAsync()
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointment();
            var totalAppointment = new TotalAppointmentAmountViewModel
            {
                TotalAppointment=listAppointment.Count()
            };
            
           return totalAppointment;
        }

        public async Task<TotalAppointmentAmountViewModel> TotalConfirmedAppointmentAsync()
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointment();
            var listConfirmedAppointment=listAppointment.Where(x=>x.Status == nameof(AppointmentStatus.Confirmed)).ToList();
            var totalAppointment = new TotalAppointmentAmountViewModel
            {
                TotalAppointment = listConfirmedAppointment.Count()
            };

            return totalAppointment;
        }

        public async Task<TotalAppointmentAmountViewModel> TotalPendingAppointmentAsync()
        {
            var listAppointment = await _unitOfWork.AppointmentRepository.GetAllAppointment();
            var listConfirmedAppointment = listAppointment.Where(x => x.Status == nameof(AppointmentStatus.Pending)).ToList();
            var totalAppointment = new TotalAppointmentAmountViewModel
            {
                TotalAppointment = listConfirmedAppointment.Count()
            };

            return totalAppointment;
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
