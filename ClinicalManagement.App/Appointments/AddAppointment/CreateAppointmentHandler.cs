using AutoMapper;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.AddAppointment
{
    class CreateAppointmentHandler : IRequestHandler<CreateAppointmentComand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateAppointmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateAppointmentComand request, CancellationToken cancellationToken)
        {

            var appintment = mapper.Map<Appointment>(request.appointment);
            await unitOfWork.Repository<Appointment>().AddAsync(appintment);
            await unitOfWork.Complete();
            return Result<string>.Success("create Appointment succesfully");
        }
    }
}
