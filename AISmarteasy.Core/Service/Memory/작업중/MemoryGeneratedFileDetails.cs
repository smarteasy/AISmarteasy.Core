using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class MemoryGeneratedFileDetails
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("size")]
    public long Size { get; set; } = 0;

    [JsonPropertyOrder(3)]
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    [JsonPropertyName("tags")]
    public MemoryTagCollection Tags { get; set; } = new();
}
