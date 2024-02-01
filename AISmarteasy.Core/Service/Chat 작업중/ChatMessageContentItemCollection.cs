using System.Collections;

namespace AISmarteasy.Core;

public class ChatMessageContentItemCollection : IList<MessageContent>, IReadOnlyList<MessageContent>
{
    public MessageContent this[int index]
    {
        get => _items[index];
        set
        {
            Verifier.NotNull(value);
            _items[index] = value;
        }
    }

    public int Count => _items.Count;

    public void Add(MessageContent item)
    {
        Verifier.NotNull(item);
        _items.Add(item);
    }

    public void Clear() => _items.Clear();

    public bool Contains(MessageContent item)
    {
        Verifier.NotNull(item);
        return _items.Contains(item);
    }

    public void CopyTo(MessageContent[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public int IndexOf(MessageContent item)
    {
        Verifier.NotNull(item);
        return _items.IndexOf(item);
    }

    public void Insert(int index, MessageContent item)
    {
        Verifier.NotNull(item);
        _items.Insert(index, item);
    }

    public bool Remove(MessageContent item)
    {
        Verifier.NotNull(item);
        return _items.Remove(item);
    }

    public void RemoveAt(int index) => _items.RemoveAt(index);

    bool ICollection<MessageContent>.IsReadOnly => false;

    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

    IEnumerator<MessageContent> IEnumerable<MessageContent>.GetEnumerator() => _items.GetEnumerator();

    private readonly List<MessageContent> _items = new();
}
