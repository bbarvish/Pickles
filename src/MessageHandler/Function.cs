using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;
using Pickles.Domain.Extensions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Pickles.MessageHandler;

public class Function
{
    public void FunctionHandler(CloudWatchEvent<object> cwEvent, ILambdaContext context)
    {
        context.Logger.LogInformation($"I see {cwEvent.ToJson()}");
    }
}