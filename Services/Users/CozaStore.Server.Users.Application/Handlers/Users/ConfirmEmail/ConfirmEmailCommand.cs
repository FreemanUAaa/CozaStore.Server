using MediatR;

namespace CozaStore.Server.Users.Application.Handlers.Users.ConfirmEmail;

public class ConfirmEmailCommand : IRequest
{
    public string ConfirmToken { get; set; } = string.Empty;

    public Guid UserId { get; set; } = Guid.Empty;
}