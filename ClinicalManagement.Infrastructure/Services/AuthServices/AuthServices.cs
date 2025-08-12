using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<UsersModel> userManager;
        private readonly ITokenService tokenService;
        private SignInManager<UsersModel> signInManager;

        public AuthServices(UserManager<UsersModel> userManager, ITokenService tokenService, SignInManager<UsersModel> signInManager)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
        }

        public Task<Result<string>> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AuthResponse>> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await userManager.FindByNameAsync(usernameOrEmail)
                   ?? await userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                return Result<AuthResponse>.Failure(new Error(message: "Invalid credentials", code: ErrorCodes.Unauthorized.ToString()));

            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return Result<AuthResponse>.Failure(new Error(message: "Invalid credentials",code: ErrorCodes.Unauthorized.ToString()));

            var roles = await userManager.GetRolesAsync(user);
            var tokens = tokenService.GenerateTokens(user, (List<string>)roles);
            return Result<AuthResponse>.Success(tokens);
        }

        public Task<Result<string>> LogoutAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TokenResponse>> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
