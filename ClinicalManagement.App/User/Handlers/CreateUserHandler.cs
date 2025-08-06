using ClinicalManagement.Application.Abstractions.Services;
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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;

        public CreateUserHandler(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var user= new UsersModel {UserName=request.FullName,Email=request.Email,PhoneNumber=request.PhoneNumber
               ,BirthDate=request.BirthDate,Gender=request.Gender,PasswordHash=request.Password
               ,NationalId=request.NationalId, Address = request.Address };
            var res = await usersServices.CreateUserAsync(user, request.Role);
            return res;
        }
    }
}
