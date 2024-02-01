using System.Text.Json;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class MemoryQueryAnswer
{
    private static readonly JsonSerializerOptions IndentedJsonOptions = new() { WriteIndented = true };
    private static readonly JsonSerializerOptions NotIndentedJsonOptions = new() { WriteIndented = false };
    private static readonly JsonSerializerOptions CaseInsensitiveJsonOptions = new() { PropertyNameCaseInsensitive = true };

    [JsonPropertyName("query")]
    [JsonPropertyOrder(1)]
    public string Query { get; set; } = string.Empty;

    [JsonPropertyName("noResult")]
    [JsonPropertyOrder(2)]
    public bool NoResult { get; set; } = true;

    [JsonPropertyName("noResultReason")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NoResultReason { get; set; }

    [JsonPropertyName("text")]
    [JsonPropertyOrder(10)]
    public string Result { get; set; } = string.Empty;

    [JsonPropertyName("relevantSources")]
    [JsonPropertyOrder(20)]
    public List<MemoryCitation> RelevantSources { get; set; } = new();

    public string ToJson(bool indented = false)
    {
        return JsonSerializer.Serialize(this, indented ? IndentedJsonOptions : NotIndentedJsonOptions);
    }

    public MemoryQueryAnswer FromJson(string json)
    {
        return JsonSerializer.Deserialize<MemoryQueryAnswer>(json, CaseInsensitiveJsonOptions)
               ?? new MemoryQueryAnswer();
    }
}
