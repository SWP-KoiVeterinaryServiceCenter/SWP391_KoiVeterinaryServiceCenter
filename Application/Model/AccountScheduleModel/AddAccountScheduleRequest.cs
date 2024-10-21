using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountSchedule
{
    public class AddAccountScheduleRequest
    {
        public Guid AccountId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime WorkingDay { get; set; }
    }
}