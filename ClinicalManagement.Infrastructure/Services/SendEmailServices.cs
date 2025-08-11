using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Domain.EmailModel;
using ClinicalManagement.Domain.Models;
using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services
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
