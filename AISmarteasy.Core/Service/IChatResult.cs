namespace AISmarteasy.Core;

public interface IChatResult
{
    ModelResult ModelResult { get; }

    Task<ChatMessageContent> GetChatMessageAsync(CancellationToken cancellationToken = default);
}
