using System.Diagnostics;

namespace AISmarteasy.Core;

internal sealed class MinHeap<T> : IEnumerable<T> where T : IComparable<T>
{
    private const int DEFAULT_CAPACITY = 7;
    private const int MIN_CAPACITY = 0;

    private static readonly T[] EmptyBuffer = Array.Empty<T>();

    private T[] _items;
    private int _count;

    public MinHeap(T minValue, int capacity = DEFAULT_CAPACITY)
    {
        if (capacity < MIN_CAPACITY)
        {
            Verifier.ThrowArgumentOutOfRangeException(nameof(capacity), capacity, $"MinHeap capacity must be greater than {MIN_CAPACITY}.");
        }

        _items = new T[capacity + 1];
        _items[0] = minValue;
    }

    public MinHeap(T minValue, IList<T> items)
        : this(minValue, items.Count)
    {
        Add(items);
    }

    public int Count
    {
        get => _count;
        internal set
        {
            Debug.Assert(value <= Capacity); 
            _count = value;
        }
    }

    public int Capacity => _items.Length - 1;

    public T this[int index]
    {
        get => _items[index + 1];
        internal set { _items[index + 1] = value; }
    }

    public T Top => _items[1];

    public bool IsEmpty => (_count == 0);

    public void Clear()
    {
        _count = 0;
    }

    public void Erase()
    {
        Array.Clear(_items, 1, _count);
        _count = 0;
    }

    public T[] DetachBuffer()
    {
        T[] buf = _items;
        _items = EmptyBuffer;
        _count = 0;
        return buf;
    }

    public void Add(T item)
    {
        _count++;
        EnsureCapacity();
        _items[_count] = item;
        UpHeap(_count);
    }

    public void Add(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public void Add(IList<T> items, int startAt = 0)
    {
        Verifier.NotNull(items);

        int newItemCount = items.Count;
        if (startAt >= newItemCount)
        {
            Verifier.ThrowArgumentOutOfRangeException(nameof(startAt), startAt, $"{nameof(startAt)} value must be less than {nameof(items)}.{nameof(items.Count)}.");
        }

        EnsureCapacity(_count + (newItemCount - startAt));
        for (int i = startAt; i < newItemCount; ++i)
        {
            _count++;
            _items[_count] = items[i];
            UpHeap(_count);
        }
    }

    public T RemoveTop()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("MinHeap is empty.");
        }

        T item = _items[1];
        _items[1] = _items[_count--];
        DownHeap(1);
        return item;
    }

    public IEnumerable<T> RemoveAll()
    {
        while (_count > 0)
        {
            yield return RemoveTop();
        }
    }

    public void EnsureCapacity(int capacity)
    {
        if (capacity < MIN_CAPACITY)
        {
            Verifier.ThrowArgumentOutOfRangeException(nameof(capacity), capacity, $"MinHeap capacity must be greater than {MIN_CAPACITY}.");
        }

        capacity++;
        if (capacity > _items.Length)
        {
            Array.Resize(ref _items, capacity);
        }
    }

    public void EnsureCapacity()
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, (_count * 2) + 1);
        }
    }

    private void UpHeap(int startAt)
    {
        int i = startAt;
        T[] items = _items;
        T item = items[i];
        int parent = i >> 1; 

        while (parent > 0 && items[parent].CompareTo(item) > 0)
        { 
            items[i] = items[parent];
            i = parent;
            parent = i >> 1; 
        }

        items[i] = item;
    }

    private void DownHeap(int startAt)
    {
        int i = startAt;
        int count = _count;
        int maxParent = count >> 1;
        T[] items = _items;
        T item = items[i];

        while (i <= maxParent)
        {
            int child = i + i;
            if (child < count && items[child].CompareTo(items[child + 1]) > 0)
            {
                child++;
            }

            if (item.CompareTo(items[child]) <= 0)
            {
                break;
            }

            items[i] = items[child];
            i = child;
        }

        items[i] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 1; i <= _count; ++i)
        {
            yield return _items[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void SortDescending()
    {
        int count = _count;
        int i = count; 

        while (_count > 0)
        {
            T item = RemoveTop();
            _items[i--] = item;
        }

        _count = count;
    }

    internal void Restore()
    {
        Clear();
        Add(_items, 1);
    }

    internal void Sort(IComparer<T> comparer)
    {
        Array.Sort(_items, 1, _count, comparer);
    }
}
