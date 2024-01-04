using Microsoft.Extensions.Primitives;
using NAudio.Wave;

namespace AISmarteasy.Core;

public record Silence(long Start, long End, TimeSpan Duration);
public record AudioSegment(long Start, long End, TimeSpan Duration);

public static class AudioTranscriptionHelper
{
    public static async Task DownloadAudioFile(string url, string downloadPath)
    {
        var httpClient = new HttpClient();
        await using var stream = await httpClient.GetStreamAsync(url);

        if (File.Exists(downloadPath))
        {
            File.Delete(downloadPath);
        }

        await using var fileStream = new FileStream(downloadPath, FileMode.CreateNew);

        await stream.CopyToAsync(fileStream);
    }
    public static List<string> TrimSilence(string filePath)
    {
        var silences = FindSilences(filePath, -19);
        var audioSegments = FindAudibleSegments(filePath, silences);

        var trimmedFiles = new List<string>();

        var directoryNameName = Path.GetDirectoryName(filePath);
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        var fileExt = Path.GetExtension(filePath);

        foreach (var audioSegment in audioSegments)
        {
            var trimmedFile = $"{directoryNameName}/{fileName}-{audioSegment.Start}-{audioSegment.End}{fileExt}";
            trimmedFiles.Add(trimmedFile);
            using var reader = new AudioFileReader(filePath);
            reader.Position = audioSegment.Start;
            using WaveFileWriter writer = new WaveFileWriter(trimmedFile, reader.WaveFormat);

            var endPos = audioSegment.End;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        return trimmedFiles;
    }

    private static Silence[] FindSilences(string fileName, double silenceThreshold = -40)
    {
        bool IsSilence(float amplitude, double threshold)
        {
            double dB = 20 * Math.Log10(Math.Abs(amplitude));
            return dB < threshold;
        }

        var silences = new List<Silence>();
        using (var reader = new AudioFileReader(fileName))
        {
            var buffer = new float[reader.WaveFormat.SampleRate * 4];

            long start = 0;
            bool eof = false;
            long counter = 0;
            bool detected = false;
            while (!eof)
            {
                int samplesRead = reader.Read(buffer, 0, buffer.Length);
                if (samplesRead == 0)
                {
                    eof = true;
                    if (detected)
                    {
                        double silenceSamples = (double)counter / reader.WaveFormat.Channels;
                        double silenceDuration = (silenceSamples / reader.WaveFormat.SampleRate) * 1000;
                        silences.Add(new Silence(start, start + counter, TimeSpan.FromMilliseconds(silenceDuration)));
                    }
                }

                for (int n = 0; n < samplesRead; n++)
                {
                    if (IsSilence(buffer[n], silenceThreshold))
                    {
                        detected = true;
                        counter++;
                    }
                    else
                    {
                        if (detected)
                        {
                            double silenceSamples = (double)counter / reader.WaveFormat.Channels;
                            double silenceDuration = (silenceSamples / reader.WaveFormat.SampleRate) * 1000;
                            var last = silences.Count - 1;
                            if (last >= 0)
                            {
                                var gap = start - silences[last].End;
                                var gapDuration = (double)gap / reader.WaveFormat.SampleRate * 1000;
                                if (gapDuration < 500)
                                {
                                    silenceDuration = silenceDuration + silences[last].Duration.TotalMilliseconds;
                                    silences[last] = new Silence(silences[last].Start, counter + silences[last].End,
                                        TimeSpan.FromMilliseconds(silenceDuration));
                                }
                                else
                                {
                                    silences.Add(
                                        new Silence(start, counter, TimeSpan.FromMilliseconds(silenceDuration)));
                                }
                            }
                            else
                            {
                                silences.Add(new Silence(start, counter, TimeSpan.FromMilliseconds(silenceDuration)));
                            }

                            start = start + counter;
                            counter = 0;
                            detected = false;
                        }
                    }
                }
            }
        }

        return silences.ToArray();
    }

    public static AudioSegment[] FindAudibleSegments(string fileName, Silence[] silences)
    {
        var segments = new List<AudioSegment>();
        using (var reader = new AudioFileReader(fileName))
        {
            var totalSamples = reader.Length;
            for (var i = 0; i < silences.Length; i++)
            {
                if (i == 0 && silences[i].Start > 0)
                {
                    segments.Add(new AudioSegment(0, silences[i].Start, 
                        TimeSpan.FromMilliseconds(silences[i].Start / reader.WaveFormat.SampleRate * 1000)));
                }

                if (i == silences.Length - 1 && silences[i].End < totalSamples)
                {
                    segments.Add(new AudioSegment(silences[i].End, totalSamples,
                        TimeSpan.FromMilliseconds((totalSamples - silences[i].End) / reader.WaveFormat.SampleRate * 1000)));
                }

                if (i < silences.Length - 1)
                {
                    var current = silences[i];
                    var next = silences[i + 1];
                    if (current.End < next.Start)
                    {
                        segments.Add(new AudioSegment(current.End, next.Start,
                            TimeSpan.FromMilliseconds((next.Start - current.End) / reader.WaveFormat.SampleRate * 1000)));
                    }
                }

            }
        }

        return segments.ToArray();
    }
}
