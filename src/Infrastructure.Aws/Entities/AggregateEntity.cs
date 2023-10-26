using EfficientDynamoDb.Attributes;

namespace Pickles.Infrastructure.Aws.Entities;

[DynamoDbTable(TableNames.Aggregate)]
public class AggregateEntity : KeyedDynamoDbEntity<AggregateEntity>
{
    [DynamoDbProperty(nameof(AggregateType))]
    public string AggregateType { get; set; }
    [DynamoDbProperty(nameof(AggregateId))]
    public string AggregateId { get; set; }
    [DynamoDbProperty(nameof(Version))]
    public int Version { get; set; }
    
    public override AggregateEntity SetKeys()
    {
        pk = AggregateType;
        sk = AggregateId;
        return this;
    }
}