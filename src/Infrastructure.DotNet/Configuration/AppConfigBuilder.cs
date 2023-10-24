using Microsoft.Extensions.Configuration;

namespace Pickles.Infrastructure.DotNet.Configuration;

public static class AppConfigBuilder
{
    public static IConfigurationRoot Build()
    {
        var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
        
        var appSettingsConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();

        return appSettingsConfig;
    }
}