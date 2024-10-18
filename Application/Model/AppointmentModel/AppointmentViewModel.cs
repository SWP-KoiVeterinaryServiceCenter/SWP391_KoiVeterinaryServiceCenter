using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AppointmentModel
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ServiceName { get; set; }
        public string KoiName { get; set; }
        public string Status { get; set; }
        public string VetName { get; set; }
        public decimal Price { get; set; }
        public decimal TravelFee { get; set; }
        public decimal ServiceFee { get; set; }
    }
}
