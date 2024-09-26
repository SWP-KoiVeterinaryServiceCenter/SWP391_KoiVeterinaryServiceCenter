using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WorkingSchedule : BaseEntity, ICreatedBy, IModificationBy, IDeletedBy
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DayOfWeek { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
