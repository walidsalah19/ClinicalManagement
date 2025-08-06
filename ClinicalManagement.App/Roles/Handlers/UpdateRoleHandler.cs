using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Roles.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Roles.Handlers
{
   public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Result<String>>
    {
        private readonly IRoleServices roleServices;

        public UpdateRoleHandler(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        public async Task<Result<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await roleServices.UpdateRoleNameAsync(request.RoleId,request.RoleName);
        }
    }
}
