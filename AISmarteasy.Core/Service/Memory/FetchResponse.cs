using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public sealed class FetchResponse(Dictionary<string, MemoryDocument> vectors, string nameSpace = "")
{
    [JsonPropertyName("vectors")]
    public Dictionary<string, MemoryDocument> Vectors { get; set; } = vectors;

    public IEnumerable<MemoryDocument> WithoutEmbeddings()
    {
        return Vectors.Values.Select(v => MemoryDocument.Create(v.Id).WithMetadata(v.Metadata));
    }

    [JsonPropertyName("namespace")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Namespace { get; set; } = nameSpace;
}
