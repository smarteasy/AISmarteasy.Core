using System.Text;
using System.Text.Json.Serialization;


namespace AISmarteasy.Core;

[method: JsonConstructor]
public class StreamingTextContent(string? text, int choiceIndex = 0, string? modelId = null,
        object? innerContent = null, Encoding? encoding = null, IReadOnlyDictionary<string, object?>? metadata = null)
    : StreamingMessageContent(innerContent, choiceIndex, modelId, metadata)
{
    public string? Text { get; } = text;

    [JsonIgnore]
    public Encoding Encoding { get; set; } = encoding ?? Encoding.UTF8;

    public override string ToString()
    {
        return Text ?? string.Empty;
    }

    /// <inheritdoc/>
    public override byte[] ToByteArray()
    {
        return Encoding.GetBytes(this.ToString());
    }
}
