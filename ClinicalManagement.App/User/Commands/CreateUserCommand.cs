using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.Commands
{
    public class CreateUserCommand:IRequest<Result<string>>
    {
        public CreateUserDto userDto { get; set; }

    }
}
