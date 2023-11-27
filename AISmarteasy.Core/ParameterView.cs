namespace AISmarteasy.Core;

public sealed class ParameterView
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            Verifier.ValidFunctionParamName(value);
            _name = value;
        }
    }

    public string? Description { get; set; }

    public string? DefaultValue { get; set; }

    public ParameterViewType? Type { get; set; }

    public ParameterView()
    {
    }

    public ParameterView(
        string name,
        string? description = null,
        string? defaultValue = null,
        ParameterViewType? type = null)
    {
        Name = name;
        Description = description;
        DefaultValue = defaultValue;
        Type = type;
    }
}
