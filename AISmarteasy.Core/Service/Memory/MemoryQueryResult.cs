using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class MemoryQueryResult(MemoryRecordMetadata metadata, double relevance, ReadOnlyMemory<float>? embedding)
{
    public MemoryRecordMetadata Metadata { get; } = metadata;

    public double Relevance { get; } = relevance;

    [JsonConverter(typeof(ReadOnlyMemoryConverter))]
    public ReadOnlyMemory<float>? Embedding { get; } = embedding;

    public static MemoryQueryResult FromMemoryRecord(MemoryRecord record, double relevance)
    {
        return new MemoryQueryResult((MemoryRecordMetadata)record.Metadata.Clone(),
            relevance, record.Embedding.IsEmpty ? null : record.Embedding);
    }
}
