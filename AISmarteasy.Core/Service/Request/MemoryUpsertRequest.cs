namespace AISmarteasy.Core;

public sealed class MemoryUpsertRequest(string collectionName, string collectionNamespace, IList<MemorySourceData> datas)
    : MemoryRequest(collectionName, collectionNamespace)
{
    public IList<MemorySourceData> Datas { get; } = datas;
}
