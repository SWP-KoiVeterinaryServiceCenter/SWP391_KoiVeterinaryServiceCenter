using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.FeedbackModel
{
    public class FeedbackResponse
    {
        
        public Guid AccountId { get; set; }
        public Guid? AppointmentID { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
