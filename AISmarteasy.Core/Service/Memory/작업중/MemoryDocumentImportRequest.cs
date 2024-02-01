namespace AISmarteasy.Core;

public class MemoryDocumentImportRequest
{
    public class ImportedFile
    {
        public string FileName { get; set; } = string.Empty;

        public Stream FileContent { get; set; } = Stream.Null;

        public ImportedFile()
        {
        }

        public ImportedFile(string fileName, Stream fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }

    public string Index { get; set; } = string.Empty;

    public string DocumentId { get; set; } = string.Empty;

    public MemoryTagCollection Tags { get; set; } = new();

    public List<ImportedFile> Files { get; set; } = new();

    public List<string> Steps { get; set; } = new();

    public MemoryDocumentImportRequest()
    {
    }

    public MemoryDocumentImportRequest(MemorySourceDocument document, string? index = null)
    {
        Index = index.CleanName();
        DocumentId = document.Id;
        Tags = document.Tags;

        foreach ((string name, Stream content) stream in document.Files.GetStreams())
        {
            var formFile = new ImportedFile(stream.name, stream.content);
            Files.Add(formFile);
        }
    }
}
