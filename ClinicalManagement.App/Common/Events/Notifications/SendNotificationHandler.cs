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

        public SendNotificationHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            await unitOfWork.notificationRepo.AddAsync(notify);
            await unitOfWork.Complete();
        }
    }
}
