using Amazon.Runtime;
using EfficientDynamoDb;
using EfficientDynamoDb.Configs;
using EfficientDynamoDb.Credentials.AWSSDK;
using Microsoft.Extensions.DependencyInjection;
using Pickles.Domain;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Infrastructure.Repositories;
using Pickles.Infrastructure.Aws.Repositories;

namespace Pickles.Infrastructure.Aws.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureAws(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddDynamoDb(appSettings);

        services.AddSingleton<ClientFactory, ClientFactory>();
        services.AddSingleton<IEventStore, DynamoDbEventStore>();

        services.AddSingleton<IMessagingService, MessagingService>();
        services.AddAutoMapper(cfg => cfg.AddProfile(new AwsAutoMapperConfig()));
        return services;
    }

    private static IServiceCollection AddDynamoDb(this IServiceCollection services, AppSettings appSettings)
    {
        var awsSdkCredentials = FallbackCredentialsFactory.GetCredentials();
        var effDdbCredentials = awsSdkCredentials.ToCredentialsProvider();
        var config = new DynamoDbContextConfig(RegionEndpoint.Create(appSettings.AWS_REGION), effDdbCredentials);
        var context = new DynamoDbContext(config);
        
        services.AddSingleton<IDynamoDbContext>(context);
        return services;
    }
}