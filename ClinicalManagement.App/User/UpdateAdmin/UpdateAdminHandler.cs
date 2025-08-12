using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Enums;
using ClinicalManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.UpdatePatient
{
   public class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public UpdateAdminHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Admin>(request.dto);
            var userExist = await usersServices.GetUserById(user.Id);
            if (userExist == null)
            {
                return Result<string>.Failure(new Error(message: "User you try to update not exist", code: ErrorCodes.NotFound.ToString()));

            }
            userExist.UserName = user.UserName;
            userExist.Email = user.Email;
            userExist.NationalId = user.NationalId;
            var res =await usersServices.UpdateAsync(userExist);
            return res;
        }
    }
}
