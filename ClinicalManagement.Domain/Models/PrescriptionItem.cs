using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class PrescriptionItem
    {
        public Guid Id { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }

        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
