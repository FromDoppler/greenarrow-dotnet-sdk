using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine
{
    /// <summary>
    /// GreenArrow Request
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class Request
    {
        /// <summary>
        /// Email address of an email user (NOT the username of GreenArrow web-interface login)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of <seealso cref="UserName"/>
        /// </summary>
        public string Password { get; set; }
    }
}
