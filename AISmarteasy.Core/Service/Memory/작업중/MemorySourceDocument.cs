using System.Globalization;

namespace AISmarteasy.Core;

public class MemorySourceDocument
{
    public string Id
    {
        get => _id;
        set => _id = string.IsNullOrWhiteSpace(value)
                ? ValidateId(RandomId()) : ValidateId(value);
    }

    public MemorySourceDocumentFileCollection Files { get; } = new();

    public MemoryTagCollection Tags { get; } = new();

    public MemorySourceDocument(string? id = null, MemoryTagCollection? tags = null, IEnumerable<string>? filePaths = null)
    {
        Id = id!;

        if (tags != null) { Tags = tags; }

        if (filePaths != null)
        {
            foreach (var filePath in filePaths)
            {
                Files.AddFile(filePath);
            }
        }
    }

    public MemorySourceDocument AddTag(string name, string value)
    {
        Tags.Add(name, value);
        return this;
    }

    public MemorySourceDocument AddFile(string filePath)
    {
        Files.AddFile(filePath);
        return this;
    }

    public MemorySourceDocument AddFiles(IEnumerable<string>? filePaths)
    {
        return AddFiles(filePaths?.ToArray());
    }

    public MemorySourceDocument AddFiles(string[]? filePaths)
    {
        if (filePaths == null) { return this; }

        foreach (var filePath in filePaths)
        {
            Files.AddFile(filePath);
        }

        return this;
    }

    public MemorySourceDocument AddStream(string? fileName, Stream content)
    {
        if (content == null)
        {
            throw new CoreException("The content stream is NULL");
        }

        Files.AddStream(fileName, content);
        return this;
    }

    public static string ValidateId(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentOutOfRangeException(nameof(id), "The document ID is empty");
        }

        if (!IsValid(id))
        {
            throw new ArgumentOutOfRangeException(nameof(id), "The document ID contains invalid chars (allowed: A-B, a-b, 0-9, '.', '_', '-')");
        }

        return id;
    }

    public static string ReplaceInvalidChars(string? value)
    {
        if (value == null) { return string.Empty; }

        return new string(value.Select(c => IsValidChar(c) ? c : '_').ToArray());
    }

    private string _id = string.Empty;

    private static bool IsValid(string? value)
    {
        if (value == null) { return false; }

        return value.All(IsValidChar);
    }

    private static bool IsValidChar(char c)
    {
        return char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '.';
    }

    private static string RandomId()
    {
        const string LocalDateFormat = "yyyyMMddhhmmssfffffff";
        return Guid.NewGuid().ToString("N") + DateTimeOffset.Now.ToString(LocalDateFormat, CultureInfo.InvariantCulture);
    }
}
