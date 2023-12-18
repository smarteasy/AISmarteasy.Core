namespace AISmarteasy.Core;

public interface IPluginFunction
{
    string Name { get; }
    string PluginName { get; }

    Task RunAsync(LLMServiceSetting requestSettings, CancellationToken cancellationToken = default);
}
