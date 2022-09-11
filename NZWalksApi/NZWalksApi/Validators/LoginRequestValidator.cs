using FluentValidation;
using NZWalksApi.Models.Dto;

namespace NZWalksApi.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Username.Length).GreaterThan(5);
            RuleFor(x => x.Password.Length).GreaterThan(5);
        }
    }
}
