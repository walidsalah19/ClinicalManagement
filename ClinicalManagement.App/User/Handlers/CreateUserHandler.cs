using AutoMapper;
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
        private readonly IMapper mapper;

        public CreateUserHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<UsersModel>(request.userDto);
            var res = await usersServices.CreateUserAsync(user, request.userDto.Role,request.userDto.Password);
            return res;
        }
    }
}
