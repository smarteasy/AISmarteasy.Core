namespace AISmarteasy.Core;

public sealed class DocumentRequest(string documentPath, string? documentId, MemoryTagCollection? tags)
{
    public string DocumentPath { get; set; } = documentPath;
    public string? DocumentId { get; set; } = documentId;
    public MemoryTagCollection? Tags { get; set; } = tags;
    public string? Index { get; set; }
}