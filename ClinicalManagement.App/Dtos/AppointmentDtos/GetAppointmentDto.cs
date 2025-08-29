using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.AppointmentDtos
{
    public class GetAppointmentDto
    {
        public required string Id { get; set; }
        public string AppointmentDate { get; set; }
        public string Notes { get; set; }
        public string DoctorId { get; set; }
        public string Status { get; set; }

        public string PatientId { get; set; }
    }
}
