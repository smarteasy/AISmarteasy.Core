namespace AISmarteasy.Core;

public interface IPlugin
{
    IPluginFunction GetFunction(string name);
}
