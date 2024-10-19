using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalRecord : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public Guid? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        /*public Guid? MedicalPrescriptionId { get; set; }
        public MedicalPrescription MedicalPrescription { get; set; }*/
        // Additional fields
        public string Symptoms { get; set; }          // Description of symptoms
        public string Diagnosis { get; set; }         // Diagnosis of the koi
        public string TreatmentGiven { get; set; }    // Treatment given during visit
        public string TestResults { get; set; }       // Results of any tests performed
        public string Notes { get; set; }             // Additional notes from vet
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<MedicalPrescription> Prescriptions { get; set; }
    }
}
