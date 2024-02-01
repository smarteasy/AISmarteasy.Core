using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

internal sealed class PodTypeJsonConverter : JsonConverter<PodTypeKind>
{
    public override PodTypeKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? stringValue = reader.GetString();

        object? enumValue = Enum
            .GetValues(typeToConvert)
            .Cast<object?>()
            .FirstOrDefault(value => value != null && typeToConvert.GetMember(value.ToString()!)[0]
                .GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttr && enumMemberAttr.Value == stringValue);

        if (enumValue != null)
        {
            return (PodTypeKind)enumValue;
        }

        throw new JsonException($"Unable to parse '{stringValue}' as a PodType enum.");
    }

    public override void Write(Utf8JsonWriter writer, PodTypeKind value, JsonSerializerOptions options)
    {
        if (value.GetType().GetMember(value.ToString())[0].GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttr)
        {
            writer.WriteStringValue(enumMemberAttr.Value);
        }
        else
        {
            throw new JsonException($"Unable to find EnumMember attribute for PodType '{value}'.");
        }
    }
}
