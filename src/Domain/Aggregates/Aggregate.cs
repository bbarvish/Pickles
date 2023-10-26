using Pickles.Domain.Messaging;

namespace Pickles.Domain.Aggregates;

public abstract class Aggregate
{
    public int Version { get; private set; }
    
    public void Apply(IEvent @event, int sequenceNumber)
    {
        Version = sequenceNumber;
        ApplyEvent(@event);
    }

    protected abstract void ApplyEvent(IEvent @event);
}