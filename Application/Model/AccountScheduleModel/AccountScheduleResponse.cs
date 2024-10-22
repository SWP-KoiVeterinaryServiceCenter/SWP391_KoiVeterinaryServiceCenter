using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountSchedule
{
    public class AccountScheduleResponse
    {
        public Guid VeterinarianId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string WorkingDay { get; set; }
    }
}