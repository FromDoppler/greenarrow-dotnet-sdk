using GreenArrow.Engine.Model;
using GreenArrow.Engine.RestApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.DKIMKeysApi
{
    /// <summary>
    /// Create a DKIM Key Request
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DKIMKeysRequest : IRestApiModel
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
        /// To create the private key
        /// </summary>
        public DkimKey DkimKey { get; set; }
    }
}
