using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.AppointmentDtos
{
    public class UpdateAppointmentStatus
    {
        public required string Id { get; set; }
        [Required]
        [RegularExpression("^(Pending|Confirmed|Cancelled)$", ErrorMessage = "Status must be Pending, Confirmed, or Cancelled.")]
        public required string Status { get; set; }
    }
}
