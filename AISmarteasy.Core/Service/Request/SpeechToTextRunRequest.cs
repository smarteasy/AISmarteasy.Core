using System;

namespace AISmarteasy.Core;

public readonly struct SpeechToTextRunRequest(SpeechSourceTypeKind speechSourceType , string language, byte[] speechData,
    List<string>? speechFilePaths = default, TranscriptionFormatKind transcriptionFormat = TranscriptionFormatKind.SingleTextJson)
{
    public List<string>? SpeechFilePaths { get; } = speechFilePaths;
    public string Language { get; } = language;
    public TranscriptionFormatKind TranscriptionFormat => transcriptionFormat;
    public SpeechSourceTypeKind SpeechSourceType => speechSourceType;
    public byte[] SpeechData { get; } = speechData;
}
