using EfficientDynamoDb;
using Pickles.Domain.Infrastructure;
using Pickles.Domain.Messaging;
using Pickles.Infrastructure.Aws.Entities;

namespace Pickles.Infrastructure.Aws;

public class DynamoDbEventStore : IEventStore
{
    private readonly IDynamoDbContext _dbContext;

    public DynamoDbEventStore(IDynamoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Save(IEvent @event, string aggregateId, string aggregateType, int? aggregateVersion = null)
    {
        var currentAggregate = await _dbContext.GetItemAsync<AggregateEntity>(aggregateType, aggregateId);
        var foundVersion = currentAggregate?.Version;
        
        if (foundVersion.HasValue && foundVersion != aggregateVersion)
            throw new Exception("concurrency exception");
                    
        var sequenceNumber = aggregateVersion + 1 ?? 0;
        
        var eventEntity = new EventEntity
        {
            AggregateId = aggregateId,
            EventType = @event.GetType().FullName,
            Data = @event.ToJson(),
            OccurredOn = DateTime.UtcNow,
            SequenceNumber = sequenceNumber
        }.SetKeys();
        
        var aggregateEntity = new AggregateEntity
        {
            AggregateId = aggregateId,
            AggregateType = aggregateType,
            Version = sequenceNumber
        }.SetKeys();

        await Task.WhenAll(_dbContext.PutItemAsync(eventEntity), _dbContext.PutItemAsync(aggregateEntity));

        return sequenceNumber;
    }

    public async Task<IDictionary<int, IEvent>> GetEventsBy(string aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task<int?> GetCurrentVersionNumberOf(string aggregateId)
    {
        throw new NotImplementedException();
    }
}