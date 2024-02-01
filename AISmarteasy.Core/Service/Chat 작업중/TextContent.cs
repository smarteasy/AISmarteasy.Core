using System.Text;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class TextContent(string? text, string? modelId = null, object? innerContent = null,
        Encoding? encoding = null, IReadOnlyDictionary<string, object?>? metadata = null)
    : MessageContent(innerContent, modelId, metadata)
{
    public string? Text { get; set; } = text;

    [JsonIgnore]
    public Encoding Encoding { get; set; } = encoding ?? Encoding.UTF8;

    public override string ToString()
    {
        return Text ?? string.Empty;
    }
}
