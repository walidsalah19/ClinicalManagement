using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services
{
    public interface IUsersServices
    {
        Task<Result<List<UsersModel>>> GetAllUsersAsync();
        Task<Result<string>> CreateUserAsync(UsersModel user, string role);
        Task<Result<string>> DeleteUserAsync<TKey>(TKey id);
        Task<Result<string>> UpdateUserAsync(UsersModel user);
    }
}
