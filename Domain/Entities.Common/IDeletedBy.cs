using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public interface IDeletedBy
    {
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
