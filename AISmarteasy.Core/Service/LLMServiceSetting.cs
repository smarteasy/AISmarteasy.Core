using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class LLMServiceSetting
{
    internal static int DefaultMaxTokens { get; } = 256;
    internal static string DefaultChatSystemPrompt { get; } = "Assistant is a large language model.";
    private string _chatSystemPrompt = DefaultChatSystemPrompt;

    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public double TopP { get; set; }

    [JsonPropertyName("presence_penalty")]
    public double PresencePenalty { get; set; } 

    [JsonPropertyName("frequency_penalty")]
    public double FrequencyPenalty { get; set; }

    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; } = DefaultMaxTokens;

    [JsonPropertyName("stop_sequences")]
    public List<string> StopSequences { get; set; } = new();

    [JsonPropertyName("results_per_prompt")]
    public int ResultsPerPrompt { get; set; } = 1;

    [JsonPropertyName("chat_system_prompt")]
    public string ChatSystemPrompt
    {
        get => _chatSystemPrompt;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                value = DefaultChatSystemPrompt;
            }
            _chatSystemPrompt = value;
        }
    }

    [JsonPropertyName("token_selection_biases")]
    public IDictionary<int, int>? TokenSelectionBiases { get; set; }
}
