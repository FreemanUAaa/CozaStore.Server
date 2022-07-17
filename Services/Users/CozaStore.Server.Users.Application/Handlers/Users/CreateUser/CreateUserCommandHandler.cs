using CozaStore.Server.Users.Core.Exceptions;
using CozaStore.Server.Users.Database.Models;
using CozaStore.Server.Users.Producers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CozaStore.Server.Users.Application.Handlers.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly ILogger<CreateUserCommandHandler> logger;

    private readonly UserManager<User> userManager;

    private readonly IEmailProducer emailProducer;

    public CreateUserCommandHandler(UserManager<User> userManager, ILogger<CreateUserCommandHandler> logger, IEmailProducer emailProducer) =>
        (this.userManager, this.emailProducer, this.logger) = (userManager, emailProducer, logger);

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool emailIsAlreadyUse = (await userManager.FindByEmailAsync(request.Email)) != null;

        if (emailIsAlreadyUse)
        {
            throw new Exception(ExceptionStrings.EmailIsAlreadyUse);
        }

        User user = new()
        {
            UserName = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
        };

        await userManager.CreateAsync(user, request.Password);
        
        string confirmEmailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

        await emailProducer.SendConfirmEmailMessage(new()
        {
            ConfirmToken = confirmEmailToken,
            UserEmail = user.Email,
            UserName = user.UserName,
        });

        logger.LogInformation("The user has been created and a email confirmation message has been sent");

        return Unit.Value;
    }
}
