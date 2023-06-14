using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// A bounce event is when a bounce message is received and processed by the GreenArrow Engine bounce processor.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class Bounce : Event
    {
        /// <summary>
        /// The type of bounce. h for hard, s for soft, and o for other.
        /// </summary>
        public BounceType BounceType { get; init; }
        /// <summary>
        /// The code of the type of bounce.
        /// </summary>
        public int BounceCode { get; init; }
        /// <summary>
        /// The text of the failure message. (Up to the number of characters configured.)
        /// </summary>
        public string BounceText { get; init; }
    }
}
