namespace AISmarteasy.Core;

public interface IPlugin
{
    IFunction GetFunction(string name);
}
