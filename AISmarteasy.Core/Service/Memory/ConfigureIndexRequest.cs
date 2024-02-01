using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class ConfigureIndexRequest
{
    public string IndexName { get; set; }

    [JsonPropertyName("pod_type")]
    public PodTypeKind PodType { get; set; }

    [JsonPropertyName("replicas")]
    public int Replicas { get; set; }

    public static ConfigureIndexRequest Create(string indexName)
    {
        return new ConfigureIndexRequest(indexName);
    }

    public ConfigureIndexRequest WithPodType(PodTypeKind podType)
    {
        PodType = podType;
        return this;
    }

    public ConfigureIndexRequest NumberOfReplicas(int replicas)
    {
        Replicas = replicas;
        return this;
    }

    public HttpRequestMessage Build()
    {
        HttpRequestMessage request = HttpRequest.CreatePatchRequest($"/databases/{IndexName}", this);
        request.Headers.Add("accept", "text/plain");
        return request;
    }

    private ConfigureIndexRequest(string indexName)
    {
        IndexName = indexName;
    }
}
