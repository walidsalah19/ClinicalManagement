using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Validations.AppointmentValidation
{
    using ClinicalManagement.Application.Appointments.AddAppointment;
    using ClinicalManagement.Application.Dtos.AppointmentDtos;
    using ClinicalManagement.Domain.Models;
    using FluentValidation;
    using System;

    public class AppointmentValidator : AbstractValidator<CreateAppointmentComand>
    {
        public AppointmentValidator()
        {


            // Validate AppointmentDate - should be in the future
            RuleFor(x => x.appointment.AppointmentDate)
                    .NotEmpty().WithMessage("Appointment date is required.")
                    .Must(date => date > DateTime.UtcNow)
                    .WithMessage("Appointment date must be in the future.");

            // Validate Status - required and should be one of specific values
            //RuleFor(x => x.Status)
            //    .NotEmpty().WithMessage("Status is required.")
            //    .Must(status => new[] { "Pending", "Confirmed", "Cancelled" }.Contains(status))
            //    .WithMessage("Status must be Pending, Confirmed, or Cancelled.");

            // Validate Notes - optional but limit length
            RuleFor(x => x.appointment.Notes)
                .NotEmpty().WithMessage("Notes is required")
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");

            // Validate DoctorId
            RuleFor(x => x.appointment.DoctorId)
                .NotEmpty().WithMessage("DoctorId is required.");

            // Validate PatientId
            RuleFor(x => x.appointment.PatientId)
                .NotEmpty().WithMessage("PatientId is required.");
        }
    }

}
