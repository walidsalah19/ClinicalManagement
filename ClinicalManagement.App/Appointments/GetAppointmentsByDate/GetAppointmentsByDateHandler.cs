using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services.AppointmentServices;
using ClinicalManagement.Application.Appointments.GetAppointments;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AppointmentDtos;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.GetAppointmentsByDate
{
   public  class GetAppointmentsByDateHandler :IRequestHandler<GetAppointmentsByDateQuery,Result<List<GetAppointmentDto>>>
    {
        private readonly IMapper mapper;
        private readonly IAppointmentService appointment;

        public GetAppointmentsByDateHandler(IMapper mapper, IAppointmentService appointment)
        {
            this.mapper = mapper;
            this.appointment = appointment;
        }

        public async Task<Result<List<GetAppointmentDto>>> Handle(GetAppointmentsByDateQuery request, CancellationToken cancellationToken)
        {
            var appointments = new List<Appointment>();
            if (request.type.Equals("Patient"))
            {
                appointments = await appointment.GetAppointmentsById(x =>
                x.PatientId.Equals(request.Id)&&
                x.AppointmentDate>=request.From&& x.AppointmentDate<=request.To);
            }
            else
            {
                appointments = await appointment.GetAppointmentsById(x =>
                 x.DoctorId.Equals(request.Id) &&
                x.AppointmentDate >= request.From && x.AppointmentDate <= request.To);
            }
            var res = mapper.Map<List<GetAppointmentDto>>(appointments);

            return Result<List<GetAppointmentDto>>.Success(res);
        }
    }
}
