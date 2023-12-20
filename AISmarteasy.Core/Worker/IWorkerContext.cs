namespace AISmarteasy.Core;

public interface IWorkerContext
{
    string Result { get; }
    VariableDictionary Variables { get; }
    IWorkerContext Clone();
}
