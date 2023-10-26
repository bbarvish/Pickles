using Pickles.Domain.Aggregates;
using Pickles.Domain.Messaging;

namespace Pickles.Domain.Infrastructure;

public interface IAggregateService
{
    Task<int> AppendEvent(IEvent @event,
        string aggregateId,
        string aggregateType,
        int? aggregateVersion = null);

    Task<TAggregate> LoadFromHistory<TAggregate>(string aggregateId, int? maxVersion=null) where TAggregate : Aggregate,new();
}

internal class AggregateService : IAggregateService
{
    private readonly IEventStore _eventStore;
    private readonly IMessagingService _bus;

    public AggregateService(IEventStore eventStore, IMessagingService bus)
    {
        _eventStore = eventStore;
        _bus = bus;
    }
        
    public async Task<int> AppendEvent(IEvent @event,
        string aggregateId,
        string aggregateType, 
        int? aggregateVersion=null)
    {
        var toReturn = await _eventStore.Save(@event, aggregateId, aggregateType, aggregateVersion);
        await _bus.Publish(@event);

        return toReturn;
    }

    public async Task<TAggregate> LoadFromHistory<TAggregate>(string aggregateId, int? maxVersion=null) where TAggregate : Aggregate,new()
    {
        var events = await _eventStore.GetEventsBy(aggregateId);
        var toReturn = new TAggregate();
            
        foreach (var @event in events)
        {
            if (maxVersion.HasValue && @event.Key > maxVersion.Value) break;
                
            toReturn.Apply(@event.Value, @event.Key);
        }

        return toReturn;
    }
}