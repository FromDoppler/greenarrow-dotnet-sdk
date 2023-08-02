using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// This event is triggered for every bounce message processed by the bounce processor.
    /// This includes bounces where the address has not yet met the qualifying criteria for deactivation.
    /// </summary>
    /// <remarks>
    /// bounce_all events do not require any action and should not be a reason to remove addresses from your database or stop sending to addresses. 
    /// Use the bounce_bad_address event for subscriber deactivation instead.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BounceAll : Bounce
    {
        /// <summary>
        /// Indicates whether this was a synchronous bounce (true) or asynchronous bounce (false).
        /// </summary>
        public bool Synchronous { get; init; } = true;
    }
}
