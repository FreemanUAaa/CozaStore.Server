using CozaStore.Server.Users.Producers.Models;

namespace CozaStore.Server.Users.Producers.Interfaces;

public interface IEmailProducer
{
    Task SendConfirmationEmailMessage(SendConfirmEmailMessageParams sendParams);
}
