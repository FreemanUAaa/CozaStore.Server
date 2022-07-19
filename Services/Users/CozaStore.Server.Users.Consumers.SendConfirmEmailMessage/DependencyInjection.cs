using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Contracts;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Options;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Consumers;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Interfaces;
using CozaStore.Server.Users.Consumers.SendConfirmationEmailMessage.Services;
using MassTransit;

namespace CozaStore.Users.Consumers.SendConfirmationEmailMessage;

public static class DependencyInjection
{
    public static IServiceCollection AddConsumers(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConfirmationUrlOptions>(configuration.GetSection("endpoits"));

        services.Configure<EmailSenderOptions>(configuration.GetSection("email"));

        RabbitMqOptions rabbitMqOptions = configuration.GetSection("rabbitmq").Get<RabbitMqOptions>();

        services.AddTransient<IEmailSender, EmailSender>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<SendConfirmationEmailConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqOptions.Host, ushort.Parse(rabbitMqOptions.Post.ToString()), rabbitMqOptions.VirtualHost, h =>
                {
                    h.Username(rabbitMqOptions.User);
                    h.Password(rabbitMqOptions.Password);
                });

                cfg.ReceiveEndpoint(ContractStrings.SendConfirmEmailMessageQueue, e =>
                {
                    e.UseMessageRetry(x => x.Immediate(5));

                    e.ConfigureConsumer<SendConfirmationEmailConsumer>(context);
                });
            });
        });

        return services;
    }
}