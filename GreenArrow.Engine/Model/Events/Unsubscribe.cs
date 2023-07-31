using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// If you use SimpleMH, GreenArrow Engine can process unsubscribe links via two mechanisms:
    /// <list type="number">
    /// <item>When you insert a SimpleMH unsubscribe link, SimpleMH processes it.</item>
    /// <item>When you do not include a List-Unsubscribe header, SimpleMH automatically inserts one for you and processes it.</item>
    /// </list>
    /// When someone unsubscribes using either of the above mechanisms, an engine_unsub event will be created.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Unsubscribe : Event
    {
        /// <summary>
        /// The URL of the destination unsubscribe link. For unsubscribes that occur as a result of the List-Unsubscribe header, this value will be blank.
        /// </summary>
        public string ClickUrl { get; init; }
    }
}
