using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.TankModel
{
    public class ListTankViewModel
    {
        public Guid TankId { get; set; }
        public string TankName { get; set; }    
        public decimal TankCapacity { get; set; }
        public string TankStatus { get; set; }
    }
}
