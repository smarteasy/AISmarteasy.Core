using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class MemoryQuery
{
    [JsonPropertyName("namespace")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Namespace { get; set; }

    [JsonPropertyName("topK")]
    public long TopK { get; set; }

    [JsonPropertyName("filter")]
    public Dictionary<string, object>? Filter { get; set; }

    [JsonPropertyName("vector")]
    public ReadOnlyMemory<float>? Vector { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; private set; }
    
    public string? Query { get; private set; }

    [JsonPropertyName("sparseVector")]
    public SparseVectorData? SparseVector { get; set; }

    [JsonPropertyName("includeValues")]
    public bool IsIncludeValues { get; set; }

    [JsonPropertyName("includeMetadata")]
    public bool IsIncludeMetadata { get; set; }

    private MemoryQuery()
    {
    }

    public static MemoryQuery Create(int topK = 1)
    {
        var result = new MemoryQuery
        {
            TopK = topK
        };

        return result;
    }

    public MemoryQuery InNamespace(string? indexNamespace)
    {
        Namespace = indexNamespace;
        return this;
    }

    public MemoryQuery WithFilter(Dictionary<string, object>? filter)
    {
        Filter = filter;
        return this;
    }

    public MemoryQuery WithId(string id)
    {
        Id = id;
        return this;
    }

    public MemoryQuery WithQuery(string query)
    {
        Query = query;
        return this;
    }

    public MemoryQuery WithVector(ReadOnlyMemory<float>? vector)
    {
        IsIncludeValues = true;
        Vector = vector;
        return this;
    }

    public MemoryQuery WithSparseVector(SparseVectorData? sparseVector)
    {
        SparseVector = sparseVector;
        return this;
    }

    public MemoryQuery WithMetadata()
    {
        IsIncludeMetadata = true;
        return this;
    }


    public HttpRequestMessage Build()
    {
        if (Filter != null)
        {
            Filter = MemoryUtil.ConvertFilter(Filter);
        }

        HttpRequestMessage request = HttpRequest.CreatePostRequest("/query", this);
        request.Headers.Add("accept", "application/json");

        return request;
    }
}
