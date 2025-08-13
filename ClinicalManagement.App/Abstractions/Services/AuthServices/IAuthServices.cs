using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<Result<AuthResponse>> LoginAsync(string usernameOrEmail, string password);
        Task<Result<string>> LogoutAsync(string userId);
        Task<Result<string>> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<Result<AuthResponse>> RefreshTokenAsync(string refreshToken);
    }
}
