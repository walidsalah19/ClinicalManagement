using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Auth.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
    {
        private readonly IAuthServices authServices;

        public RefreshTokenHandler(IAuthServices authServices)
        {
           this. authServices = authServices;
        }

        public async Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var res = await authServices.RefreshTokenAsync(request.RefreshToken);

            return res;
        }
    }
}
