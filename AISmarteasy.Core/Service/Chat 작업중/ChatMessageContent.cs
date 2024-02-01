using System.Text;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class ChatMessageContent : MessageContent
{
    public AuthorRole Role { get; set; }

    public string? Content { get; set; }

    public ChatMessageContentItemCollection? Items { get; set; }

    [JsonIgnore]
    public Encoding Encoding { get; set; }

    [JsonConstructor]
    public ChatMessageContent(AuthorRole role,
        string? content, string? modelId = null, object? innerContent = null, Encoding? encoding = null, 
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(innerContent, modelId, metadata)
    {
        Role = role;
        Content = content;
        Encoding = encoding ?? Encoding.UTF8;
    }

    public ChatMessageContent(AuthorRole role, ChatMessageContentItemCollection items,
        string? modelId = null, object? innerContent = null, Encoding? encoding = null, 
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(innerContent, modelId, metadata)
    {
        Role = role;
        Encoding = encoding ?? Encoding.UTF8;
        Items = items;
    }

    public override string ToString()
    {
        return Content ?? string.Empty;
    }
}
