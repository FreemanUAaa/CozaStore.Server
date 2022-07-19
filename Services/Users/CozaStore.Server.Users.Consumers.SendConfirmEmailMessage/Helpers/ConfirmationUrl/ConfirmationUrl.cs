namespace CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Helpers.ConfirmationUrl;

public static class ConfirmationUrl
{
    public static string GenerateConfirmationUrl(string confirmationToken, string confirmationEndpoint) =>
        confirmationEndpoint.EndsWith("/")? 
        confirmationEndpoint + confirmationToken : 
        confirmationEndpoint + "/" + confirmationToken;
}