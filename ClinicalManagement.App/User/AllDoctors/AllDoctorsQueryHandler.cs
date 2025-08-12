using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.AllDoctors
{
    public class AllDoctorsQueryHandler : IRequestHandler<AllDoctorsQuery, Result<List<DoctorDto>>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public AllDoctorsQueryHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<List<DoctorDto>>> Handle(AllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var res =await usersServices.GetAllAsync("Doctor");
            var doctors = mapper.Map<List<DoctorDto>>(res);
            return Result<List<DoctorDto>>.Success(doctors);
        }
    }
}
