using CozaStore.Server.Users.Producers.Constracts;
using CozaStore.Server.Users.Producers.Interfaces;
using CozaStore.Server.Users.Producers.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CozaStore.Server.Users.Producers.Producers;

public class EmailProducer : IEmailProducer
{
    private readonly ISendEndpointProvider sendEndpointProvider;

    private readonly ILogger<EmailProducer> logger;

    public EmailProducer(ISendEndpointProvider sendEndpointProvider, ILogger<EmailProducer> logger) =>
        (this.sendEndpointProvider, this.logger) = (sendEndpointProvider, logger);

    public async Task SendConfirmEmailMessage(SendConfirmEmailMessageParams sendParams)
    {
        Uri queue = new(ConstractStrings.SendConfirmEmailMessageQueue);

        ISendEndpoint endpoint = await sendEndpointProvider.GetSendEndpoint(queue);

        logger.LogInformation("Email producer -> a new message has been sent to send a confirm email message");

        await endpoint.Send(new
        {
            sendParams.UserName,
            sendParams.UserEmail,
            sendParams.ConfirmToken,
        }, CancellationToken.None);
    }
}
