using FluentValidation;

namespace CozaStore.Server.Users.Application.Handlers.Users.ConfirmEmail;

public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(x => x.ConfirmToken).NotEmpty();

        RuleFor(x => x.UserId).NotEmpty();
    }
}
