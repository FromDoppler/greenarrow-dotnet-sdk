namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// GreenArrow Response
    /// </summary>
    public class HttpSubmissionResponse
    {
        /// <summary>
        /// When request was succesful treated
        /// </summary>
        public bool Success { get; init; }
        /// <summary>
        /// Error when request was not accepted
        /// </summary>
        public string Error { get; init; }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Id { get; init; }
        /// <summary>
        /// Number of attemps
        /// </summary>
        public int Attempted { get; init; }
        /// <summary>
        /// The single message id
        /// </summary>
        public string MessageId { get; init; }
        /// <summary>
        /// An array of responses for many messages
        /// </summary>
        public ICollection<HttpSubmissionResponse> Messages { get; init; }
    }
}
