using FluentValidation;

namespace CozaStore.Server.Users.Application.Handlers.Users.SendConfirmEmailMessage;

public class SendConfirmEmailMessageCommandValidator : AbstractValidator<SendConfirmEmailMessageCommand>
{
    public SendConfirmEmailMessageCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
