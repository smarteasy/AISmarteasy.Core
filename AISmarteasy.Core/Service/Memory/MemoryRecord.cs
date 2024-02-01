using System.Text.Json;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class MemoryRecord(MemoryRecordMetadata metadata, ReadOnlyMemory<float> embedding,
        string? key, DateTimeOffset? timestamp = null) : DataEntryBase(key, timestamp)
{
    [JsonPropertyName("embedding")]
    [JsonConverter(typeof(ReadOnlyMemoryConverter))]
    public ReadOnlyMemory<float> Embedding { get; } = embedding;

    [JsonPropertyName("metadata")]
    public MemoryRecordMetadata Metadata { get; } = metadata;

    public static MemoryRecord ReferenceRecord(string externalId, string sourceName, string? description, 
        ReadOnlyMemory<float> embedding, string? additionalMetadata = null, string? key = null, DateTimeOffset? timestamp = null)
    {
        return new MemoryRecord(
            new MemoryRecordMetadata
            (
                isReference: true,
                externalSourceName: sourceName,
                id: externalId,
                description: description ?? string.Empty,
                text: string.Empty,
                additionalMetadata: additionalMetadata ?? string.Empty
            ),
            embedding,
            key,
            timestamp
        );
    }

    public static MemoryRecord LocalRecord(string id, string text, string? description, ReadOnlyMemory<float> embedding,
        string? additionalMetadata = null, string? key = null, DateTimeOffset? timestamp = null)
    {
        return new MemoryRecord
        (
            new MemoryRecordMetadata
            (
                isReference: false,
                id: id,
                text: text,
                description: description ?? string.Empty,
                externalSourceName: string.Empty,
                additionalMetadata: additionalMetadata ?? string.Empty
            ),
            embedding,
            key,
            timestamp
        );
    }

    public static MemoryRecord FromJsonMetadata(string json, ReadOnlyMemory<float> embedding, 
        string? key = null, DateTimeOffset? timestamp = null)
    {
        var metadata = JsonSerializer.Deserialize<MemoryRecordMetadata>(json);
        return metadata != null
            ? new MemoryRecord(metadata, embedding, key, timestamp)
            : throw new CoreException("Unable to create memory record from serialized metadata");
    }

    public static MemoryRecord FromMetadata(MemoryRecordMetadata metadata, ReadOnlyMemory<float> embedding,
        string? key = null, DateTimeOffset? timestamp = null)
    {
        return new MemoryRecord(metadata, embedding, key, timestamp);
    }

    public MemoryDocument ToMemoryDocument()
    {
        string key = !string.IsNullOrEmpty(Key) ? Key : Metadata.Id;

        Dictionary<string, object> metadata = new()
        {
            ["document_Id"] = Metadata.Id,
            ["text"] = Metadata.Text,
            ["source_Id"] = Metadata.ExternalSourceName,
            ["created_at"] = HasTimestamp
                ? Timestamp?.ToString("o") ?? DateTimeOffset.UtcNow.ToString("o")
                : DateTimeOffset.UtcNow.ToString("o")
        };

        if (!string.IsNullOrEmpty(Metadata.AdditionalMetadata))
        {
            JsonSerializerOptions options = MemoryUtil.DefaultSerializerOptions;
            var additionalMetaData = JsonSerializer.Deserialize<Dictionary<string, object>>(Metadata.AdditionalMetadata, options);

            if (additionalMetaData != null)
            {
                foreach (var item in additionalMetaData)
                {
                    metadata[item.Key] = item.Value;
                }
            }
        }

        return MemoryDocument.Create(key, Embedding).WithMetadata(metadata);
    }

    public string GetSerializedMetadata()
    {
        return JsonSerializer.Serialize(Metadata);
    }
}
