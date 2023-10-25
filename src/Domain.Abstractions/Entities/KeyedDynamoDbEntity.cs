using EfficientDynamoDb.Attributes;

namespace Pickles.Domain.Entities;

public abstract class KeyedDynamoDbEntity<T>
{
    [DynamoDbProperty("pk", DynamoDbAttributeType.PartitionKey)]
    public string pk { get; set; }

    [DynamoDbProperty("sk", DynamoDbAttributeType.SortKey)]
    public string sk { get; set; }
    public abstract T SetKeys();
}