namespace AISmarteasy.Core;

public readonly struct TextToSpeechRunRequest(string speechFilePath, string voice)
{
    public TextToSpeechRunRequest(string voice) : this(string.Empty, voice)
    {
    }

    public string Voice{ get; } = voice;
    
    public string SpeechFilePath { get; } = speechFilePath;
}
