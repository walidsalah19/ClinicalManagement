using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.UpAppointmentStatus
{
    public class UpdateAppointmentStatusCommand: IRequest<Result<string>>
    {
        public UpdateAppointmentStatus status { get; set; }
    }
}
