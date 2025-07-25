using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using ClinicalManagement.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleServices(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<Result<string>> CreateRoleAsync(string roleName)
        {
           if (await RoleExistsAsync(roleName))
            {
                return Result<string>.Failure(new Error(
                    message: "This role is Exixt",
                    code: ErrorCodes.AlreadyExists.ToString()));
            }
            var res = roleManager.CreateAsync(new IdentityRole(roleName));
            return Result<string>.Success(res.Result.ToString());
        }

        public Task<Result<string>> DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var roleDtos = roles.Select(r => new RoleDto { RoleId = r.Id, RoleName = r.Name }).ToList();
            return  Result<List<RoleDto>>.Success(roleDtos);
        }

        public Task<Result<string>?> GetRoleByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public Task<Result<string>> UpdateRoleNameAsync(string roleId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
