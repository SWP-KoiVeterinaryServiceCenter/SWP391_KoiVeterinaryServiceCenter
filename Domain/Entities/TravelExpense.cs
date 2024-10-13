using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TravelExpense : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        [Column(TypeName = "decimal(5, 2)")]
        public decimal BaseRate { get; set; }
        [Column(TypeName ="decimal(5,2)")]
        public decimal Distance { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal MinimumTravelRate { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal MaximumTravelRate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<ServiceType> ServiceTypeLists { get; set; }
    }
}
