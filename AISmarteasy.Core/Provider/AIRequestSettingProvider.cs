namespace AISmarteasy.Core;


public static class AIRequestSettingProvider
{
    public static AIRequestSetting ProvideFromCompletionConfig(PromptTemplateConfig.CompletionConfig config)
    {
        return FromCompletionConfig(new PromptTemplateConfig().Completion);
    }

    private static AIRequestSetting FromCompletionConfig(PromptTemplateConfig.CompletionConfig config)
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
