using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Auth.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<string>>
    {
        private readonly IAuthServices authServices;

        public LogoutCommandHandler(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        public async Task<Result<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await authServices.LogoutAsync(request.userId);
        }
    }
}
