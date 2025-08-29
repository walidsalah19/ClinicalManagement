using AutoMapper;
using ClinicalManagement.Application.Abstractions.DbContext;
using ClinicalManagement.Application.Abstractions.Services.AppointmentServices;
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
    public class GetAppointmentHandler : IRequestHandler<GetApplointmentsQuery, Result<List<GetAppointmentDto>>>
    {
        
        private readonly IMapper mapper;
        private readonly IAppointmentService appointment;

        public GetAppointmentHandler(IMapper mapper, IAppointmentService appointment)
        {
            this.mapper = mapper;
            this.appointment = appointment;
        }

        public async Task<Result<List<GetAppointmentDto>>> Handle(GetApplointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await appointment.GetAppointmentsById(x => x.PatientId.Equals(request.Id));
            var res = mapper.Map<List<GetAppointmentDto>>(appointments);

            return Result<List<GetAppointmentDto>>.Success(res);
        }
    }
}
