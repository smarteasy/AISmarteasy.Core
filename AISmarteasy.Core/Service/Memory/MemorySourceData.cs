using System.ComponentModel;

namespace AISmarteasy.Core;

public readonly struct MemorySourceData(string id, string text, string? description = null, string? additionalMetadata = null) : IEquatable<MemorySourceData>
{

    public string Id { get; } = id;
    public string Text { get; } = text;
    public string? Description { get; } = description;
    public string? AdditionalMetadata { get; } = additionalMetadata;

    public static bool operator ==(MemorySourceData left, MemorySourceData right)
    {
        if (Equals(left, right))
        {
            return true;
        }

        if (Equals(left, null) || Equals(right, null))
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(MemorySourceData left, MemorySourceData right)
        => !(left == right);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj)
        => obj is MemorySourceData otherRole && this == otherRole;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
        => Text.GetHashCode();

    public bool Equals(MemorySourceData other)
        => !Equals(other, null)
           && string.Equals(Text, other.Text, StringComparison.OrdinalIgnoreCase);

    public override string ToString() => Text;
}