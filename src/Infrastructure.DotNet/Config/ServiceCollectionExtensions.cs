using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain.Infrastructure;

namespace Pickles.Infrastructure.DotNet.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDotNet(this IServiceCollection services)
    {
        services.AddSingleton<IIdGenerator, IdGenerator>();

        return services;
    }
}