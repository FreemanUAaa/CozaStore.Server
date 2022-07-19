namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Interfaces;

public interface IEmailSender 
{
    Task SendConfirmationEmailMessage(string toEmail, string toName, string confirmationUrl);
}