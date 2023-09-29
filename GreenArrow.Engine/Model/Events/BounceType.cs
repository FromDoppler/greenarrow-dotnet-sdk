using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// The type of bounce. h for hard, s for soft, and o for other.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BounceType
    {
        /// <summary>
        /// Bounce for message that not be retried
        /// </summary>
        [EnumMember(Value = "h")]
        Hard = 'h',

        /// <summary>
        /// Bounce for message that can be retried
        /// </summary>
        [EnumMember(Value = "s")]
        Soft = 's',

        /// <summary>
        /// Other type of bounce
        /// </summary>
        [EnumMember(Value = "o")]
        Other = 'o',
    }
}
