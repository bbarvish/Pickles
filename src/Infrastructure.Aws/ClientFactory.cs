using Amazon;
using Amazon.CloudWatchEvents;
using Amazon.S3;
using Pickles.Domain;

namespace Pickles.Infrastructure.Aws;

public class ClientFactory
{
    private readonly RegionEndpoint _regionEndpoint;

    public ClientFactory(AppSettings appSettings)
    {
        _regionEndpoint = RegionEndpoint.GetBySystemName(appSettings.AWS_REGION);
    }
    
    public AmazonS3Client GetS3Client()
    {
        return new AmazonS3Client(new AmazonS3Config
        {
            ForcePathStyle = true,
            RegionEndpoint = _regionEndpoint
        }); 
    }
    
    public AmazonCloudWatchEventsClient GetCloudWatchClient()
    {
        return new AmazonCloudWatchEventsClient(new AmazonCloudWatchEventsConfig
        {
            RegionEndpoint = _regionEndpoint
        });
    
    }
}