namespace AISmarteasy.Core;

public interface IWebSearchEngineConnector
{
    Task<IEnumerable<string>> SearchAsync(string query, int count = 1, int offset = 0);
}
