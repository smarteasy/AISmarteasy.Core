namespace AISmarteasy.Core;

public class ParameterTypeInfo : IEquatable<ParameterTypeInfo>
{
    private readonly string _name;

    public static readonly ParameterTypeInfo String = new("string");

    public static readonly ParameterTypeInfo Number = new("number");

    public static readonly ParameterTypeInfo Object = new("object");

    public static readonly ParameterTypeInfo Array = new("array");

    public static readonly ParameterTypeInfo Boolean = new("boolean");

    public ParameterTypeInfo(string name)
    {
        Verifier.NotNullOrWhitespace(name, nameof(name));

        _name = name;
    }

    public string Name => _name;

    public override string ToString() => _name;

    public bool Equals(ParameterTypeInfo? other)
    {
        if (other is null)
        {
            return false;
        }

        return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        return obj is ParameterTypeInfo other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
