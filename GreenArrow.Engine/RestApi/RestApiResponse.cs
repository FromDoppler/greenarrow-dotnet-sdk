using System.Net;

namespace GreenArrow.Engine.RestApi
{
    /// <summary>
    /// A generic Greeen Arrow Rest API response
    /// </summary>
    /// <typeparam name="T">Model type that return the endpoint</typeparam>
    public class RestApiResponse<T> : IRestApiResponse<T> where T : IRestApiModel
    {
        /// <inheritdoc />
        public HttpStatusCode HttpStatusCode { get; init; }

        /// <inheritdoc />
        public T Content { get; init; }
        /// <summary>
        /// Initializes a new instance of generic Green Arrow Rest API response
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code of the response</param>
        /// <param name="content">The object deserialized from the response content</param>
        public RestApiResponse(HttpStatusCode httpStatusCode, T content = default)
        {
            HttpStatusCode = httpStatusCode;
            Content = content;
        }
    }
}
