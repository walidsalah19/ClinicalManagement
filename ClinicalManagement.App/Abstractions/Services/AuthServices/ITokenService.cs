using ClinicalManagement.Application.Dtos.AuthDtos;
using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services.AuthServices
{
    public interface ITokenService
    {
        AuthResponse GenerateTokens(UserModel user, List<string> roles);
        public string GenerateRefreshToken();
    }
}
