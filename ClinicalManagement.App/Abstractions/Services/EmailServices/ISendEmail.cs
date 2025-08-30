using ClinicalManagement.Domain.EmailModel;
using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services.EmailServices
{
     public interface ISendEmail
    {
        Task Send(EmailMetaData emailMetaData);
    }
}
