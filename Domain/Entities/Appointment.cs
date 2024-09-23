using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public string Description { get; set; }
        public string AppointmentStatus { get; set; }
        public Guid? ServiceId { get; set; }
        public CenterService Service { get; set; }
        public Guid? MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Guid? RatingId { get; set; }
        public Rating Rating { get; set; }
        public Guid? FeedbackId { get; set; }
        public Feedback Feedback { get; set; }
        public Guid? KoiId { get; set; }
        public Koi Koi { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
