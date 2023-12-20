using System.Text.Json;

namespace AISmarteasy.Core;

public static class Json
{
    public static string Serialize(object? o) => JsonSerializer.Serialize(o, Options);

    public static T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, Options);

    public static string ToJson(this object o) => JsonSerializer.Serialize(o, Options);

    private static readonly JsonSerializerOptions Options = CreateOptions();

    private static JsonSerializerOptions CreateOptions()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            MaxDepth = 20,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
        };

        options.Converters.Add(new ReadOnlyMemoryConverter());

        return options;
    }
}