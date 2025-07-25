using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Services
{
    public interface IRoleServices
    {
        Task<Result<List<RoleDto>>> GetAllRolesAsync();
        Task<Result<string>?> GetRoleByIdAsync(string roleId);
        Task<Result<string>> CreateRoleAsync(string roleName);
        Task<Result<string>> DeleteRoleAsync(string roleId);
        Task<Result<string>> UpdateRoleNameAsync(string roleId, string newName);
        Task<bool> RoleExistsAsync(string roleName);

    }
}
