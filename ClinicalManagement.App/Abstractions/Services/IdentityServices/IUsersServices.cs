using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using ClinicalManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services.IdentityServices
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserModel>> GetAllAsync(string role);
        Task<Result<string>> CreateAsync(UserModel user, string role, string password);
        Task<Result<string>> DeleteAsync(string userId);
        Task<Result<string>> UpdateAsync(UserModel user);

        Task<UserModel> GetUserById(string Id);
    }
}
