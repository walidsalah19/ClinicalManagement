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
    public interface IUsersServices<TUser> where TUser : class
    {
        Task<Result<IQueryable<TUser>>> GetAllAsync();
        Task<Result<string>> CreateAsync(TUser user, string role, string Password);
        Task<Result<string>> DeleteAsync(string userId);
        Task<Result<string>> UpdateAsync(TUser user);
    }
}
