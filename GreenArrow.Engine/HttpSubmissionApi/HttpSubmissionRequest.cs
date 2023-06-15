using GreenArrow.Engine.Model;
using GreenArrow.Engine.RestApi;
using System.ComponentModel.DataAnnotations;

namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// Http Submission Message Request
    /// </summary>
    public class HttpSubmissionRequest : IRestApiModel
    {
        /// <summary>
        /// Email address of an email user (NOT the username of GreenArrow web-interface login)
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password of <seealso cref="Username"/>
        /// </summary>
        public string Password { get; set; }

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
