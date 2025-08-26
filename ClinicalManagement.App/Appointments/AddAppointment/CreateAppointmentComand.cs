using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.AddAppointment
{
    public class CreateAppointmentComand : IRequest<Result<string>>
    {
         public CreateAppointment appointment { get; set; }
    }
}
