using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.User.Commands;
using ClinicalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        public CreateUserHandler()
        {
        }

        public  Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var guid = Guid.NewGuid();
            request.Address = guid.ToString();
          
            return Task.FromResult(Result<Guid>.Success(guid));
        }

       
    }
}
