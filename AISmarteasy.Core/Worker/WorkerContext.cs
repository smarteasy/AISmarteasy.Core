using System.Globalization;

namespace AISmarteasy.Core;

public sealed class WorkerContext(VariableDictionary variables) : IWorkerContext
{
    public string Result => Variables.ToString();

    public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

    public VariableDictionary Variables { get; } = variables;

    public override string ToString()
    {
        return Result;
    }
    public IWorkerContext Clone()
    {
        return new WorkerContext(variables: Variables.Clone())
        {
            Culture = Culture,
        };
    }
}
