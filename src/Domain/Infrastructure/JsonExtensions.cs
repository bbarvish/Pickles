using System.Text.Json;

// ReSharper disable once CheckNamespace
namespace System;

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