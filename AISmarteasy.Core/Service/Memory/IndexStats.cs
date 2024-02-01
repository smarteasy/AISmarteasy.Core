using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class IndexStats(Dictionary<string, IndexNamespaceStats> namespaces,
    int dimension = default, float indexFullness = default, long totalVectorCount = default)
{
    [JsonPropertyName("namespaces")]
    public Dictionary<string, IndexNamespaceStats> Namespaces { get; set; } = namespaces;

    [JsonPropertyName("dimension")]
    public int Dimension { get; set; } = dimension;

    [JsonPropertyName("indexFullness")]
    public float IndexFullness { get; set; } = indexFullness;

    [JsonPropertyName("totalVectorCount")]
    public long TotalVectorCount { get; set; } = totalVectorCount;
}
