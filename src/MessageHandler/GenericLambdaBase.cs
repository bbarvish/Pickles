using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;

namespace Pickles.MessageHandler;

public abstract class GenericLambdaBase<T> : LambdaBase
{
    protected GenericLambdaBase()
    {
        
    }

    public virtual Task HandleCloudWatchEvent(CloudWatchEvent<T> cloudWatchEvent, ILambdaContext ctx)
    {
        return Task.CompletedTask;
    }
}