using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain.Services;
using Pickles.Infrastructure.Aws.Config;
using Pickles.Infrastructure.DotNet.Config;

namespace Pickles.Domain.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, AppSettings appSettings)
    {
        return services
            .AddServices()
            .AddAutoMapper(cfg => cfg.AllowNullCollections = true, Assembly.GetExecutingAssembly())
            .AddInfrastructureAws(appSettings)
            .AddInfrastructureDotNet();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UserService, UserService>();
        services.AddSingleton<ValuesService, ValuesService>();

        return services;
    }
}