namespace AISmarteasy.Core;

public interface IPlugin
{
    IPluginFunction? GetFunction(string name);
    void AddFunction(IPluginFunction function);
}
