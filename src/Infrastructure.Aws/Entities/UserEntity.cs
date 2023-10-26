using EfficientDynamoDb.Attributes;
using Pickles.Domain;

namespace Pickles.Infrastructure.Aws.Entities;

[DynamoDbTable(TableNames.User)]
public class UserEntity : KeyedDynamoDbEntity<UserEntity>
{
    [DynamoDbProperty(nameof(Id))]
    public string Id { get; set; }
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
        pk = Id;
        sk = "primary";
        return this;
    }

    public static (string pk, string sk) GetKeys(string id)
    {
        return (id, "primary");
    }
}