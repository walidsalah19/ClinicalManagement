using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Domain.EmailModel;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Services.SignalR;
using FluentEmail.Core;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.SnedEmail
{
    public class SendEmailServices : ISendEmail
    {
        private readonly IFluentEmail fluentEmail;
        public SendEmailServices(IFluentEmail fluentEmail)
        {
            this.fluentEmail = fluentEmail;
        }

        public async Task Send(EmailMetaData emailMetaData)
        {
            await fluentEmail
                .To(emailMetaData.ToAddress)
                .Subject(emailMetaData.Subject)
                
                .Body(emailMetaData.Body)
                .SendAsync();
        }
    }
}
