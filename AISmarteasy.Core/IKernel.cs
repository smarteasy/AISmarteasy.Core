namespace AISmarteasy.Core;

public interface IKernel
{
    Dictionary<string, IPlugin> Plugins { get; }
    IContext Context { get; set; }
}
