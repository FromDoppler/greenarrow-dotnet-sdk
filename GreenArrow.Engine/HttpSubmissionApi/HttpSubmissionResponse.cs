using GreenArrow.Engine.RestApi;

namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// GreenArrow Response for single or multiple delivery request
    /// </summary>
    public class HttpSubmissionResponse : HttpSubmissionSingleResponse, IRestApiModel
    {
        /// <summary>
        /// An array of responses for many messages
        /// </summary>
        public ICollection<HttpSubmissionSingleResponse> Messages { get; init; }
    }
}
