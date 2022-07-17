namespace CozaStore.Server.Users.Producers.Models;

public class SendConfirmEmailMessageParams
{
    public string UserName { get; set; } = string.Empty;

    public string UserEmail { get; set; } = string.Empty;

    public string ConfirmToken { get; set; } = string.Empty;
}