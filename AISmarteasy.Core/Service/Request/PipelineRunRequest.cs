namespace AISmarteasy.Core;

public readonly struct PipelineRunRequest(LLMServiceSetting serviceSetting)
{
    public List<PluginFunctionName> PluginFunctionNames { get; } = new List<PluginFunctionName>();
    public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();
    public LLMServiceSetting ServiceSetting { get; init; } = serviceSetting;

    private const string INPUT_PARAMETER_KEY = "input";


    public void AddPluginFunctionName(string pluginName, string functionName)
    {
        PluginFunctionNames.Add(new PluginFunctionName(pluginName, functionName));
        Parameters[INPUT_PARAMETER_KEY] = string.Empty;
    }

    public void UpdateInput(string value)
    {
        Parameters[INPUT_PARAMETER_KEY] = value;
    }
}

public readonly struct PluginFunctionName
{
    public string PluginName { get; }
    public string FunctionName { get; }

    public PluginFunctionName(string pluginName, string functionName)
    {
        PluginName = pluginName;
        FunctionName = functionName;
    }
}
