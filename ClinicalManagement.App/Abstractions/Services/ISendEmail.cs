using ClinicalManagement.Domain.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services
{
     public interface ISendEmail
    {
        Task Send(EmailMetaData emailMetaData);
    }
}
