using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountSchedule
{
    public class AccountScheduleResponse
    {
        public Guid ScheduleId { get; set; }
        public Guid AccountId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}