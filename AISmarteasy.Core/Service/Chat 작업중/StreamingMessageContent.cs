using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public abstract class StreamingMessageContent(object? innerContent, int choiceIndex = 0, string? modelId = null, 
    IReadOnlyDictionary<string, object?>? metadata = null)
{
    public int ChoiceIndex { get; } = choiceIndex;

    [JsonIgnore]
    public object? InnerContent { get; } = innerContent;

    public string? ModelId { get; } = modelId;

    public IReadOnlyDictionary<string, object?>? Metadata { get; } = metadata;

    public abstract override string ToString();

    public abstract byte[] ToByteArray();
}
