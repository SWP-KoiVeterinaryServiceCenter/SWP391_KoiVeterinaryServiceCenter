using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.TravelExpenseModel
{
    public class ListTravelExpenseViewModel
    {
        public Guid Id { get; set; }
        public decimal BaseRate { get; set; }
        public decimal MinimumTravelRate { get; set; }
        public decimal MaximumTravelRate { get; set; }
    }
}
