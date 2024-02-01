using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class IndexNamespaceStats(long vectorCount = default)
{
    [JsonPropertyName("vectorCount")]
    public long VectorCount { get; } = vectorCount;
}
