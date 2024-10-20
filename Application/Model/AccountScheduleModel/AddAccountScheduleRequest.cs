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
        public Guid ScheduleId { get; set; }
    }
}