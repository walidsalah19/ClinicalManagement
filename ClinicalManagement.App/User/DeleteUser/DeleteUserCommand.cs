using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.DeleteUser
{
    public class DeleteUserCommand :IRequest<Result<string>>
    {
        public string Id { get; set; }
    }
}
