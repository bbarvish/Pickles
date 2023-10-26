using Pickles.Domain.Messaging;

namespace Pickles.Domain.Infrastructure;

public interface IEventStore
{
    /// <summary>
    /// Saves the event and returns the latest aggregate version number
    /// </summary>
    Task<int> Save(IEvent @event, string aggregateId, string aggregateType, int? aggregateVersion=null);
    Task<IDictionary<int, IEvent>> GetEventsBy(string aggregateId);
    Task<int?> GetCurrentVersionNumberOf(string aggregateId);

    Task Bootstrap();
}