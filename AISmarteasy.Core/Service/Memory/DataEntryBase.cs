using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class DataEntryBase(string? key = null, DateTimeOffset? timestamp = null)
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = key ?? string.Empty;

    [JsonPropertyName("timestamp")]
    public DateTimeOffset? Timestamp { get; set; } = timestamp;

    [JsonIgnore]
    public bool HasTimestamp => Timestamp.HasValue;
}
