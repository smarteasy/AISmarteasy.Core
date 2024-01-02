namespace AISmarteasy.Core;

public interface IChatResult
{
    ModelResult ModelResult { get; }

    Task<ChatMessageBase> GetChatMessageAsync(CancellationToken cancellationToken = default);
}
