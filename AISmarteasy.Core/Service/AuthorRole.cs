using System.ComponentModel;

namespace AISmarteasy.Core;

public readonly struct AuthorRole : IEquatable<AuthorRole>
{
    public static readonly AuthorRole System = new("system");

    public static readonly AuthorRole Assistant = new("assistant");

    public static readonly AuthorRole User = new("user");

    public static readonly AuthorRole Tool = new("tool");

    public string Label { get; }

    public AuthorRole(string label)
    {
        Verifier.NotNull(label, nameof(label));

        Label = label;
    }

    public static bool operator ==(AuthorRole left, AuthorRole right)
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

    public static bool operator !=(AuthorRole left, AuthorRole right)
        => !(left == right);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj)
        => obj is AuthorRole otherRole && this == otherRole;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
        => Label.GetHashCode();

    public bool Equals(AuthorRole other)
        => !Equals(other, null)
           && string.Equals(Label, other.Label, StringComparison.OrdinalIgnoreCase);

    public override string ToString() => Label;
}