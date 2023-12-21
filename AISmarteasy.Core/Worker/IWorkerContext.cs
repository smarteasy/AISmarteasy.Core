using System.Globalization;

namespace AISmarteasy.Core;

public interface IWorkerContext
{
    string Result { get; }
    VariableDictionary Variables { get; }
    CultureInfo Culture { get; set; }
    IWorkerContext Clone();
}
