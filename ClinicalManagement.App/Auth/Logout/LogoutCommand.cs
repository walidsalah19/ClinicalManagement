using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Auth.Logout
{
    public class LogoutCommand :IRequest<Result<string>>
    {
        public string userId { get; set; }
    }
}
