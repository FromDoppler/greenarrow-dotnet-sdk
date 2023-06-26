namespace GreenArrow.Engine.RestApi
{
    /// <summary>
    /// Represents errors that occur executing a Rest API Client.
    /// </summary>
    [Serializable]
    public class RestApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Green Arrow.RestApi.RestApiException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public RestApiException(string message, Exception inner) : base(message, inner) { }
    }
}
