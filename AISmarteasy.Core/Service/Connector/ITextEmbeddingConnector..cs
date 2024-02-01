namespace AISmarteasy.Core;

public interface ITextEmbeddingConnector : IAIServiceConnector
{
    Task<ReadOnlyMemory<float>> GenerateEmbeddingsAsync(EmbeddingRequest request, CancellationToken cancellationToken = default);
}
