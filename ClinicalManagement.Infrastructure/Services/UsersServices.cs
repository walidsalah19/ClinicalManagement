using Azure.Core;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Events;
using ClinicalManagement.Application.Events.SendEmail;
using ClinicalManagement.Domain.EmailModel;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Enums;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Migrations;
using MediatR;
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
    public class UsersServices : IUsersServices
    {
        private readonly UserManager<UsersModel> _userManager;
        private readonly AppDbContext appDbContext;
        private readonly IMediator _mediator;

        public UsersServices(UserManager<UsersModel> userManager, AppDbContext appDbContext, IMediator mediator)
        {
            _userManager = userManager;
            this.appDbContext = appDbContext;
            _mediator = mediator;
        }

        public async Task<Result<string>> CreateAsync(UsersModel user, string role, string password)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                {
                    return Result<string>.Failure(createResult.Errors.Select(e => e.Description).ToList());
                }

                var roleResult = await _userManager.AddToRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return Result<string>.Failure(roleResult.Errors.Select(e => e.Description).ToList());
                }
                await _mediator.Publish(new SendEmailEvent(new EmailMetaData(toAddress: user.Email, subject: "Creating Account", body: $"Welcome in our app {user.UserName}")));
                await transaction.CommitAsync();
                return Result<string>.Success("User created successfully");
            }
        }
        public async Task<Result<string>> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Result<string>.Failure(new Error(message: "User not found",code:ErrorCodes.NotFound.ToString()));

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded
                ? Result<string>.Success("User deleted successfully")
                : Result<string>.Failure(result.Errors.Select(e => e.Description).ToList());
        }

        public async Task<IEnumerable<UsersModel>> GetAllAsync(string role)
        {
            var users =await _userManager.GetUsersInRoleAsync(role);
            return users;
        }

        public async Task<Result<string>> UpdateAsync(UsersModel user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded
                ? Result<string>.Success("User updated successfully")
                : Result<string>.Failure(result.Errors.Select(e => e.Description).ToList());
        }
    }
}
