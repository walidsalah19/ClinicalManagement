using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Result<string>> CreateUserAsync(UsersModel user, string role)
        {
            using (var transaction = appDbContext.Database.BeginTransaction())
            {

                var createResult = await userManager.CreateAsync(user);

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


        public Task<Result<string>> DeleteUserAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<UsersModel>>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> UpdateUserAsync(UsersModel user)
        {
            throw new NotImplementedException();
        }
    }
}
