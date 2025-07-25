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
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result<String>>
    {
        private readonly IRoleServices roleServices;

        public CreateRoleCommandHandler(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }

        public async Task<Result<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var res = await roleServices.CreateRoleAsync(request.RoleName);

            return res;
        }
    }
}
