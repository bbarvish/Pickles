using System.Text.Json;

namespace Pickles.Infrastructure.DotNet.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object o)
    {
        return JsonSerializer.Serialize(o);
    }
    
    public static T? FromJson<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}