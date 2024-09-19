using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public interface ICreatedBy
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
