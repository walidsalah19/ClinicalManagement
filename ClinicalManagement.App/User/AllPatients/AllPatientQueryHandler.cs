using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos;
using ClinicalManagement.Application.Dtos.UserDtos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.AllPatients
{
    public class AllPatientQueryHandler : IRequestHandler<AllPatientQuery, Result<List<PatientDto>>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public AllPatientQueryHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<List<PatientDto>>> Handle(AllPatientQuery request, CancellationToken cancellationToken)
        {
            var patients = await usersServices.GetAllAsync("Patient");
            var res = mapper.Map<List<PatientDto>>(patients);
            return Result<List<PatientDto>>.Success(res);
        }
    }
}
