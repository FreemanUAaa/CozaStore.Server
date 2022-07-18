using CozaStore.Server.Users.Database.Models;
using CozaStore.Server.Users.Producers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CozaStore.Server.Users.Application.Handlers.Users.SendConfirmationEmailMessage;

public class SendConfirmEmailMessageCommandHandler : IRequestHandler<SendConfirmEmailMessageCommand>
{
    private readonly ILogger<SendConfirmEmailMessageCommandHandler> logger;

    private readonly UserManager<User> userManager;

    private readonly IEmailProducer emailProducer;

    public SendConfirmEmailMessageCommandHandler(ILogger<SendConfirmEmailMessageCommandHandler> logger, UserManager<User> userManager, IEmailProducer emailProducer) =>
        (this.userManager, this.emailProducer, this.logger) = (userManager, emailProducer, logger);

    public async Task<Unit> Handle(SendConfirmEmailMessageCommand request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByIdAsync(request.UserId.ToString());

        string confirmEmailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

        await emailProducer.SendConfirmationEmailMessage(new()
        {
            ConfirmToken = confirmEmailToken,
            UserEmail = user.Email,
            UserName = user.UserName,
        });

        logger.LogInformation("A email confirmation message has been sent");

        return Unit.Value;
    }
}
