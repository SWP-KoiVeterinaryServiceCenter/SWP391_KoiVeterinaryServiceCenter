using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public interface IModificationBy
    {
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
