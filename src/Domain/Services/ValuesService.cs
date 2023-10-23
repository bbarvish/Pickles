namespace Pickles.Domain.Services;

public class ValuesService
{
    public async Task<string> Get(int id)
    {
        return $"{id} is awesome";
    }
}