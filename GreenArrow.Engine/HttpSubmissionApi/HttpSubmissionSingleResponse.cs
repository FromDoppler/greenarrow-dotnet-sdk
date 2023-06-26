namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// GreenArrow Response of single delivery request
    /// </summary>
    public class HttpSubmissionSingleResponse
    {
        /// <summary>
        /// Number of attemps
        /// </summary>
        public int Attempted { get; init; }
        /// <summary>
        /// Error when request was not accepted
        /// </summary>
        public string Error { get; init; }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Id { get; init; }
        /// <summary>
        /// The single message id
        /// </summary>
        public string MessageId { get; init; }
        /// <summary>
        /// When request was succesful treated
        /// </summary>
        public bool Success { get; init; }
    }
}
