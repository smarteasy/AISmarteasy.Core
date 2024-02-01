using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class SparseVectorData(List<long> indices, ReadOnlyMemory<float> values)
{
    [JsonPropertyName("indices")]
    public IEnumerable<long> Indices { get; set; } = indices;

    [JsonPropertyName("values")]
    [JsonConverter(typeof(ReadOnlyMemoryConverter))]
    public ReadOnlyMemory<float> Values { get; set; } = values;

    public static SparseVectorData CreateSparseVectorData(List<long> indices, ReadOnlyMemory<float> values)
    {
        return new SparseVectorData(indices, values);
    }
}
