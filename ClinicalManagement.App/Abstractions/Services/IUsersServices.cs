using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using ClinicalManagement.Domain.Entities;
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
        public Task<Result<IQueryable<UsersModel>>> GetAllUsersAsync(Expression<Func<UsersModel, bool>> expression);
        Task<Result<string>> CreateUserAsync(UsersModel user, string role, string Password);
        Task<Result<string>> DeleteUserAsync(string userId);
        Task<Result<string>> UpdateUserAsync(UsersModel user);
        Task<UsersModel> FinduserById(string id);
    }
}
