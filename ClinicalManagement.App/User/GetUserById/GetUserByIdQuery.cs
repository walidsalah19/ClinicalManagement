using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result<UsersModel>>
    {
        public string Id { get; set; }
    }
}
