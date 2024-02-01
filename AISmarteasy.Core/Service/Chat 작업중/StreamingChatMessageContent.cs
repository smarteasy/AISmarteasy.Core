using System.Text;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class StreamingChatMessageContent(AuthorRole? role, string? content, object? innerContent = null,
        int choiceIndex = 0, string? modelId = null, Encoding? encoding = null,
        IReadOnlyDictionary<string, object?>? metadata = null)
    : StreamingMessageContent(innerContent, choiceIndex, modelId, metadata)
{
    public string? Content { get; set; } = content;

    public AuthorRole? Role { get; set; } = role;

    [JsonIgnore]
    public Encoding Encoding { get; set; } = encoding ?? Encoding.UTF8;

    public override string ToString() => Content ?? string.Empty;

    public override byte[] ToByteArray() => Encoding.GetBytes(ToString());
}