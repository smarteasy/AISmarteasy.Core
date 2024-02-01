using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[method: JsonConstructor]
public class IndexStatus(string host, int port = default, IndexState? state = default, bool ready = false)
{
    [JsonPropertyName("state")]
    public IndexState? State { get; set; } = state;

    [JsonPropertyName("host")]
    public string Host { get; set; } = host;

    [JsonPropertyName("port")]
    public int Port { get; set; } = port;

    [JsonPropertyName("ready")]
    public bool Ready { get; set; } = ready;
}
