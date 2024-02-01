using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class MemorySourceDocumentDetails : MemorySourceFileDetails
{
    [JsonPropertyOrder(24)]
    [JsonPropertyName("generated_files")]
    public Dictionary<string, MemoryGeneratedFileDetails> GeneratedFiles { get; set; } = new();

    public string GetPartitionFileName(int partitionNumber)
    {
        return $"{Name}.partition.{partitionNumber}.txt";
    }
}
