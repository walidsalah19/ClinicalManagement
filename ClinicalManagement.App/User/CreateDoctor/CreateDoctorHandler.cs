using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.CreateDoctor
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public CreateDoctorHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Doctor>(request.CreateDoctor);
            var res = await usersServices.CreateAsync(user, request.
                CreateDoctor.Role, request.CreateDoctor.Password);
            return res;
        }
    }
}
