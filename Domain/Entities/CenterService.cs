using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CenterService : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        [Column(TypeName="decimal(15,2)")]
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid? TypeId { get; set; }
        public ServiceType ServiceType { get; set; }
       public ICollection<Appointment> Appointments { get; set; }
        public Guid? TankId { get; set; }
        public CenterTank Tank { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
