using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace AISmarteasy.Core;

public class MemorySourceDocumentFileCollection
{
    private readonly Dictionary<string, string> _filePaths = new(StringComparer.OrdinalIgnoreCase);

    private readonly Dictionary<string, Stream> _streams = new(StringComparer.OrdinalIgnoreCase);

    private readonly HashSet<string> _fileNames = new(StringComparer.OrdinalIgnoreCase);

    public void AddFile(string filePath)
    {
        if (_filePaths.ContainsKey(filePath)) { return; }

        if (!File.Exists(filePath))
        {
            throw new CoreException($"File not found: '{filePath}'");
        }

        var file = new FileInfo(filePath);
        var fileName = file.Name;
        if (_fileNames.Contains(fileName))
        {
            var count = 0;

            var dirNameId = CalculateSha256(MemorySourceDocument.ReplaceInvalidChars(file.DirectoryName));
            do
            {
                fileName = $"{dirNameId}{count++}_{file.Name}";
            } while (_fileNames.Contains(fileName));
        }

        _filePaths.Add(filePath, fileName);
        _fileNames.Add(fileName);
    }

    public void AddStream(string? fileName, Stream content)
    {
        if (content == null)
        {
            throw new CoreException("The content stream is NULL");
        }

        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = "content.txt";
        }

        var count = 0;
        while (_fileNames.Contains(fileName))
        {
            fileName = $"stream{count++}_{fileName}";
        }

        _streams.Add(fileName, content);
        _fileNames.Add(fileName);
    }

    public IEnumerable<(string name, Stream content)> GetStreams()
    {
        foreach (KeyValuePair<string, string> file in _filePaths)
        {
            byte[] bytes = File.ReadAllBytes(file.Key);
            var data = new BinaryData(bytes);
            yield return (file.Value, data.ToStream());
        }

        foreach (KeyValuePair<string, Stream> stream in _streams)
        {
            yield return (stream.Key, stream.Value);
        }
    }

    private static string CalculateSha256(string value)
    {
        byte[] byteArray;

        try
        {
            using SHA256 mySha256 = SHA256.Create();
            byteArray = mySha256.ComputeHash(Encoding.UTF8.GetBytes(value));
        }
        catch (Exception)
        {
            return "SHA256Exception";
        }
        return ToHexString(byteArray).ToLowerInvariant();
    }
    public static string ToHexString(byte[] byteArray)
    {
        StringBuilder hex = new(byteArray.Length * 2);
        foreach (byte b in byteArray) { hex.AppendFormat(CultureInfo.InvariantCulture, "{0:x2}", b); }

        return hex.ToString();
    }
}
