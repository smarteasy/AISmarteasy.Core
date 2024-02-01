namespace AISmarteasy.Core;

public class MemoryDocumentSplitRequest(string text)
{
    public string Text { get; } = text;
}
