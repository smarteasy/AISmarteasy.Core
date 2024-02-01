namespace AISmarteasy.Core;

public sealed class ImageContent(Uri uri, string? modelId = null, object? innerContent = null, IReadOnlyDictionary<string, object?>? metadata = null)
    : MessageContent(innerContent, modelId, metadata)
{
    public Uri? Uri { get; set; } = uri;

    public override string ToString()
    {
        return Uri?.ToString() ?? string.Empty;
    }
}
