using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.MedicalPrescriptionModel
{
    public class CreatePrescriptionModel
    {
        public string MedicalName { get; set; }
        public string Dosage { get; set; }            // Dosage of the medication
        public string Frequency { get; set; }         // Frequency of administration (e.g., twice daily)
        public string Duration { get; set; }          // Duration of treatment (e.g., 7 days)
        public string Instructions { get; set; }      // Additional instructions (e.g., how to administer)
    }
}
