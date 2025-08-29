using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.GetAppointmentsByDate
{
    public class GetAppointmentsByDateQuery : IRequest<Result<List<GetAppointmentDto>>>
    {
        [RegularExpression("^(Patient|Doctor)$", ErrorMessage = "type must be Patient or Doctor.")]
        public required string type { get; set; }
        public required string Id { get; set; }
        public required DateTime From { get; set; }
        public DateTime To { get; set; } = DateTime.UtcNow;

    }
}
