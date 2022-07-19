using CozaStore.Server.Messages.Messages;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Helpers.ConfirmationUrl;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Interfaces;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Options;
using MassTransit;

namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Consumers;

public class SendConfirmationEmailConsumer : IConsumer<ISendConfirmEmailMessage>
{
    private readonly ILogger<SendConfirmationEmailConsumer> logger;

    private readonly ConfirmationUrlOptions confirmationUrlOptions;

    private readonly IEmailSender emailSender;

    public SendConfirmationEmailConsumer(IEmailSender emailSender, ConfirmationUrlOptions confirmationUrlOptions, ILogger<SendConfirmationEmailConsumer> logger) =>
        (this.emailSender, this.confirmationUrlOptions, this.logger) = (emailSender, confirmationUrlOptions, logger);

    public async Task Consume(ConsumeContext<ISendConfirmEmailMessage> context)
    {
        ISendConfirmEmailMessage message = context.Message;

        string confirmationUrl = ConfirmationUrl.GenerateConfirmationUrl(message.ConfirmationToken, confirmationUrlOptions.ConfirmationEndpoint);

        await emailSender.SendConfirmationEmailMessage(message.UserEmail, message.UserName, confirmationUrl);

        logger.LogInformation("SendConfirmationEmailConsumer consumer -> a confirmation message has been sent to the user's e-mail address");
    }
}
