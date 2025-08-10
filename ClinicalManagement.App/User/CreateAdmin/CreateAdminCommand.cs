using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.CreateAdmin
{
   public  class CreateAdminCommand :IRequest<Result<string>>
    {
       public  CreateAdmin adminDto { get; set; }
    }
}
