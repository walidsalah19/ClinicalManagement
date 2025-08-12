using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        private readonly IUsersServices usersServices;

        public DeleteUserHandler(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var res =await usersServices.DeleteAsync(request.Id);
            return res;
        }
    }
}
