using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;
using Pickles.Domain;

namespace Pickles.MessageHandler;

public class Function : LambdaBase
{
    private readonly AppSettings _appSettings;
    public Function()
    {
        _appSettings = Resolve<AppSettings>();
    }
    public void FunctionHandler(CloudWatchEvent<object> cwEvent, ILambdaContext context)
    {
        context.Logger.LogInformation($"I see {cwEvent.ToJson()}");
        context.Logger.LogInformation($"App settings is: {_appSettings.ToJson()}");
    }
}