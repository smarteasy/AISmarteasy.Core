namespace AISmarteasy.Core;

public sealed record PluginFunctionInfo(string PluginName, string Name, 
    string Description = "", bool IsSemantic = false, IList<ParameterInfo>? Parameters = null)
{
    public IList<ParameterInfo> Parameters { get; } = Parameters ?? Array.Empty<ParameterInfo>();

    public string ToManualString()
    {
        if(IsSemantic)
            return ToSemanticFunctionManualString();

        return ToNativeFunctionManualString();
    }

    private string ToSemanticFunctionManualString()
    {
        return $"description: {Description}";
    }

    private string ToNativeFunctionManualString()
    {
        var inputs = string.Join("\n", Parameters.Select(parameter =>
        {
            var defaultValueString = string.IsNullOrEmpty(parameter.DefaultValue) ? string.Empty : $" (default value: {parameter.DefaultValue})";
            return $"  - {parameter.Name}: {parameter.Description}{defaultValueString}";
        }));

        return $@"description: {Description}
  inputs:
  {inputs}";
    }

    public string ToFullyQualifiedName()
    {
        return $"{PluginName}.{Name}";
    }
}