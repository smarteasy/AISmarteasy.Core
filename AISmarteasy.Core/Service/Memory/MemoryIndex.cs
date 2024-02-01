using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public sealed class MemoryIndex(IndexDefinition configuration, IndexStatus status)
{
    [JsonPropertyName("database")]
    public IndexDefinition Configuration { get; set; } = configuration;

    [JsonPropertyName("status")]
    public IndexStatus Status { get; set; } = status;
}