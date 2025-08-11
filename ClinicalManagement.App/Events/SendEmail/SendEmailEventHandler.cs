using ClinicalManagement.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Events.SendEmail
{
    class SendEmailEventHandler : INotificationHandler<SendEmailEvent>
    {
        private readonly ISendEmail sendEmail;

        public SendEmailEventHandler(ISendEmail sendEmail)
        {
            this.sendEmail = sendEmail;
        }

        public async Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
        {
            await sendEmail.Send(notification.Email);
        }
    }
}
