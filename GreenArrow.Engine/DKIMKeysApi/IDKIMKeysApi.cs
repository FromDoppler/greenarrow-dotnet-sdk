using GreenArrow.Engine.RestApi;

namespace GreenArrow.Engine.DKIMKeysApi
{
    /// <summary>
    /// Represent the actions available in Green Arrow Engine DKIM Keys API
    /// </summary>
    /// <remarks><see href="https://www.greenarrowemail.com/docs/greenarrow-engine/API-V3/Engine/DKIM-Keys"/></remarks>
    public interface IDKIMKeysApi
    {
        /// <summary>
        /// Create a DKIM Key
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A generic rest api response with the deserialized DKIM Keys API response when success</returns>
        Task<IRestApiResponse<DKIMKeysResponse>> PostAsync(DKIMKeysRequest request, CancellationToken cancellationToken = default);
    }
}
