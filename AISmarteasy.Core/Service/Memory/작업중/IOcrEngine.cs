namespace AISmarteasy.Core;

public interface IOcrEngine
{
    Task<string> ExtractTextFromImageAsync(Stream imageContent, CancellationToken cancellationToken = default);
}
