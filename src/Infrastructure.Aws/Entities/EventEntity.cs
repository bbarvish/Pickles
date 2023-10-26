using System.ComponentModel;
using EfficientDynamoDb.Attributes;

namespace Pickles.Infrastructure.Aws.Entities;

[DynamoDbTable(TableNames.Event)]
public class EventEntity : KeyedDynamoDbEntity<EventEntity>
{
    [DynamoDbProperty(nameof(AggregateId))]
    public string AggregateId { get; set; }
    [DynamoDbProperty(nameof(SequenceNumber))]
    public int SequenceNumber { get; set; }
    [DynamoDbProperty(nameof(EventType))]
    public string EventType { get; set; }
    [DynamoDbProperty(nameof(Data))]
    public string Data { get; set; }
    [DynamoDbProperty(nameof(OccurredOn))]
    public DateTime OccurredOn { get; set; }
    public override EventEntity SetKeys()
    {
        pk = AggregateId;
        sk = SequenceNumber.ToString();
        return this;
    }
}