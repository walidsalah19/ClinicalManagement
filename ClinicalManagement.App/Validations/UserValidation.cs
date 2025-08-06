using ClinicalManagement.Application.User.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Validations
{
    public class UserValidation : AbstractValidator<CreateUserCommand>
    {
        public UserValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().Length(3, 50);
            //RuleFor(x => x.LastName).NotEmpty().Length(3, 50);
        }
    }
}
