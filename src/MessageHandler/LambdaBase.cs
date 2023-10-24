using Amazon.Lambda.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pickles.Domain;
using Pickles.MessageHandler.Config;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace Pickles.MessageHandler;

public abstract class LambdaBase
{
    protected readonly Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer JsonSerializer;
    private readonly IServiceProvider  _serviceProvider;

    protected LambdaBase()
    {
        JsonSerializer = new Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer();
            
        var appSettingsConfig = Infrastructure.DotNet.Configuration.AppConfigBuilder.Build();
        
        var appSettings = new AppSettings();
        appSettingsConfig.Bind(appSettings);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton(appSettings);
                services.AddDomain(appSettings);
            })
            .Build();
        
        var scope = host.Services.CreateScope();
        _serviceProvider = scope.ServiceProvider;
    }
    
    protected T Resolve<T>()
    {
        return _serviceProvider.GetService<T>();
    }
    
    protected  IEnumerable<T> ResolveMany<T>()
    {
        return _serviceProvider.GetServices<T>();
    }
}