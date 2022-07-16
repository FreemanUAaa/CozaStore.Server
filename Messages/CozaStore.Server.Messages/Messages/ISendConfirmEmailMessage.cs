namespace CozaStore.Server.Messages.Messages;

public interface ISendConfirmEmailMessage
{
    string UserName { get; set; }

    string UserEmail { get; set; }

    string ConfirmUrl { get; set; }
}