using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// If you are using SimpleMH’s click and open tracking, then a click or open event will be created whenever someone loads images in an email message or clicks on a link in it.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ClickTracking : Event
    {
        /// <summary>
        /// The URL of the link that was clicked on.	
        /// </summary>
        public string ClickUrl { get; init; }

        /// <summary>
        /// The IP address that generated the click	
        /// </summary>
        public string EngineIp { get; init; }

        /// <summary>
        /// The user agent that generated the click.	
        /// </summary>
        public string UserAgent { get; init; }
    }
}
