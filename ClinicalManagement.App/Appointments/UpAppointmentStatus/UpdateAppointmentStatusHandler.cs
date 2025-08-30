using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Appointments.UpAppointmentStatus
{
    public class UpdateAppointmentStatusHandler : IRequestHandler<UpdateAppointmentStatusCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateAppointmentStatusHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(UpdateAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            var appointmnt = await unitOfWork.appoointmentsRepo.GetEntityById(request.status.AppointmentId);
            if (appointmnt == null)
                return Result<string>.Failure("this appointment not exist");
            else if(appointmnt.Status.Equals("Cancelled"))
                return Result<string>.Failure("this appointment is cancelled before so you cant change the status");


            appointmnt.Status = request.status.Status;

            try
            {
                await unitOfWork.Complete();
                return Result<string>.Success("Update appointment status Successfully");
            }
            catch(Exception ex)
            {
                return Result<string>.Failure(ex.Message);
                throw;
            }
        }
    }
}
