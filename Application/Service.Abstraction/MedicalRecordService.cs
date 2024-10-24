using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.MedicalRecordModel;
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
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        public MedicalRecordService(IUnitOfWork unitOfWork,IClaimService claimService,IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _claimService = claimService;
            _mapper = mapper;
        }
        public async Task<bool> AddMedicalRecord(Guid appointmentId, CreateMedicalRecordModel model)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(_claimService.GetCurrentUserId, x => x.Role);
            var findAppointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointmentId);
            if (account == null || findAppointment == null)
            {
                throw new Exception("Error");
            }
            else if (account.Id != findAppointment.VeterinarianId)
             {
                throw new Exception("You do not meet the patient");
             } else if (findAppointment.AppointmentStatus == nameof(AppointmentStatus.Missed) || findAppointment.AppointmentStatus == nameof(AppointmentStatus.Cancelled)){
                throw new Exception("This appointment have been cancelled or the patient have miss this appointment");
            }
            var medicalRecord = _mapper.Map<MedicalRecord>(model);
            medicalRecord.AppointmentId = appointmentId;
            await _unitOfWork.MedicalRecordRepository.AddAsync(medicalRecord);
            await _unitOfWork.SaveChangeAsync();
            foreach(var medicalPrescriptionModel in model.createPrescriptionModel)
            {
                var medicalPrescription = _mapper.Map<MedicalPrescription>(medicalPrescriptionModel);
                medicalPrescription.MedicalRecordId = medicalRecord.Id;
                await _unitOfWork.MedicalPrescriptionRepository.AddAsync(medicalPrescription);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<MedicalRecordListModel>> GetListMedicalRecordByAppointmentIdAsync(Guid appointmentId)
        {
            var listMedicalRecord = await _unitOfWork.MedicalRecordRepository.GetAllMedicalRecordByAppointmentIdAsync(appointmentId);
            return listMedicalRecord;
        }
    }
}
