using ClinicalManagement.Application.Abstractions.Jop;
using ClinicalManagement.Application.Abstractions.SignalR;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Common.Events.Notifications
{
    public class SendNotificationHandler : INotificationHandler<SendNotification>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IhangfireJop ihangfireJop;
        private readonly ISignalrServices signalrServices;

        public SendNotificationHandler(IUnitOfWork unitOfWork, IhangfireJop ihangfireJop, ISignalrServices signalrServices)
        {
            this.unitOfWork = unitOfWork;
            this.ihangfireJop = ihangfireJop;
            this.signalrServices = signalrServices;
        }

        public async Task Handle(SendNotification notification, CancellationToken cancellationToken)
        {
            var notify = new Notification
            {
                Id = Guid.NewGuid(),
                Message = notification.message,
                SentAt = DateTime.UtcNow,
                UserId = notification.UserId
            };
            ihangfireJop.CreateScheduleJop(notification.UserId,notification.appointmentDate);
            await unitOfWork.notificationRepo.AddAsync(notify);
            await unitOfWork.Complete();
        }
    }
}
