using ClinicalManagement.Application.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.Commands
{
    public class CreateUserCommand:IRequest<Result<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
