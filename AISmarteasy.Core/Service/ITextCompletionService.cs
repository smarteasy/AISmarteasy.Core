namespace AISmarteasy.Core;

public interface ITextCompletionService : ILLMService
{
    Task<string> RunAsync(string prompt, LLMServiceSetting serviceSetting, CancellationToken cancellationToken = default);


    //IAsyncEnumerable<TextStreamingResult> RunTextStreamingCompletionAsync(string prompt, AIRequestSettings requestSettings, CancellationToken cancellationToken = default);



    //Task<ChatHistory> RunChatAsync(ChatHistory chatHistory, LLMRequestSetting requestSetting, CancellationToken cancellationToken = default);
    
    //IAsyncEnumerable<IChatStreamingResult> RunChatStreamingCompletionAsync(ChatHistory chatHistory, AIRequestSettings requestSettings, CancellationToken cancellationToken = default);
    //ChatHistory CreateNewChat(string systemMessage);
    //Task<string> GenerateMessageAsync(ChatHistory chat, AIRequestSettings requestSettings, CancellationToken cancellationToken = default);



}
