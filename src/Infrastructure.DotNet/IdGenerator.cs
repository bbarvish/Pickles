using Pickles.Domain.Infrastructure;

namespace Pickles.Infrastructure.DotNet;

public class IdGenerator : IIdGenerator
{
    public string GenerateUniqueString()
    {
        return ByRandomizingEligibleCharacters();
    }

    private static string ByTruncatingNewGuid(int length=12)
    {
        return Guid.NewGuid().ToString("N")[..length];
    }
    
    private static readonly char[] EligibleCharacters =
    {
        '0','1','2','3','4','5','6','7','8','9',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 
        'j', 'k', 'q', 'r', 's', 't', 'u', 'v', 'w', 
        'x', 'y', 'z'
    };
    private static string ByRandomizingEligibleCharacters(int length=12)
    {
        var rand = new Random();
        var toReturn = string.Empty;

        for (var i = 0; i < length; i++)
        {
            toReturn += EligibleCharacters[rand.Next(0, EligibleCharacters.Length)];
        }
        return toReturn;
    }
}