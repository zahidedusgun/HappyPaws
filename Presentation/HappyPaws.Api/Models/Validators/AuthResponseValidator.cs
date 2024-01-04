using FluentValidation;
using HappyPaws.API.Models;

namespace HappyPaws.API.Models.Validators
{
    public class AuthResponseValidator : AbstractValidator<AuthResponse>
    {
        public AuthResponseValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}