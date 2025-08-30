using ClinicalManagement.Application.Common.Events.Notifications;
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
        private readonly IMediator mediator;

        public UpdateAppointmentStatusHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
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
                await mediator.Publish(new SendNotification(UserId: appointmnt.PatientId, message: $" appointment at {appointmnt.AppointmentDate} has status changed to {appointmnt.Status}"));

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
