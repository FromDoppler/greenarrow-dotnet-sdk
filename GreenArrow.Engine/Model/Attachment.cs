using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GreenArrow.Engine.Model
{
    /// <summary>
    /// Attachment to include in the mail to send
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Attachment
    {
        /// <summary>
        /// Name of the file to attach.
        /// </summary>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// The content type, such as application/pdf.
        /// </summary>
        [Required]
        public string ContentType { get; set; }

        /// <summary>
        /// The raw content of the attachment.
        /// GreenArrow will base64 encode this value for you before attaching the file to the message.
        /// Exactly one of content or content_base64 must be specified.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The base64-encoded content of the attachment.
        /// GreenArrow will verify that this value can be base64 decoded before accepting it.
        /// Exactly one of content or content_base64 must be specified.
        /// </summary>
        public string ContentBase64 { get; set; }
    }
}
