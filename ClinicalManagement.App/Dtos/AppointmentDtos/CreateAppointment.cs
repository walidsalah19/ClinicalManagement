using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.AppointmentDtos
{
   public class CreateAppointment
    {
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public string DoctorId { get; set; }
      
        public string PatientId { get; set; }
    }
}
