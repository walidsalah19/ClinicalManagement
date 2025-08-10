using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using ClinicalManagement.Application.Roles.Quires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Roles.Handlers
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRoles, Result<List<RoleDto>>>
    {
        private readonly IRoleServices roleServices;

        public GetAllRolesHandler(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        public  Task<Result<List<RoleDto>>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            var roles =  roleServices.GetAllRolesAsync();

            return roles;
        }
    }
}
