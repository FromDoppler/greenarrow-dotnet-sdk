using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// When someone clicks on a “this is spam” link at an ISP that supports feedback loops, and a feedback loop notification is sent to GreenArrow, a spam complaint event is created.
    /// <para>
    /// This event occurs so that you can remove the address that generated the complaint from your database or stop sending to it.
    /// You can also use this event to maintain statistical information on the number of spam complaints created by each campaign.
    /// Continuing to send to an address that has complained about spam can have a negative effect on your deliverability.
    /// </para>
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SpamComplaint : Event
    {
        /// <inheritdoc/>
        public static new EventType EventType => EventType.Scomp;
    }
}
