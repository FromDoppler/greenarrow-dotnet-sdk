using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model
{
    /// <summary>
    /// Dkim Key Data
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DkimKey
    {
        /// <summary>
        /// The domain name associated with this DKIM Key.
        /// </summary>
        public string Domain { get; init; }

        /// <summary>
        /// The selector used to identify this DKIM Key.
        /// </summary>
        public string Selector { get; init; }

        /// <summary>
        /// Whether this is the default DKIM key for this domain.
        /// </summary>
        public bool DefaultForDomain { get; init; }

        /// <summary>
        /// The key data
        /// </summary>
        public Key Key { get; init; }
    }

    /// <summary>
    /// The key data
    /// </summary>
    public class Key
    {
        /// <summary>
        /// The number of bits used to generate this key.
        /// </summary>
        public int? Bits { get; init; }

        /// <summary>
        /// The PEM-encoded private key.
        /// </summary>
        public string Private { get; init; }

        /// <summary>
        /// The public key, derived from the private key. This is PEM-encoded with the header line, footer line, and line-breaks stripped.
        /// </summary>
        public string Public { get; init; }
    }
}
