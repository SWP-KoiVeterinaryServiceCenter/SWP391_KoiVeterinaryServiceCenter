using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Koi : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public string KoiName { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Varieties { get; set; }
        public string KoiImage { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<Appointment> AppointmentLists { get; set; }
    }
}
