namespace AISmarteasy.Core;

public interface IAIServiceConnector
{
    Task GenerateAudioAsync(AudioGenerationRequest request);
    Task<Stream> GenerateAudioStreamAsync(AudioGenerationRequest request);

    Task<string> GenerateImageAsync(ImageGenerationRequest request, CancellationToken cancellationToken = default);

    Task<string> RunSpeechToTextAsync(SpeechToTextRunRequest request, CancellationToken cancellationToken = default);

    Task<ChatHistory> RunTextCompletionAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting, CancellationToken cancellationToken = default);

    IAsyncEnumerable<ChatStreamingResult> RunTextCompletionStreamingAsync(ChatHistory chatHistory, LLMServiceSetting requestSetting, CancellationToken cancellationToken = default);
}
