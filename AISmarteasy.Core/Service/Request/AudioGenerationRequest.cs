namespace AISmarteasy.Core;

public readonly struct AudioGenerationRequest(string speechFilePath, string voice)
{
    public AudioGenerationRequest(string voice) : this(string.Empty, voice)
    {
    }

    public string Voice { get; } = voice;

    public string SpeechFilePath { get; } = speechFilePath;
}
