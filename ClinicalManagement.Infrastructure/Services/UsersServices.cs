using Azure.Core;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services
{
    public class UsersServices<TUser> : IUsersServices<TUser> where TUser : IdentityUser
    {
        private readonly UserManager<TUser> userManager;
        private readonly AppDbContext appDbContext;

        public UsersServices(UserManager<TUser> userManager, AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        public async Task<Result<string>> CreateAsync(TUser user, string role, string password)
        {
            using var transaction = await appDbContext.Database.BeginTransactionAsync();

            var createResult = await userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors
                    .Select(e => new Error(e.Description, e.Code))
                    .ToList();
                return Result<string>.Failure(errors);
            }

            var roleResult = await userManager.AddToRoleAsync(user, role);
            if (!roleResult.Succeeded)
            {
                await transaction.RollbackAsync();
                var errors = roleResult.Errors
                    .Select(e => new Error(e.Description, e.Code))
                    .ToList();
                return Result<string>.Failure(errors);
            }

            await transaction.CommitAsync();
            return Result<string>.Success("User created successfully.");
        }

        public async Task<Result<string>> DeleteAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return Result<string>.Failure("User not found.");

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Result<string>.Success("User deleted successfully.");

            var errors = result.Errors.Select(e => new Error(e.Description, e.Code)).ToList();
            return Result<string>.Failure(errors);
        }

        

        public async Task<Result<IQueryable<TUser>>> GetAllAsync()
        {
            return Result<IQueryable<TUser>>.Success(userManager.Users);
        }

        public async Task<Result<string>> UpdateAsync(TUser user)
        {
            var existing = await userManager.FindByIdAsync(user.Id);
            if (existing == null)
                return Result<string>.Failure("User not found.");

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Result<string>.Success("User updated successfully.");

            var errors = result.Errors.Select(e => new Error(e.Description, e.Code)).ToList();
            return Result<string>.Failure(errors);
        }
    }
}
