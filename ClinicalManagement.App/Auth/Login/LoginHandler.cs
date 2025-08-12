using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
    {
        private readonly IAuthServices authServices;

        public LoginHandler(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var res = await authServices.LoginAsync(request.UserName,request.Password);

            return res;
        }
    }
}
