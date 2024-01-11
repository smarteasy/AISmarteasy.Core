using System.ComponentModel;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;

namespace AISmarteasy.Core;

public abstract class WebSearchEngineSkill
{
    public const string COUNT_PARAM = "count";
    public const string OFFSET_PARAM = "offset";

    private static readonly JsonSerializerOptions JsonOptionsCache = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    protected IWebSearchEngineConnector? Connector { get; set; }

    [Function, Description("Perform a web search.")]
    public string Search(
        [Description("Search query")] string query,
        [Description("Number of results")] int count = 10,
        [Description("Number of results to skip")] int offset = 0)
    {
        if (Connector == null)
            return string.Empty;

        CancellationToken cancellationToken = default;
        var searchTask = Connector.SearchAsync(query, count, offset, cancellationToken);
        Task.WaitAll(searchTask);

        var result = searchTask.Result.ToArray();

        if (result.Length == 0)
        {
            throw new InvalidOperationException("Failed to get a response from the web search engine.");
        }

        return count == 1
            ? result[0]
            : JsonSerializer.Serialize(result, JsonOptionsCache);
    }
}
