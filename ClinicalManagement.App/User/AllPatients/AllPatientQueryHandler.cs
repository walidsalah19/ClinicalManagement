using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.AllPatients
{
    public class AllPatientQueryHandler : IRequestHandler<AllPatientQuery, Result<List<UserDto>>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public AllPatientQueryHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<List<UserDto>>> Handle(AllPatientQuery request, CancellationToken cancellationToken)
        {
            var patients = await usersServices.GetAllAsync("Patient");
            var res = mapper.Map<List<UserDto>>(patients);
            return Result<List<UserDto>>.Success(res);
        }
    }
}
