using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
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

namespace ClinicalManagement.Infrastructure.Services.IdentityServices
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

        public async Task<Result<string>> DeleteRoleAsync(string roleId)
        {

            var res=await  roleManager.DeleteAsync(new IdentityRole { Id=roleId});
            if (res.Succeeded)
            {
                return Result<string>.Success("delete role Successed "+res.Succeeded.ToString());
            }
            else
            {
                var errors = res.Errors.Select(r => new Error(message: r.Description, r.Code)).ToList();
                return Result<string>.Failure(errors);
            }
            
        }

        public async Task<Result<List<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.
            Select(r => new RoleDto { RoleId = r.Id, RoleName = r.Name }).ToListAsync();
            return  Result<List<RoleDto>>.Success(roles);
        }

        public async Task<Result<string>?> GetRoleByIdAsync(string roleId)
        {
            var role =await roleManager.FindByIdAsync(roleId);
            if(role is null)
            {
                return Result<string>.Failure(new Error(
                   message: "This role isn't  Exixt",
                   code: ErrorCodes.AlreadyExists.ToString()));
            }
            return Result<string>.Success(role.Name);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await roleManager.RoleExistsAsync(roleName);
        }

        public async Task<Result<string>> UpdateRoleNameAsync(string roleId, string newName)
        {
           var role= await roleManager.FindByIdAsync(roleId);
            if (await RoleExistsAsync(newName))
            {
                return Result<string>.Failure(new Error(
                    message: "This role name is Exixt",
                    code: ErrorCodes.AlreadyExists.ToString()));
            }
            else if (role==null)
            {
                return Result<string>.Failure(new Error(
                    message: "This role isn't  Exixt",
                    code: ErrorCodes.AlreadyExists.ToString()));
            }
            role.Name = newName;
            var res = roleManager.UpdateAsync(role);
            return Result<string>.Success(res.Result.ToString());
        }
    }
}
