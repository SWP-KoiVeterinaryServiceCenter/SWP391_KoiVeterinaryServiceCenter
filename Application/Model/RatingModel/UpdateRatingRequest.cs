using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.RatingModel
{
    public class UpdateRatingRequest
    {
        public decimal RatingPoint { get; set; }
        public string RatingContent { get; set; }
        public Guid AccountId { get; set; }
        public Guid AppointmentId { get; set; }

    }
}