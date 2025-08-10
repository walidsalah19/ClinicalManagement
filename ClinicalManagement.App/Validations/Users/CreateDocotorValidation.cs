using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Validations.Users
{
    public class CreateDocotorValidation : AbstractValidator<CreateDoctorDto>
    {
        public CreateDocotorValidation()
        {
            RuleFor(x => x.UserName)
           .NotEmpty().WithMessage("Username is required.")
           .MinimumLength(3).WithMessage("Username must be at least 3 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female").WithMessage("Gender must be Male or Female.");

            RuleFor(x => x.NationalId)
                .NotEmpty().WithMessage("National ID is required.")
                .Length(14).WithMessage("National ID must be exactly 14 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.");

            RuleFor(x => x.Specialization)
                .NotEmpty().When(x => x.Role == "Doctor").WithMessage("Specialization is required for doctors.");

            RuleFor(x => x.Qualification)
                .NotEmpty().When(x => x.Role == "Doctor").WithMessage("Qualification is required for doctors.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .Must(BeAtLeast18YearsOld).WithMessage("User must be at least 18 years old.");
        }

        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            return birthDate <= DateTime.Today.AddYears(-18);
        }
    }
}
