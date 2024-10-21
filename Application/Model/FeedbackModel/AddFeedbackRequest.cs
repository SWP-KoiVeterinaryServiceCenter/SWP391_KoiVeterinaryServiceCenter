using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.FeedbackModel
{
    public class AddFeedbackRequest
    {
        public Guid AppointmentId { get; set; }
        public string ContentFeedback { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
