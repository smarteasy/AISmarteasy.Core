using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class MemoryQueryResponse(List<MemoryDocument> matches, string? nameSpace = default)
{
    [JsonPropertyName("matches")]
    public List<MemoryDocument> Matches { get; set; } = matches;

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; } = nameSpace;
}
