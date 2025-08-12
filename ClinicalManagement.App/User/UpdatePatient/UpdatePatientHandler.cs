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
   public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;
        private readonly IMapper mapper;

        public UpdatePatientHandler(IUsersServices usersServices, IMapper mapper)
        {
            this.usersServices = usersServices;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = mapper.Map<Patient>(request.patientDto);
            var userExist = await usersServices.GetUserById(patient.Id);
            if(userExist ==null)
            {
                return Result<string>.Failure(new Error(message: "User you try to update not exist", code: ErrorCodes.NotFound.ToString()));

            }
            userExist.UserName = patient.UserName;
            userExist.Address = patient.Address;
            userExist.Email = patient.Email;
            userExist.BirthDate = patient.BirthDate;
            userExist.Gender = patient.Gender;
            userExist.NationalId = patient.NationalId;
            userExist.PhoneNumber = patient.PhoneNumber;

            var res =await usersServices.UpdateAsync(userExist);
            return res;
        }
    }
}
