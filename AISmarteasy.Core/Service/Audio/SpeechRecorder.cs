using NAudio.Wave;
using NAudio.Wave.Compression;

namespace AISmarteasy.Core;

public class SpeechRecorder : IWaveProvider, IDisposable
{
    private readonly WaveInEvent _recorder;
    private readonly WaveFileWriter _writer;
    private readonly BufferedWaveProvider _sourceWaveProvider;
    private bool _isWriterDisposed;

    bool _isRecording = true;

    public IAIServiceConnector ServiceConnector { get; }

    public SpeechRecorder(string wavFilePath, IAIServiceConnector serviceConnector)
    {
        ServiceConnector = serviceConnector;
        var format = new WaveFormat(44100, 1);
        _recorder = new WaveInEvent
        {
            BufferMilliseconds = 3000,
            DeviceNumber = 0,
            WaveFormat = format
        };

        _recorder.DataAvailable += RecorderOnDataAvailable;
        _recorder.RecordingStopped += WaveInRecordingStopped;

        _sourceWaveProvider = new BufferedWaveProvider(_recorder.WaveFormat);
        _writer = new WaveFileWriter(wavFilePath, _sourceWaveProvider.WaveFormat);
    }

    public WaveFormat WaveFormat => _sourceWaveProvider.WaveFormat;


    public void StartRecording()
    {
        _recorder.StartRecording();
    }

    public async Task StopRecording()
    {
        _recorder.StopRecording();

        var request = new SpeechToTextRunRequest(SpeechSourceTypeKind.Files, "ko", new byte[]{}, new List<string>(){ "./temp1.mp3" } );
        //await ServiceConnector.RunSpeechToTextAsync(request);
        //Task.WaitAll();
    }

    private void RecorderOnDataAvailable(object? sender, WaveInEventArgs args)
    {
        if (_isRecording)
        {
            _sourceWaveProvider.AddSamples(args.Buffer, 0, args.BytesRecorded);
            _writer.Write(args.Buffer, 0, args.BytesRecorded);
            _writer.Flush();
        }

        _isRecording = false;
    }

    private void WaveInRecordingStopped(object? sender, StoppedEventArgs e)
    {
        _recorder.Dispose();
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        var read = _sourceWaveProvider.Read(buffer, offset, count);
        if (count > 0 && !_isWriterDisposed)
        {
            _writer.Write(buffer, offset, read);
        }
        if (count == 0)
        {
            Dispose();
        }
        return read;
    }

    public void Dispose()
    {
        if (!_isWriterDisposed)
        {
            _isWriterDisposed = true;
            _writer.Dispose();
        }
    }
}