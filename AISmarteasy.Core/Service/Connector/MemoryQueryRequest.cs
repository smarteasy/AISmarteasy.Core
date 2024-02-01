using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class MemoryQueryRequest : MemoryRequest
{
    public double MinRelevanceScore { get; set; }
    public int TopK { get; set; }
    public MemoryQuery MemoryQuery { get; set; }
    public string Id => MemoryQuery.Id?? string.Empty;
    public string Query => MemoryQuery.Query ?? string.Empty;
    public bool IsIncludeMetadata { get; set; } = false;

    public static MemoryQueryRequest Create(string collectionName, string collectionNamespace, MemoryQuery query, int topK = 1, double minRelevanceScore = 0)
    {
        return new MemoryQueryRequest(collectionName, collectionNamespace, query, topK, minRelevanceScore);
    }

    [JsonConstructor]
    private MemoryQueryRequest(string collectionName, string collectionNamespace, MemoryQuery query, int topK, double minRelevanceScore)
    : base(collectionName, collectionNamespace)
    {
        MemoryQuery = query;
        TopK = topK;
        MinRelevanceScore = minRelevanceScore;
    }
}