using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AISmarteasy.Core;

[JsonConverter(typeof(PodTypeJsonConverter))]
public enum PodTypeKind
{
    [EnumMember(Value = "starter")]
    None = 0,

    [EnumMember(Value = "s1.x1")]
    S1X1 = 1,

    [EnumMember(Value = "s1.x2")]
    S1X2 = 2,

    [EnumMember(Value = "s1.x4")]
    S1X4 = 3,

    [EnumMember(Value = "s1.x8")]
    S1X8 = 4,

    [EnumMember(Value = "p1.x1")]
    P1X1 = 5,

    [EnumMember(Value = "p1.x2")]
    P1X2 = 6,

    [EnumMember(Value = "p1.x4")]
    P1X4 = 7,

    [EnumMember(Value = "p1.x8")]
    P1X8 = 8,

    [EnumMember(Value = "p2.x1")]
    P2X1 = 9,

    [EnumMember(Value = "p2.x2")]
    P2X2 = 10,

    [EnumMember(Value = "p2.x4")]
    P2X4 = 11,

    [EnumMember(Value = "p2.x8")]
    P2X8 = 12
}
