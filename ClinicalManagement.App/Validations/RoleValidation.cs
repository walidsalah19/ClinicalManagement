using ClinicalManagement.Application.Roles.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Validations
{
    public class RoleValidation :AbstractValidator<CreateRoleCommand>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName)
             .NotEmpty().WithMessage("Role name is required.")
             .MinimumLength(3).WithMessage("Role name must be at least 3 characters.")
             .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.")
             .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Role name can only contain letters, numbers, and spaces.");
        }
    }
}
