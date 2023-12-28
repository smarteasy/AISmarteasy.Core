namespace AISmarteasy.Core;

public interface IPlugin
{
    string Name { get; }
    List<IPluginFunction> Functions { get; }

    void AddFunction(IPluginFunction function);
    IPluginFunction? GetFunction(string name);

}
