namespace AISmarteasy.Core;

public interface IContext
{
    string Result { get; }
    ContextVariableDictionary Variables { get; }
    IContext Clone();
}
