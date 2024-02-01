using System.Collections;

namespace AISmarteasy.Core;

public sealed class TopNCollection<T>(int topK) : IEnumerable<ScoredValue<T>>
{
    private readonly MinHeap<ScoredValue<T>> _heap = new MinHeap<ScoredValue<T>>(ScoredValue<T>.Min(), topK);
    private bool _sorted;

    public int MaxItems { get; } = topK;

    public int Count => _heap.Count;

    internal ScoredValue<T> this[int i] => _heap[i];
    internal ScoredValue<T> Top => _heap.Top;

    public void Reset()
    {
        _heap.Clear();
    }

    public void Add(ScoredValue<T> value)
    {
        if (_sorted)
        {
            _heap.Restore();
            _sorted = false;
        }

        if (_heap.Count == MaxItems)
        {
            if (value.Score <= Top.Score)
            {
                return;
            }

            _heap.RemoveTop();
        }

        _heap.Add(value);
    }

    public void Add(T value, double score)
    {
        Add(new ScoredValue<T>(value, score));
    }

    public void SortByScore()
    {
        if (!_sorted && _heap.Count > 0)
        {
            _heap.SortDescending();
            _sorted = true;
        }
    }

    public IList<ScoredValue<T>> ToList()
    {
        var list = new List<ScoredValue<T>>(Count);
        for (int i = 0, count = Count; i < count; ++i)
        {
            list.Add(this[i]);
        }

        return list;
    }

    public IEnumerator<ScoredValue<T>> GetEnumerator()
    {
        return _heap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _heap.GetEnumerator();
    }
}
