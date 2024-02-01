using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class MemoryCitation
{
    [JsonPropertyName("link")]
    [JsonPropertyOrder(1)]
    public string Link { get; set; } = string.Empty;

    [JsonPropertyName("index")]
    [JsonPropertyOrder(2)]
    public string Index { get; set; } = string.Empty;

    [JsonPropertyName("documentId")]
    [JsonPropertyOrder(3)]
    public string DocumentId { get; set; } = string.Empty;

    [JsonPropertyName("fileId")]
    [JsonPropertyOrder(4)]
    public string FileId { get; set; } = string.Empty;

    [JsonPropertyName("sourceContentType")]
    [JsonPropertyOrder(5)]
    public string SourceContentType { get; set; } = string.Empty;

    [JsonPropertyName("sourceName")]
    [JsonPropertyOrder(6)]
    public string SourceName { get; set; } = string.Empty;

    [JsonPropertyName("sourceUrl")]
    [JsonPropertyOrder(7)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SourceUrl { get; set; } = null;

    [JsonPropertyName("partitions")]
    [JsonPropertyOrder(8)]
    public List<Partition> Partitions { get; set; } = new();

    public class Partition
    {
        private MemoryTagCollection _tags = new();

        [JsonPropertyName("text")]
        [JsonPropertyOrder(1)]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("relevance")]
        [JsonPropertyOrder(2)]
        public float Relevance { get; set; } = 0;

        [JsonPropertyName("lastUpdate")]
        [JsonPropertyOrder(10)]
        public DateTimeOffset LastUpdate { get; set; } = DateTimeOffset.MinValue;

        [JsonPropertyName("tags")]
        [JsonPropertyOrder(100)]
        public MemoryTagCollection Tags
        {
            get => _tags;
            set
            {
                _tags = new();
                foreach (KeyValuePair<string, List<string?>> tag in value)
                {
                   _tags[tag.Key] = tag.Value;
                }
            }
        }
    }
}
