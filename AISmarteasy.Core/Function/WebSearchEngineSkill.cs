using System.ComponentModel;
using System.Text.Json;

namespace AISmarteasy.Core;

public abstract class WebSearchEngineSkill
{
    public const string COUNT_PARAM = "count";
    public const string OFFSET_PARAM = "offset";

    protected IWebSearchEngineConnector? Connector { get; set; }

    [Function, Description("Perform a web search.")]
    public async Task<string> Search(
        [Description("Search query")] string query,
        [Description("Number of results")] int count = 10,
        [Description("Number of results to skip")] int offset = 0)
    {
        if (Connector == null)
            return string.Empty;

        var results = await Connector.SearchAsync(query, count, offset).ConfigureAwait(false);
        var enumerable = results.ToList();
        if (!enumerable.Any())
        {
            throw new InvalidOperationException("Failed to get a response from the web search engine.");
        }

        return count == 1
            ? enumerable.FirstOrDefault() ?? string.Empty
            : JsonSerializer.Serialize(enumerable);
    }
}
