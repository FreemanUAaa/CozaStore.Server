using MediatR;

namespace CozaStore.Server.Users.Application.Handlers.Users.SendConfirmEmailMessage;

public class SendConfirmEmailMessageCommand : IRequest
{
    public Guid UserId { get; set; } = Guid.Empty;
}