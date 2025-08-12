using AutoMapper;
using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
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
   public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public UpdateDoctorHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Doctor>(request.dto);
            Doctor userExist =(Doctor) await usersServices.GetUserById(user.Id);
            if (userExist == null)
            {
                return Result<string>.Failure(new Error(message: "User you try to update not exist", code: ErrorCodes.NotFound.ToString()));

            }
            userExist.UserName = user.UserName;
            userExist.Address = user.Address;
            userExist.Email = user.Email;
            userExist.BirthDate = user.BirthDate;
            userExist.Gender = user.Gender;
            userExist.NationalId = user.NationalId;
            userExist.PhoneNumber = user.PhoneNumber;
            userExist.Specialization = user.Specialization;
            userExist.Qualification = user.Qualification;
            userExist.Biography = user.Biography;
            var res =await usersServices.UpdateAsync(userExist);
            return res;
        }
    }
}
