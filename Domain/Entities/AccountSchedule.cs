using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountSchedule : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid ScheduleId { get; set; }
        public WorkingSchedule WorkingSchedule { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get ; set  ; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
