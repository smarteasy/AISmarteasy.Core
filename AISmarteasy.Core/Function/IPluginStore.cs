namespace AISmarteasy.Core;

public interface IPluginStore
{
    List<SemanticFunctionCategory> SemanticFunctionCategories { get; }

    IPluginFunction? FindFunction(string pluginName, string functionName);
    IPlugin? FindPlugin(string pluginName);
}
