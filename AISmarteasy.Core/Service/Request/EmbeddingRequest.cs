namespace AISmarteasy.Core;

public sealed class EmbeddingRequest(MemorySourceData data)
{
    public MemorySourceData Data { get; } = data;
}
