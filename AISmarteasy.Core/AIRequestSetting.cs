using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public class AIRequestSetting
{
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public double TopP { get; set; }

    [JsonPropertyName("presence_penalty")]
    public double PresencePenalty { get; set; }

    [JsonPropertyName("frequency_penalty")]
    public double FrequencyPenalty { get; set; }

    [JsonPropertyName("max_tokens")] public int? MaxTokens { get; set; } = DefaultMaxTokens;

    [JsonPropertyName("stop_sequences")]
    public IList<string> StopSequences { get; set; } = Array.Empty<string>();

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

    internal static string DefaultChatSystemPrompt { get; } = "Assistant is a large language model.";


    internal static int DefaultMaxTokens { get; } = 256;

    private string _chatSystemPrompt = DefaultChatSystemPrompt;

    public static AIRequestSetting FromCompletionConfig(PromptTemplateConfig.CompletionConfig config)
    {
        var settings = new AIRequestSetting
        {
            Temperature = config.Temperature,
            TopP = config.TopP,
            PresencePenalty = config.PresencePenalty,
            FrequencyPenalty = config.FrequencyPenalty,
            MaxTokens = config.MaxTokens,
            StopSequences = config.StopSequences,
        };

        if (!string.IsNullOrWhiteSpace(config.ChatSystemPrompt))
        {
            settings.ChatSystemPrompt = config.ChatSystemPrompt!;
        }

        return settings;
    }
}
