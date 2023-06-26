using GreenArrow.Engine.RestApi;

namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// Represent the actions available in Green Arrow Engine Http Submission API
    /// </summary>
    /// <remarks><see href="https://www.greenarrowemail.com/docs/greenarrow-engine/API-V3/HTTP-Submission-API"/></remarks>
    public interface IHttpSubmissionApi
    {
        /// <summary>
        /// Submit messages for delivery
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The cancellation toekn</param>
        /// <returns>A generic rest api response with the deserialized Http Submission API response when success</returns>
        Task<IRestApiResponse<HttpSubmissionResponse>> PostAsync(HttpSubmissionRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit messages for delivery
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The cancellation toekn</param>
        /// <returns>A generic rest api response with the deserialized Http Submission API response when success</returns>
        Task<IRestApiResponse<HttpSubmissionResponse>> PutAsync(HttpSubmissionRequest request, CancellationToken cancellationToken = default);
    }
}
