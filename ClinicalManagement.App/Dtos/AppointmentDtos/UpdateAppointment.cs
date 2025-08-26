using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.AppointmentDtos
{
   public  class UpdateAppointment 
    {
        public required string Id { get; set; }
        public required DateTime AppointmentDate { get; set; }
        [Required]
        [RegularExpression("^(Pending|Confirmed|Cancelled)$", ErrorMessage = "Status must be Pending, Confirmed, or Cancelled.")]
        public required string Status { get; set; }
        public required string Notes { get; set; }

      
    }
}
