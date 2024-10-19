using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalPrescription : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public Guid? MedicalRecordId {  get; set; }
        public MedicalRecord MedicalRecordLink {  set; get; }
        public string MedicalName { get; set; }
        public string Dosage { get; set; }            // Dosage of the medication
        public string Frequency { get; set; }         // Frequency of administration (e.g., twice daily)
        public string Duration { get; set; }          // Duration of treatment (e.g., 7 days)
        public string Instructions { get; set; }      // Additional instructions (e.g., how to administer)
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
