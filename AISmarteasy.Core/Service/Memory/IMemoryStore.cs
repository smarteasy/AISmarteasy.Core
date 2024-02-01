namespace AISmarteasy.Core;

public interface IMemoryStore
{
    Task CreateCollectionAsync(string collectionName, CancellationToken cancellationToken = default);
    IAsyncEnumerable<string> GetCollectionsAsync(CancellationToken cancellationToken = default);
    Task<bool> DoesCollectionExistAsync(string collectionName, CancellationToken cancellationToken = default);
    Task<string> UpsertAsync(string collectionName, MemoryRecord record, CancellationToken cancellationToken = default);
    Task<MemoryRecord?> GetAsync(string collectionName, string key, CancellationToken cancellationToken = default);
    IAsyncEnumerable<(MemoryRecord, double)> GetNearestMatchesAsync(string collectionName, string collectionNamespace, ReadOnlyMemory<float> vector, int topK,
        double minRelevanceScore = 0, bool isIncludeMetadata = true, CancellationToken cancellationToken = default);




    Task DeleteCollectionAsync(string collectionName, CancellationToken cancellationToken = default);

    IAsyncEnumerable<string> UpsertBatchAsync(string collectionName, IEnumerable<MemoryRecord> records, CancellationToken cancellationToken = default);

    IAsyncEnumerable<MemoryRecord> GetBatchAsync(string collectionName, IEnumerable<string> keys, CancellationToken cancellationToken = default);
    Task RemoveAsync(string collectionName, string key, CancellationToken cancellationToken = default);
    Task RemoveBatchAsync(string collectionName, IEnumerable<string> keys, CancellationToken cancellationToken = default);
}
