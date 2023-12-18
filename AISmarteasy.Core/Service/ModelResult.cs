using System.Text.Json;

namespace AISmarteasy.Core;

public sealed class ModelResult
{
    private readonly object _result;

    public ModelResult(object result)
    {
        Verifier.NotNull(result);
        _result = result;
    }

    public object GetRawResult() => _result;

    public T GetResult<T>()
    {
        if (_result is T typedResult)
        {
            return typedResult;
        }

        throw new InvalidCastException($"Cannot cast {_result.GetType()} to {typeof(T)}");
    }

    public JsonElement GetJsonResult()
    {
        return Json.Deserialize<JsonElement>(_result.ToJson());
    }
}
