namespace AISmarteasy.Core;

public interface IMemory
{
    public bool ImportAsync(DocumentRequest request, CancellationToken cancellationToken = default);




    //public Task<string> ImportDocumentAsync(MemorySourceDocument document, 
    //    string? index = null, IEnumerable<string>? steps = null, CancellationToken cancellationToken = default);


    //public Task<string> ImportDocumentAsync(MemorySourceDocumentUploadRequest uploadRequest, CancellationToken cancellationToken = default);

    //public Task<string> ImportDocumentAsync(Stream content, string? fileName = null, string? documentId = null, MemoryTagCollection? tags = null,
    //    string? index = null, IEnumerable<string>? steps = null, CancellationToken cancellationToken = default);

    //public Task<string> ImportTextAsync(string text, string? documentId = null, MemoryTagCollection? tags = null,
    //    string? index = null, IEnumerable<string>? steps = null, CancellationToken cancellationToken = default);

    //public Task<string> ImportWebPageAsync(string url, string? documentId = null, MemoryTagCollection? tags = null,
    //    string? index = null, IEnumerable<string>? steps = null, CancellationToken cancellationToken = default);

    //public Task<IEnumerable<MemoryIndexDetails>> ListIndexesAsync(CancellationToken cancellationToken = default);

    //public Task DeleteIndexAsync(string? index = null, CancellationToken cancellationToken = default);

    //public Task DeleteDocumentAsync(string documentId, string? index = null, CancellationToken cancellationToken = default);

    //public Task<bool> IsDocumentReadyAsync(string documentId, string? index = null, CancellationToken cancellationToken = default);

    //public Task<MemoryPipelineStatus?> GetDocumentStatusAsync(string documentId, string? index = null, CancellationToken cancellationToken = default);

    //public Task<MemoryQueryAnswer> QueryAsync(string query,
    //    string? index = null, MemoryFilter? filter = null, ICollection<MemoryFilter>? filters = null,
    //    double minRelevance = 0, int limit = -1, CancellationToken cancellationToken = default);

    //public Task<MemoryQueryAnswer> QueryAsync(string query,
    //    string? index = null, MemoryFilter? filter = null, ICollection<MemoryFilter>? filters = null,
    //    double minRelevance = 0, CancellationToken cancellationToken = default);
}
