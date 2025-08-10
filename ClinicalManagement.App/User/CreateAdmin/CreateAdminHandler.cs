using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.CreateAdmin
{
    public class CreateAdminHandler : IRequestHandler<CreateAdminCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public CreateAdminHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = mapper.Map<Admin>(request.adminDto);
            var res =await usersServices.CreateAsync(admin, request.adminDto.Role, request.adminDto.Password);
            return res;
        }
    }
}
