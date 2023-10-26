using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain;
using Pickles.Domain.Events;
using Pickles.Domain.MessageHandlers;
using Pickles.Domain.Messaging;
using Pickles.Infrastructure.Aws.Config;

namespace Pickles.MessageHandler.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddMessageHandler();
        services.AddInfrastructureAws(appSettings);
        return services;
    }
    
    private static IServiceCollection AddMessageHandler(this IServiceCollection services)
    {
        services.AddSingleton<IMessageHandler<UserCreated>, UserCreatedHandler>();

        return services;
    }
}