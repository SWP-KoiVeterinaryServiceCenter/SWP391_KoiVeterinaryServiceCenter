using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        [Column(TypeName = "decimal(5, 2)")]
        public decimal RatingPoint { get; set; }
        public Guid? RaterId { get; set; }
        public Account Rater {  get; set; }
        public Guid? AppointmentId { get; set; }
        public Appointment RatingAppointment { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
