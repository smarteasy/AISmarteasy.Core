using System.Diagnostics.CodeAnalysis;

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
        => left.Equals(right);

    public static bool operator !=(AuthorRole left, AuthorRole right)
        => !(left == right);

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is AuthorRole otherRole && this == otherRole;

    public bool Equals(AuthorRole other)
        => string.Equals(this.Label, other.Label, StringComparison.OrdinalIgnoreCase);

    public override int GetHashCode()
        => StringComparer.OrdinalIgnoreCase.GetHashCode(this.Label ?? string.Empty);

    public override string ToString() => this.Label ?? string.Empty;
}