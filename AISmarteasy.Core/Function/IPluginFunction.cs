namespace AISmarteasy.Core;

public interface IPluginFunction
{
    string Name { get; }
    string PluginName { get; }
    public bool IsSemantic { get; }

    Task<ChatHistory> RunAsync(ITextCompletionConnector serviceConnector, LLMServiceSetting serviceSetting, CancellationToken cancellationToken = default);
    IAsyncEnumerable<ChatStreamingResult> RunStreamingAsync(ITextCompletionConnector serviceConnector, LLMServiceSetting serviceSetting, CancellationToken cancellationToken = default);
    string ToFullyQualifiedName();
    string ToManualString();
}
