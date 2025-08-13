using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Enums;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Migrations;
using ClinicalManagement.Infrastructure.UnitOFWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<UserModel> userManager;
        private readonly ITokenService tokenService;
        private readonly SignInManager<UserModel> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext appContext;

        public AuthServices(UserManager<UserModel> userManager, ITokenService tokenService, SignInManager<UserModel> signInManager, IUnitOfWork unitOfWork, AppDbContext appContext)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.appContext = appContext;
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

            var roles = await GetUserRoles(user);
            var tokens = tokenService.GenerateTokens(user,roles);
            tokens.RefreshToken = await SaveRefreshToken(user.Id);
            return Result<AuthResponse>.Success(tokens);
        }

        public Task<Result<string>> LogoutAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AuthResponse>> RefreshTokenAsync(string refreshToken)
        {
            var token =await appContext.RefreshTokens.Include(x => x.user).FirstOrDefaultAsync(x => x.Token == refreshToken);
            if(token ==null || token.ExpireOnUtc<DateTime.UtcNow)
            {
                return Result<AuthResponse>.Failure(new Error(message: "the refresh token has expire", code: ErrorCodes.Forbidden.ToString()));
            }
            var roles = await GetUserRoles(token.user);
            var accesToken = tokenService.GenerateTokens(token.user, roles);
            token.Token = tokenService.GenerateRefreshToken();
            token.ExpireOnUtc = DateTime.UtcNow.AddDays(7);
            accesToken.RefreshToken = token.Token;
            return Result<AuthResponse>.Success(accesToken);

        }
        private async Task<string> SaveRefreshToken(string userId)
        {
            var refrashToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = tokenService.GenerateRefreshToken(),
                UserId = userId,
                ExpireOnUtc = DateTime.UtcNow.AddDays(7)
            };

            await unitOfWork.Repository<RefreshToken>().AddAsync(refrashToken);
            unitOfWork.Complete();

            return refrashToken.Token;
        }
        private async Task<List<string>> GetUserRoles(UserModel user)
        {
            var roles = await userManager.GetRolesAsync(user);
            return (List<string>)roles;
        }
    }
}
