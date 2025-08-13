using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserModel>>
    {
        private readonly IUsersServices usersServices;

        public GetUserByIdHandler(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        public  async Task<Result<UserModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await usersServices.GetUserById(request.Id);
            if (res == null)
                return Result<UserModel>.Failure(new Error(message: "User not found", code: ErrorCodes.NotFound.ToString()));
      
            return  Result<UserModel>.Success(res);
        }
    }
}
