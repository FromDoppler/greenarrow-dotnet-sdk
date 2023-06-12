using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// If you are using SimpleMH’s click and open tracking, then a click or open event will be created whenever someone loads images in an email message or clicks on a link in it.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OpenTracking : Event
    {
        /// <inheritdoc/>
        public static new EventType EventType => EventType.EngineOpen;

        /// <summary>
        /// The IP address that generated the click
        /// </summary>
        public string EngineIp { get; init; }

        /// <summary>
        /// The user agent that generated the open.
        /// </summary>
        public string UserAgent { get; init; }

        /// <summary>
        /// GreenArrow has determined that this open represents a Mail Privacy Protection open.
        /// </summary>
        public bool IsPrivacyOpen { get; init; }
    }
}
