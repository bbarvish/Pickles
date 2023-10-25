namespace Pickles.Domain.Infrastructure;

public interface IIdGenerator
{
    public string GenerateUniqueString();
}