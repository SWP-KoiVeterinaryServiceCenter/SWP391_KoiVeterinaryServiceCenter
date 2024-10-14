﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.RatingModel
{
    public class RatingResponse
    {
        public Guid Id { get; set; }
        public decimal RatingPoint { get; set; }
        public Guid? RaterId { get; set; }
        public Guid? AppointmentId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}