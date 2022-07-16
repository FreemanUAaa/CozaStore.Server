using CozaStore.Server.Users.Producers.Interfaces;
using CozaStore.Server.Users.Producers.Producers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CozaStore.Server.Users.Producers;

public static class DependencyInjection
{
    public static IServiceCollection AddProducers(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq();
        });

        services.AddTransient<IEmailProducer, EmailProducer>();

        return services;
    }
}
