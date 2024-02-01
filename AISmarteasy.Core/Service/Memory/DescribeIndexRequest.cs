namespace AISmarteasy.Core;

public sealed class DescribeIndexRequest
{
    public string IndexName { get; }

    public static DescribeIndexRequest Create(string indexName)
    {
        return new DescribeIndexRequest(indexName);
    }

    public HttpRequestMessage Build()
    {
        HttpRequestMessage request = HttpRequest.CreateGetRequest($"/databases/{this.IndexName}");
        request.Headers.Add("accept", "application/json");
        return request;
    }

    private DescribeIndexRequest(string indexName)
    {
        IndexName = indexName;
    }
}
