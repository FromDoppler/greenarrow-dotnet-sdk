using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// Base of all event
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class Event
    {
        /// <summary>
        /// The type of event
        /// </summary>
        public EventType EventType { get; init; }
        /// <summary>
        /// The time that the bounce happened, in seconds past the Unix epoch.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EventTime { get; init; }
        /// <summary>
        /// Server ID as configured by server_id.
        /// </summary>
        public string ServerId { get; init; }
        /// <summary>
        /// A unique identifier for this event.
        /// </summary>
        [MaxLength(64)]
        public string EventUniqueId { get; init; }
        /// <summary>
        /// The email address that this message was to.
        /// </summary>
        public string Email { get; init; }
        /// <summary>
        /// The lowercased identifier for the mailing list that this message is a part of.
        /// </summary>
        public string Listid { get; init; }
        /// <summary>
        /// The lowercased internal identifier for the send.
        /// </summary>
        public string Sendid { get; init; }
        /// <summary>
        /// The click tracking ID is specified using the X-GreenArrow-Click-Tracking-ID header and can be used to trace an event back to a specific message.
        /// </summary>
        public string ClickTrackingId { get; init; }
    }
}
