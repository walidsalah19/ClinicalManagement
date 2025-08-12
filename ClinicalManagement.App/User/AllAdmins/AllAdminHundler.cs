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

namespace ClinicalManagement.Application.User.AllAdmins
{
   public class AllAdminHundler : IRequestHandler<AllAdminsQuery, Result<List<AdminDto>>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public AllAdminHundler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<List<AdminDto>>> Handle(AllAdminsQuery request, CancellationToken cancellationToken)
        {
            var res = await usersServices.GetAllAsync("Admin");
            var admins = mapper.Map<List<AdminDto>>(res);
            return Result<List<AdminDto>>.Success(admins);
        }
    }
}
