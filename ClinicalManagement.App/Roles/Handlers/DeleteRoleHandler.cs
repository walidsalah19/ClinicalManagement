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
    class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Result<string>>
    {
        private readonly IRoleServices roleServices;

        public DeleteRoleHandler(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        public async Task<Result<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var res = await roleServices.DeleteRoleAsync(request.RoleId);
            return res;
        }
    }
}
