using Application.IRepository;
using Application.IService.Common;
using Application.Model.MedicalPrescriptionModel;
using Application.Model.MedicalRecordModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
    {
        private readonly AppDbContext _appDbContext;
        public MedicalRecordRepository(AppDbContext appDbContext, IClaimService claimService, ICurrentTime currentTime) : base(appDbContext, claimService, currentTime)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<MedicalRecordListModel>> GetAllMedicalRecordByAppointmentIdAsync(Guid appointmentId)
        {

            var medicalRecordList = await _appDbContext.MedicalRecords.Where(x => x.AppointmentId == appointmentId && x.IsDelete == false)
                                                                    .Select(x => new MedicalRecordListModel
                                                                    {
                                                                        Symptoms = x.Symptoms,
                                                                        Diagnosis = x.Diagnosis,
                                                                        Notes = x.Notes,
                                                                        TestResults = x.TestResults,
                                                                        TreatmentGiven = x.TreatmentGiven,
                                                                        createPrescriptionModel = x.Prescriptions.Select(y=>new CreatePrescriptionModel
                                                                        {
                                                                            Dosage=y.Dosage,
                                                                            Duration=y.Duration,
                                                                            Frequency=y.Frequency,
                                                                            Instructions=y.Instructions,
                                                                            MedicalName = y.MedicalName
                                                                        }).ToList(),
                                                                    })
                                                                   .ToListAsync();
            return medicalRecordList;
        }

        public async Task<Guid> GetLastSaveMedicalRecordId()
        {
            var lastSaveMedicalRecord = await _appDbContext.MedicalRecords.Where(x => x.IsDelete == false)
                                                                        .OrderBy(x => x.CreationDate)
                                                                        .LastOrDefaultAsync();
            return lastSaveMedicalRecord.Id;
        }
    }
}
