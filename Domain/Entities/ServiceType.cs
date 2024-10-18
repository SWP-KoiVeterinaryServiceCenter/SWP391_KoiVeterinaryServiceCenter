using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceType : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public string TypeName { get; set; }
     /*   public string? ServiceLocation { get; set; }*/
        public Guid? TravelExpenseId { get; set; }
        public TravelExpense TravelExpense { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<CenterService> ListServices { get; set; }
    }
}
