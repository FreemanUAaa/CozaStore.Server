using CozaStore.Users.Consumers.SendConfirmationEmailMessage;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((http, services) =>
        services.AddConsumers(http.Configuration))
    .Build();

host.Run();