namespace AISmarteasy.Core;

public interface IFunction
{
    string Name { get; }
    string PluginName { get; }

    Task RunAsync(AIRequestSetting requestSettings, CancellationToken cancellationToken = default);
}
