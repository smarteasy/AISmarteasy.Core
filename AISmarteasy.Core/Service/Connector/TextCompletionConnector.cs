namespace AISmarteasy.Core;

public abstract class TextCompletionConnector : AIServiceConnector, ITextCompletionConnector
{
    public abstract Task<ChatHistory> RunAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting,
        CancellationToken cancellationToken = default);
    public abstract IAsyncEnumerable<ChatStreamingResult> RunStreamingAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting,
        CancellationToken cancellationToken = default);
}