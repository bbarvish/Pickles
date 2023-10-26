using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Services;
using Pickles.Infrastructure.DotNet;

namespace Pickles.Domain.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddServices()
            .AddAutoMapper(cfg => cfg.AllowNullCollections = true, Assembly.GetExecutingAssembly());
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<UserService, UserService>();
        services.AddSingleton<ValuesService, ValuesService>();
        services.AddSingleton<IIdGenerator, IdGenerator>();

        return services;
    }
}