using FluentValidation;

namespace CozaStore.Server.Users.Application.Handlers.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();

        RuleFor(x => x.Password).MinimumLength(8).NotEmpty();

        RuleFor(x => x.PhoneNumber).NotEmpty();

        RuleFor(x => x.Name).MinimumLength(4).NotEmpty();
    }
}