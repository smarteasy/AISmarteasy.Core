using System.Collections;
using System.Text;

namespace AISmarteasy.Core;

public class ChatHistory : IList<ChatMessageContent>, IReadOnlyList<ChatMessageContent>
{
    private readonly List<ChatMessageContent> _messages;

    public ChatMessageContent LastContent => _messages.Last();

    public ChatHistory()
    {
        _messages = new List<ChatMessageContent>();
    }

    public ChatHistory(string systemMessage)
    {
        Verifier.NotNullOrWhitespace(systemMessage);

        _messages = new();
        AddSystemMessage(systemMessage);
    }

    public ChatHistory(IEnumerable<ChatMessageContent> messages)
    {
        Verifier.NotNull(messages);
        _messages = new List<ChatMessageContent>(messages);
    }

    public int Count => _messages.Count;

    public void AddMessage(AuthorRole authorRole, string content, Encoding? encoding = null, IReadOnlyDictionary<string, object?>? metadata = null) 
        => Add(new ChatMessageContent(authorRole, content, null, null, encoding, metadata));

    public void AddMessage(AuthorRole authorRole, ChatMessageContentItemCollection contentItems, Encoding? encoding = null, IReadOnlyDictionary<string, object?>? metadata = null) =>
        Add(new ChatMessageContent(authorRole, contentItems, null, null, encoding, metadata));

    public void AddUserMessage(string content) => AddMessage(AuthorRole.User, content);

    public void AddUserMessage(ChatMessageContentItemCollection contentItems) => AddMessage(AuthorRole.User, contentItems);

    public void AddAssistantMessage(string content) => AddMessage(AuthorRole.Assistant, content);

    public void AddSystemMessage(string content) => AddMessage(AuthorRole.System, content);

    public void Add(ChatMessageContent contentItem)
    {
        Verifier.NotNull(contentItem);
        _messages.Add(contentItem);
    }

    public void AddRange(IEnumerable<ChatMessageContent> items)
    {
        Verifier.NotNull(items);
        _messages.AddRange(items);
    }

    public void Insert(int index, ChatMessageContent item)
    {
        Verifier.NotNull(item);
        _messages.Insert(index, item);
    }

    public void CopyTo(ChatMessageContent[] array, int arrayIndex) => _messages.CopyTo(array, arrayIndex);

    public void Clear() => _messages.Clear();

    public ChatMessageContent this[int index]
    {
        get => _messages[index];
        set
        {
            Verifier.NotNull(value);
            _messages[index] = value;
        }
    }

    public bool Contains(ChatMessageContent item)
    {
        Verifier.NotNull(item);
        return _messages.Contains(item);
    }

    public int IndexOf(ChatMessageContent item)
    {
        Verifier.NotNull(item);
        return _messages.IndexOf(item);
    }

    public void RemoveAt(int index) => _messages.RemoveAt(index);

    public bool Remove(ChatMessageContent item)
    {
        Verifier.NotNull(item);
        return _messages.Remove(item);
    }

    public void RemoveRange(int index, int count)
    {
        _messages.RemoveRange(index, count);
    }

    bool ICollection<ChatMessageContent>.IsReadOnly => false;

    IEnumerator<ChatMessageContent> IEnumerable<ChatMessageContent>.GetEnumerator() => _messages.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _messages.GetEnumerator();
}
