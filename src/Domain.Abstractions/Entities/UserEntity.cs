using EfficientDynamoDb.Attributes;

namespace Pickles.Domain.Entities;

[DynamoDbTable(TableNames.User)]
public class UserEntity : DynamoDbEntity<UserEntity>
{
    [DynamoDbProperty(nameof(FirstName))]
    public string FirstName { get; set; }
    
    [DynamoDbProperty(nameof(LastName))]
    public string LastName { get; set; }
    
    [DynamoDbProperty(nameof(Email))]
    public string Email { get; set; }
    [DynamoDbProperty(nameof(Phone))]
    public string Phone { get; set; }
    public DateTime AddedOn { get; set; }
    public override UserEntity SetKeys()
    {
        var emailParts = ParseEmail(Email);
        pk = emailParts.domain;
        sk = emailParts.userName;
        return this;
    }

    public static (string userName, string domain) ParseEmail(string email)
    {
        var emailParts = email.Split("@");
        return (emailParts.First(), emailParts.Last());
    }
}

public abstract class DynamoDbEntity<T>
{
    [DynamoDbProperty("pk", DynamoDbAttributeType.PartitionKey)]
    public string pk { get; set; }

    [DynamoDbProperty("sk", DynamoDbAttributeType.SortKey)]
    public string sk { get; set; }
    public abstract T SetKeys();
}