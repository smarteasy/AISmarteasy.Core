namespace AISmarteasy.Core;

public abstract class MemoryRequest(string collectionName, string collectionNamespace) 
{
    public string CollectionName { get; } = collectionName;
    public string CollectionNamespace { get; } = collectionNamespace;
}
