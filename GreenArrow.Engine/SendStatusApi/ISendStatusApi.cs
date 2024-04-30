using GreenArrow.Engine.RestApi;

namespace GreenArrow.Engine.SendStatusApi
{
    /// <summary>
    /// Represent the actions available in Green Arrow Engine Send Status API.
    /// </summary>
    /// <remarks><see href="https://www.greenarrowemail.com/docs/greenarrow-engine/API-V3/Engine/Send-Status"/></remarks>
    public interface ISendStatusApi
    {
        /// <summary>
        /// Update the status of a send
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A generic rest api response with the deserialized Send Status API response when success</returns>
        Task<IRestApiResponse<SendStatusResponse>> PostAsync(SendStatusRequest request, CancellationToken cancellationToken = default);
    }
}
