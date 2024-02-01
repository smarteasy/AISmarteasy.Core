using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public sealed class UpsertResponse
{
    public UpsertResponse(int upsertedCount = default)
    {
        this.UpsertedCount = upsertedCount;
    }

    [JsonPropertyName("upsertedCount")]
    public int UpsertedCount { get; set; }
}
