using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CerebellumRestLib.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        [EnumMember(Value = "PHOTO")]
        Photo,

        [EnumMember(Value = "FILE")]
        File,

        [EnumMember(Value = "SOUND")]
        Sound,

        [EnumMember(Value = "VIDEO")]
        Video
    }
}