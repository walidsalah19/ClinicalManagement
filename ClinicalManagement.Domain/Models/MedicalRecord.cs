using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class MedicalRecord
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public string Notes { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
