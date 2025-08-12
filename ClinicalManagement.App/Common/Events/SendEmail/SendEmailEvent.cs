using ClinicalManagement.Domain.EmailModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Common.Events.SendEmail
{
   public record SendEmailEvent(EmailMetaData Email) : INotification;
   
}
