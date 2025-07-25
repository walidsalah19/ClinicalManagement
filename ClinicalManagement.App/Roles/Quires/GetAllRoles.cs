using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Roles.Quires
{
    public class GetAllRoles :IRequest<Result<List<RoleDto>>>
    {
    }
}
