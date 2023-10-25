using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain.Services;
using Pickles.Infrastructure.Aws.Config;

namespace Pickles.Domain.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddServices();
        
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
}