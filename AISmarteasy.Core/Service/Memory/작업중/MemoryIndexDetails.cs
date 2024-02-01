using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class MemoryIndexDetails
{
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string Name { get; set; } = string.Empty;
}
