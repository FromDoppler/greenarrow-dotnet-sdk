using GreenArrow.Engine.Model;
using GreenArrow.Engine.RestApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.SendStatusApi
{
    /// <summary>
    /// Create a Send Status Request
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SendStatusRequest : IRestApiModel
    {
        /// <summary>
        /// Username that is authorized to log in to GreenArrow Engine’s web interface.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password that is authorized to log in to GreenArrow Engine’s web interface.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The Send information
        /// </summary>
        public Send Send { get; set; }
    }
}
