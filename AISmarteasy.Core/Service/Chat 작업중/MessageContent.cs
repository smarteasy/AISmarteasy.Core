using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public abstract class MessageContent(object? innerContent, 
    string? modelId = null, IReadOnlyDictionary<string, object?>? metadata = null)
{
    [JsonIgnore]
    public object? InnerContent { get; } = innerContent;

    public string? ModelId { get; } = modelId;

    public IReadOnlyDictionary<string, object?>? Metadata { get; } = metadata;
}