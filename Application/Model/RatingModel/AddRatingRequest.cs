﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.RatingModel
{
    public class AddRatingRequest
    {
        public decimal RatingPoint { get; set; }
        public Guid? RaterId { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
