using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Interfaces;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailSenderOptions options;

    public EmailSender(IOptions<EmailSenderOptions> options) => this.options = options.Value;

    public async Task SendConfirmationEmailMessage(string toEmail, string toName, string confirmationUrl)
    {
        MimeMessage message = new();

        message.From.Add(new MailboxAddress(options.FromName, options.FromEmail));
        message.To.Add(new MailboxAddress(toName, toEmail));
        message.Subject = "CozaStore: confirm your email";

        message.Body = new TextPart("html") { Text = confirmationUrl };

        using SmtpClient client = new();

        await client.ConnectAsync(options.Host, options.Port, options.UseSsl);

        await client.AuthenticateAsync(options.FromEmail, options.Password);

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}