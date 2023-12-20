namespace AISmarteasy.Core;

public interface IPluginStore
{
    IPluginFunction? FindFunction(string pluginName, string functionName);
    IPlugin? FindPlugin(string pluginName);
}
