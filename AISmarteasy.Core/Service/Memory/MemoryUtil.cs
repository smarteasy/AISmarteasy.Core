using System.Collections;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

public static class MemoryUtil
{
    public const string DEFAULT_INDEX_NAME = "sk-index";
    public const IndexMetric DEFAULT_INDEX_METRIC = IndexMetric.Cosine;
    public const int DEFAULT_DIMENSION = 1536;
    public const PodTypeKind DEFAULT_POD_TYPE = PodTypeKind.P1X1;
    public const int MAX_METADATA_SIZE = 40 * 1024;

    public static JsonSerializerOptions DefaultSerializerOptions => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        AllowTrailingCommas = false,
        ReadCommentHandling = JsonCommentHandling.Skip,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        Converters =
        {
            new PodTypeJsonConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };

    public static Dictionary<string, object> ConvertFilter(Dictionary<string, object> filter)
    {
        Dictionary<string, object> pineconeFilter = new();

        foreach (KeyValuePair<string, object> entry in filter)
        {
            pineconeFilter[entry.Key] = entry.Value switch
            {
                MemoryOperator op => op.ToDictionary(),
                IList list => new MemoryOperator("$in", list).ToDictionary(),

                DateTimeOffset dateTimeOffset => new MemoryOperator("$eq", dateTimeOffset.ToUnixTimeSeconds()).ToDictionary(),
                _ => new MemoryOperator("$eq", entry.Value).ToDictionary()
            };
        }

        return pineconeFilter;
    }

    public static async IAsyncEnumerable<UpsertRequest> GetUpsertBatchesAsync(IAsyncEnumerable<MemoryDocument> data, int batchSize)
    {
        List<MemoryDocument> currentBatch = new(batchSize);

        await foreach (MemoryDocument record in data.ConfigureAwait(false))
        {
            currentBatch.Add(record);

            if (currentBatch.Count != batchSize)
            {
                continue;
            }

            yield return UpsertRequest.UpsertVectors(currentBatch);

            currentBatch = new List<MemoryDocument>(batchSize);
        }

        if (currentBatch.Count <= 0)
        {
            yield break;
        }

        yield return UpsertRequest.UpsertVectors(currentBatch);
    }

    public static async IAsyncEnumerable<MemoryDocument> EnsureValidMetadataAsync(
        IAsyncEnumerable<MemoryDocument> documents)
    {
        await foreach (MemoryDocument document in documents.ConfigureAwait(false))
        {
            if (document.Metadata == null || GetMetadataSize(document.Metadata) <= MAX_METADATA_SIZE)
            {
                yield return document;

                continue;
            }

            if (!document.Metadata.TryGetValue("text", out object? value))
            {
                yield return document;

                continue;
            }

            string text = value as string ?? string.Empty;
            int textSize = Encoding.UTF8.GetByteCount(text);
            document.Metadata.Remove("text");
            int remainingMetadataSize = GetMetadataSize(document.Metadata);

            int splitCounter = 0;
            int textIndex = 0;

            while (textSize > 0)
            {
                int availableSpace = MAX_METADATA_SIZE - remainingMetadataSize;
                int textSplitSize = Math.Min(textSize, availableSpace);

                while (textSplitSize > 0 && Encoding.UTF8.GetByteCount(text.ToCharArray(textIndex, textSplitSize)) > availableSpace)
                {
                    textSplitSize--;
                }

                string splitText = text.Substring(textIndex, textSplitSize);
                textIndex += textSplitSize;
                textSize -= Encoding.UTF8.GetByteCount(splitText);

                MemoryDocument splitDocument = MemoryDocument.Create($"{document.Id}_{splitCounter}", document.Values)
                    .WithMetadata(new Dictionary<string, object>(document.Metadata))
                    .WithSparseValues(document.SparseValues);
                splitDocument.Metadata!["text"] = splitText;

                yield return splitDocument;

                splitCounter++;
            }
        }
    }

    private static int GetMetadataSize(Dictionary<string, object> metadata)
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        JsonSerializer.Serialize(writer, metadata);

        return (int)stream.Length;
    }
}

public sealed class MemoryOperator(string op, object value)
{
    public string Operator { get; } = op;

    public object Value { get; } = value;

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>
            {
                {
                    Operator, Value
                }
            };
    }
}
