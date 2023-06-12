using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GreenArrow.Engine.Model
{
    /// <summary>
    /// A email recipient
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Recipient
    {
        /// <summary>
        /// The recipient’s email address.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The recipient’s name.   
        /// </summary>
        public string Name { get; set; }
    }
}
