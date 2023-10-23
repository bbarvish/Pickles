using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain.Events;
using Pickles.Domain.MessageHandlers;
using Pickles.Domain.Messaging;
using Pickles.Domain.Services;
using Pickles.Infrastructure.Aws;

namespace Pickles.Domain.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddServices()
            .AddMessageHandler();
        
        services.AddAutoMapper(cfg => cfg.AllowNullCollections = true, Assembly.GetExecutingAssembly());

        services.AddInfrastructureAws(appSettings);
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UserService, UserService>();
        services.AddSingleton<ValuesService, ValuesService>();

        return services;
    }
    
    private static IServiceCollection AddMessageHandler(this IServiceCollection services)
    {
        services.AddSingleton<IMessageHandler<UserCreated>, UserCreatedHandler>();

        return services;
    }
}