using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model
{
    /// <summary>
    /// Send Data
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Send
    {
        /// <summary>
        /// An automatically generated identifier.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// The SendId for this send.
        /// </summary>
        public string Sendid { get; init; }

        /// <summary>
        /// The send status.
        /// </summary>
        public string Status { get; init; }
    }
}
