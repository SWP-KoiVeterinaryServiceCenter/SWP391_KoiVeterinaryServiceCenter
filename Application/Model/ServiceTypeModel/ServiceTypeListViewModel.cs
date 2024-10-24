using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.ServiceTypeModel
{
    public class ServiceTypeListViewModel
    {
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public Guid TravelExpenseId { get; set; }
    }
}
