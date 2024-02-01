namespace AISmarteasy.Core;

public class DocumentPage(string? text, int number)
{
    public string Text { get; } = text ?? string.Empty;

    public int Number { get; } = number;
}
