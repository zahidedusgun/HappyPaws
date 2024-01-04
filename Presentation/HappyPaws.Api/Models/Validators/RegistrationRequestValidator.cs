using FluentValidation;
using HappyPaws.API.Models;

namespace HappyPaws.API.Models.Validators
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
                .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(30).WithMessage("Password cannot exceed 30 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name cannot be empty.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("Surname cannot be empty.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");
        }
    }
}