using MediatR;

namespace CozaStore.Server.Users.Application.Handlers.Users.SendConfirmationEmailMessage;

public class SendConfirmEmailMessageCommand : IRequest
{
    public Guid UserId { get; set; } = Guid.Empty;
}