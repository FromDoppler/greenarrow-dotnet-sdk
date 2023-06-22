using System.Net;

namespace GreenArrow.Engine.RestApi
{
    /// <summary>
    /// Contract that represent a Green Arrow Rest API response
    /// </summary>
    /// <typeparam name="T">Model type that return the endpoint</typeparam>
    public interface IRestApiResponse<T> where T : IRestApiModel
    {
        /// <summary>
        /// Response HTTP status code
        /// </summary>
        HttpStatusCode HttpStatusCode { get; init; }

        /// <summary>
        /// Object deserialized from the response content
        /// </summary>
        T Content { get; init; }
    }
}
