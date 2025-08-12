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

namespace ClinicalManagement.Application.Abstractions.Services
{
    public interface IUsersServices
    {
        Task<IEnumerable<UsersModel>> GetAllAsync(string role);
        Task<Result<string>> CreateAsync(UsersModel user, string role, string password);
        Task<Result<string>> DeleteAsync(string userId);
        Task<Result<string>> UpdateAsync(UsersModel user);

        Task<UsersModel> GetUserById(string Id);
    }
}
