using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Roles.Commands
{
   public class DeleteRoleCommand :IRequest<Result<string>>
    {
        public string RoleId { get; set; }
    }
}
