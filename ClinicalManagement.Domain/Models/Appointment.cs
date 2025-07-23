using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
