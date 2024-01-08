namespace AISmarteasy.Core;

public readonly struct SpeechToTextRunRequest(List<string> audioFilePaths, string language = "en")
{
    public List<string> AudioFilePaths { get; } = audioFilePaths;
    public string Language { get; } = language;
}
