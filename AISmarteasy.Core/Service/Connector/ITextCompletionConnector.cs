namespace AISmarteasy.Core;

public interface ITextCompletionConnector : IAIServiceConnector
{
    Task<ChatHistory> RunAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting, CancellationToken cancellationToken = default);
    IAsyncEnumerable<ChatStreamingResult> RunStreamingAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting, CancellationToken cancellationToken = default);
}
