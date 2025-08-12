using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Auth.Login
{
    public class LoginCommand :IRequest<Result<AuthResponse>>
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
