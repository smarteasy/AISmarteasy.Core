using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class MemoryRecordMetadata(bool isReference, string id, string text, string description, 
        string externalSourceName, string additionalMetadata) : ICloneable
{
    [JsonInclude]
    [JsonPropertyName("is_reference")]
    public bool IsReference { get; } = isReference;

    [JsonInclude]
    [JsonPropertyName("external_source_name")]
    public string ExternalSourceName { get; } = externalSourceName;

    [JsonInclude]
    [JsonPropertyName("id")]
    public string Id { get; } = id;

    [JsonInclude]
    [JsonPropertyName("description")]
    public string Description { get; } = description;

    [JsonInclude]
    [JsonPropertyName("text")]
    public string Text { get; } = text;

    [JsonInclude]
    [JsonPropertyName("additional_metadata")]
    public string AdditionalMetadata { get; } = additionalMetadata;

    public object Clone()
    {
        return MemberwiseClone();
    }
}

