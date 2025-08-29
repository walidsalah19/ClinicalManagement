using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.GetAppointments
{
     public class GetApplointmentsQuery :IRequest<Result<List<GetAppointmentDto>>>
    {
        public required string Id { get; set; }
    }
}
