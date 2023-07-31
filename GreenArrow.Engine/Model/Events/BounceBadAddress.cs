using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// This event is triggered when the bounce processing system detects that an email address has met the configured removal threshold for either hard or soft bounces.
    /// This event occurs so you can remove the address from your database or stop sending to this address.
    /// </summary>
    /// <remarks>
    /// This often requires more than one soft bounce, as we don’t want to remove addresses after a single soft bounce.
    /// Continuing to send to a bad address may have a negative impact on your deliverability.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BounceBadAddress : Bounce
    {
    }
}
