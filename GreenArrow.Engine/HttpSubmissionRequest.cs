using GreenArrow.Engine.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GreenArrow.Engine
{
    /// <summary>
    /// Http Submission Message Request
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class HttpSubmissionRequest : Request
    {
        /// <summary>
        /// For Submission of single message
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// For Submission of multiple messages
        /// </summary>
        [MinLength(1)]
        [MaxLength(500)]
        public ICollection<Message> Messages { get; set; }
    }
}
