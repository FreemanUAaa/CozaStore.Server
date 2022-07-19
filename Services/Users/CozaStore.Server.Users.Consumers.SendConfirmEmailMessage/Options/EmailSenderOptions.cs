namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Options;

public class EmailSenderOptions
{
    public string FromEmail { get; set; } = string.Empty;

    public string FromName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Host { get; set; } = string.Empty;

    public bool UseSsl { get; set; } = false;

    public int Port { get; set; } = 0;
}