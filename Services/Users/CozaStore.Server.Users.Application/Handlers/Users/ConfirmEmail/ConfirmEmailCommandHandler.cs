using CozaStore.Server.Users.Core.Exceptions;
using CozaStore.Server.Users.Database.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CozaStore.Server.Users.Application.Handlers.Users.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
{
    private readonly ILogger<ConfirmEmailCommandHandler> logger;

    private readonly UserManager<User> userManager;

    public ConfirmEmailCommandHandler(ILogger<ConfirmEmailCommandHandler> logger, UserManager<User> userManager) =>
        (this.userManager, this.logger) = (userManager, logger);

    public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByIdAsync(request.UserId.ToString());
    
        if (user == null)
        {
            throw new Exception(ExceptionStrings.NotFound);
        }

        await userManager.ConfirmEmailAsync(user, request.ConfirmToken);

        logger.LogInformation("The user's email is confirmed ID: {id}", user.Id);

        return Unit.Value;
    }
}
