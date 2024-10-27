using Application.Model.MedicalPrescriptionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.MedicalRecordModel
{
    public class MedicalRecordListModel
    {
        public Guid RecordId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentGiven { get; set; }
        public string TestResults { get; set; }
        public string Notes { get; set; }
        public List<CreatePrescriptionModel> createPrescriptionModel { get; set; }
    }
}
