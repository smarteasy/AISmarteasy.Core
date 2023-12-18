using System.Diagnostics.CodeAnalysis;

namespace AISmarteasy.Core;

public sealed class ParameterInfo
{
    private string _name = string.Empty;
    private readonly string _description = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            Verifier.ValidParameterName(value);
            _name = value;
        }
    }

    [AllowNull]
    public string Description
    {
        get => _description;
        init =>_description = value ?? string.Empty;
    }

    public string? DefaultValue { get; set; }

    public ParameterTypeInfo? Type { get; init; }

    public ParameterInfo(string name,
        string? description = null, string? defaultValue = null, ParameterTypeInfo? type = null)
    {
        Name = name;
        Description = description;
        DefaultValue = defaultValue;
        Type = type;
    }
}
