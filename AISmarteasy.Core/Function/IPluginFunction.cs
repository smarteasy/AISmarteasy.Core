namespace AISmarteasy.Core;

public interface IPluginFunction
{
    string Name { get; }
    string PluginName { get; }
    PluginFunctionInfo Info { get; }

    Task<ChatHistory> RunAsync(IAIServiceConnector serviceConnector, LLMServiceSetting serviceSetting, CancellationToken cancellationToken = default);
    public abstract Task Run();
}
