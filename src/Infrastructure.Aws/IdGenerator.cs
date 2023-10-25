using Pickles.Domain.Infrastructure;

namespace Pickles.Infrastructure.DotNet;

public class IdGenerator : IIdGenerator
{
    public string GenerateUniqueString()
    {
        return Guid.NewGuid().ToString("D").Substring(0,13);
    }
}