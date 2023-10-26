using Amazon.CloudWatchEvents.Model;
using MoreLinq.Extensions;
using Pickles.Domain;
using Pickles.Domain.Events;
using Pickles.Domain.Infrastructure;

namespace Pickles.Infrastructure.Aws;

public class MessagingService : IMessagingService
{
    private readonly ClientFactory _clientFactory;
    private readonly AppSettings _appSettings;

    public MessagingService(ClientFactory clientFactory, AppSettings appSettings)
    {
        _clientFactory = clientFactory;
        _appSettings = appSettings;
    }
    public async Task Publish<T>(T message)
    {
        await PublishMany(new[] {message});
    }

    public async Task PublishMany<T>(IEnumerable<T> messages)
    {
        await PublishManyInternal(messages);
    }

    public Task Send<T>(string destination, T message)
    {
        return Task.CompletedTask;
    }

    private async Task PublishManyInternal<T>(IEnumerable<T> message)
    {
        var entries = new List<PutEventsRequestEntry>();

        message.ForEach(m =>
        {
            var eventToSend = BuildEvent(m);
            
            entries.Add(
                new PutEventsRequestEntry
                {
                    Detail = eventToSend.ToJson(),
                    DetailType = eventToSend.EventType,
                    Source = "Api",
                    EventBusName = _appSettings.MessagingOptions.BusName,
                    Time = DateTime.UtcNow
                });     
        });

        //TODO: wrap with Polly 
        await _clientFactory.GetCloudWatchClient().PutEventsAsync(
            new PutEventsRequest
            {
                Entries = entries
            });
    }

    private AnyEvent BuildEvent<T>(T message)
    {
        return new AnyEvent
        {
            DataPayload = message.ToJson(),
            EventType = message.GetType().FullName
        };
    }
}