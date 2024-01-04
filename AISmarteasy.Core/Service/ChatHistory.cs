namespace AISmarteasy.Core;

public class ChatHistory : List<ChatMessageBase>
{
    private sealed class ChatMessage : ChatMessageBase
    {
        public ChatMessage(AuthorRole authorRole, string message)
            : base(authorRole, message)
        {
        }
    }

    public List<ChatMessageBase> Messages => this;

    public void AddSystemMessage(string message)
    {
        AddMessage(AuthorRole.System, message);
    }

    public void AddUserMessage(string message)
    {
        AddMessage(AuthorRole.User, message);
    }
    public void AddAssistantMessage(string message)
    {
        AddMessage(AuthorRole.Assistant, message);
    }

    public void AddMessage(AuthorRole authorRole, string message)
    {
        Add(new ChatMessage(authorRole, message));
        LastContent = message;
        PipelineLastContent = message;
    }

    public string LastContent { get; set; } = string.Empty;
    public string PipelineLastContent { get; set; } = string.Empty;

    public int GetTokenCount(string? additionalMessage = null, int skipStart = 0, int skipCount = 0, TextChunker.TokenCounter? tokenCounter = null)
    {
        tokenCounter ??= DefaultTokenCounter;

        var messages = string.Join("\n", this.Where((_, i) => i < skipStart || i >= skipStart + skipCount).Select(m => m.Content));

        if (!string.IsNullOrEmpty(additionalMessage))
        {
            messages = $"{messages}\n{additionalMessage}";
        }

        var tokenCount = tokenCounter(messages);
        return tokenCount;
    }

    private static int DefaultTokenCounter(string input)
    {
        return input.Length / 4;
    }
}
