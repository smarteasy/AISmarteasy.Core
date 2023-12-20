namespace AISmarteasy.Core;

public interface IAIServiceConnector
{
    Task<ChatHistory> TextCompletionAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting, CancellationToken cancellationToken = default);
}
