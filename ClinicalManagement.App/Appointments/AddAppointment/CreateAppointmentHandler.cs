using AutoMapper;
using ClinicalManagement.Application.Abstractions.Caching;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICachingServices cachingServices;

        public CreateAppointmentHandler(IUnitOfWork unitOfWork, IMapper mapper, ICachingServices cachingServices)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cachingServices = cachingServices;
        }

        public async Task<Result<string>> Handle(CreateAppointmentComand request, CancellationToken cancellationToken)
        {

            var appintment = mapper.Map<Appointment>(request.appointment);
            var lockValue = Guid.NewGuid().ToString();
            if (!await cachingServices.AcquireLockAsync(appintment,lockValue))
                return Result<string>.Failure("Another appointment is being scheduled for this doctor at this time.");

            bool exists = await unitOfWork.appoointmentsRepo.CheckIfAppointmentExist(
                    a => a.DoctorId == appintment.DoctorId && a.AppointmentDate == appintment.AppointmentDate
                );
            if (exists)
                return Result<string>.Failure("Doctor already has an appointment at this time.");

            try
            {
                await unitOfWork.appoointmentsRepo.AddAsync(appintment);
                try
                {
                    await unitOfWork.Complete();
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException?.Message?.Contains("IX_Appointment_Doctor_Date") == true ||
                            ex.Message?.Contains("IX_Appointment_Doctor_Date") == true)
                    {
                        return Result<string>.Failure("Slot was just taken. Please choose a different time.");
                    }

                    throw;
                }
                return Result<string>.Success("create Appointment succesfully");
            }finally
            {
                await cachingServices.ReleaseLockAsync(lockValue);
            }
        }
       
    }
}
