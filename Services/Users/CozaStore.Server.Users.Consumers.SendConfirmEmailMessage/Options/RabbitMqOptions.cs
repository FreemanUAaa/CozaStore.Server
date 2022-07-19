namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Options;

public class RabbitMqOptions
{
    public int Post { get; set; }

    public string User { get; set; } = string.Empty;

    public string Host { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string VirtualHost { get; set; } = string.Empty;
}
