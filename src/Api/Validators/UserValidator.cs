using FluentValidation;
using Pickles.Domain.Models;

namespace Pickles.Api.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.LastName).NotNull();
        RuleFor(x => x.LastName).Length(1, 30);

        RuleFor(x => x.FirstName).NotNull();
        RuleFor(x => x.FirstName).Length(1, 10);

        RuleFor(x => x.Email).NotNull();
        RuleFor(x => x.Email).EmailAddress();
    }
}