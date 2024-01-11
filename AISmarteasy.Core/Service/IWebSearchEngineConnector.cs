namespace AISmarteasy.Core;

public interface IWebSearchEngineConnector
{
    Task<IEnumerable<string>> SearchAsync(string query, int count, int offset, CancellationToken cancellationToken);
}
