﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.WorkingScheduleModel
{
    public class UpdateWorkingScheduleRequest
    {
        //public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime WorkingDay { get; set; }
       // public Guid VeterinarianId  { get; set; }
    }
}
