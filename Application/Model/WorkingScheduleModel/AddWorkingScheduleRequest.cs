using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.WorkingScheduleModel
{
    public class AddWorkingScheduleRequest
    {
        public int  StartTime { get; set; }
        public int  EndTime { get; set; }
        public DateOnly WorkingDay { get; set; }
        public Guid VeterinarianId { get; set; }
    }
}
