using ClinicalManagement.Application.Abstractions.Services;
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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UsersModel>>
    {
        private readonly IUsersServices usersServices;

        public GetUserByIdHandler(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        public  async Task<Result<UsersModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await usersServices.GetUserById(request.Id);
            if (res == null)
                return Result<UsersModel>.Failure(new Error(message: "User not found", code: ErrorCodes.NotFound.ToString()));
      
            return  Result<UsersModel>.Success(res);
        }
    }
}
