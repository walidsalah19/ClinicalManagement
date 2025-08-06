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
    public class UsersServices : IUsersServices
    {
        private readonly UserManager<UsersModel> userManager;
        private readonly AppDbContext appDbContext;

        public UsersServices(UserManager<UsersModel> userManager, AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        public async Task<Result<string>> CreateUserAsync(UsersModel user, string role,string Password)
        {
            using (var transaction = appDbContext.Database.BeginTransaction())
            {

                var createResult = await userManager.CreateAsync(user,Password);

                if (!createResult.Succeeded)
                {
                   // await transaction.RollbackAsync();
                    var createErrors = createResult.Errors
                        .Select(e => new Error(e.Description, e.Code))
                        .ToList();
                    return Result<string>.Failure(createErrors);
                }

                var roleResult = await userManager.AddToRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync();

                    // rollback: delete the user if role assignment failed
                  //  await userManager.DeleteAsync(user);

                    var roleErrors = roleResult.Errors
                        .Select(e => new Error(e.Description, e.Code))
                        .ToList();
                    return Result<string>.Failure(roleErrors);
                }
                await transaction.CommitAsync();
                return Result<string>.Success("User created successfully.");
            }
        }


        public async Task<Result<string>> DeleteUserAsync(string userId)
        {
            var user = await FinduserById(userId);
            if (user == null)
            {
                return Result<string>.Failure("User not found.");
            }
            var deleteResult = await userManager.DeleteAsync(user);

            if (deleteResult.Succeeded)
            {
                return Result<string>.Success("User deleted successfully.");
            }
            else
            {
                var errors = deleteResult.Errors
                    .Select(e => new Error(e.Description, e.Code))
                    .ToList();
                return Result<string>.Failure(errors);
            }
        }

        public async Task<UsersModel> FinduserById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<Result<IQueryable<UsersModel>>> GetAllUsersAsync(Expression<Func<UsersModel,bool>> expression)
        {
            var res = userManager.Users.Where(expression);
            return Result<IQueryable<UsersModel>>.Success(res);
        }

        public async Task<Result<string>> UpdateUserAsync(UsersModel user)
        {
            var find = await FinduserById(user.Id);
            if (find == null)
            {
                return Result<string>.Failure("User not found.");
            }
            var updateRes = await userManager.UpdateAsync(user);
            if (updateRes.Succeeded)
            {
                return Result<string>.Success("User deleted successfully.");
            }
            else
            {
                var errors = updateRes.Errors
                    .Select(e => new Error(e.Description, e.Code))
                    .ToList();
                return Result<string>.Failure(errors);
            }
        }
    }
}
