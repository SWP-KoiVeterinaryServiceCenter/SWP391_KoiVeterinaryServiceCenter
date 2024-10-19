using Application.Model.MedicalRecordModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IMedicalRecordService
    {
        Task<bool> AddMedicalRecord(Guid appointmentId,CreateMedicalRecordModel model);
    }
}
