using Application.Model.MedicalRecordModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMedicalRecordRepository:IGenericRepository<MedicalRecord>
    {
        Task<Guid> GetLastSaveMedicalRecordId();
        Task<List<MedicalRecordListModel>> GetAllMedicalRecordByAppointmentIdAsync(Guid appointmentId);
    }
}
