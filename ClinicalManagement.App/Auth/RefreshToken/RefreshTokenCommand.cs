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
    public class RefreshTokenCommand : IRequest<Result<AuthResponse>>
    { 
        public string RefreshToken { get; set; }
    }
}
