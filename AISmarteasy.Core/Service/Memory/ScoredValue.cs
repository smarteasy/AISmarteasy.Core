using System.Diagnostics.CodeAnalysis;

namespace AISmarteasy.Core;

public readonly struct ScoredValue<T>(T item, double score) : IComparable<ScoredValue<T>>, IEquatable<ScoredValue<T>>
{
    public T Value { get; } = item;

    public double Score { get; } = score;

    public int CompareTo(ScoredValue<T> other)
    {
        return Score.CompareTo(other.Score);
    }

    public override string ToString()
    {
        return $"{Score}, {Value}";
    }

    public static explicit operator double(ScoredValue<T> src)
    {
        return src.Score;
    }

    public static explicit operator T(ScoredValue<T> src)
    {
        return src.Value;
    }

    public static implicit operator ScoredValue<T>(KeyValuePair<T, double> src)
    {
        return new ScoredValue<T>(src.Key, src.Value);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return (obj is ScoredValue<T> other) && Equals(other);
    }

    public bool Equals(ScoredValue<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Value, other.Value) &&
                Score.Equals(other.Score);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Score);
    }

    public static bool operator ==(ScoredValue<T> left, ScoredValue<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ScoredValue<T> left, ScoredValue<T> right)
    {
        return !(left == right);
    }

    public static bool operator <(ScoredValue<T> left, ScoredValue<T> right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(ScoredValue<T> left, ScoredValue<T> right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(ScoredValue<T> left, ScoredValue<T> right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(ScoredValue<T> left, ScoredValue<T> right)
    {
        return left.CompareTo(right) >= 0;
    }

    internal static ScoredValue<T> Min()
    {
        return new ScoredValue<T>(default!, double.MinValue);
    }
}
