using GreenArrow.Engine.Model;
using GreenArrow.Engine.RestApi;

namespace GreenArrow.Engine.SendStatusApi
{
    /// <summary>
    /// GreenArrow Response is the full DKIM Key record data
    /// </summary>
    public class SendStatusResponse : IRestApiModel
    {
        /// <summary>
        /// When request was succesful created
        /// </summary>
        public bool Success { get; init; }

        /// <summary>
        /// Full DKIM Key record data
        /// </summary>
        public SendResponseData Data { get; init; }

        /// <summary>
        /// Error code when request was not accepted
        /// </summary>
        public string ErrorCode { get; init; }

        /// <summary>
        /// Error message when request was not accepted
        /// </summary>
        public string[] ErrorMessages { get; init; }
    }

    /// <summary>
    /// Full DKIM Key record data
    /// </summary>
    public class SendResponseData
    {
        /// <summary>
        /// Full Send record data
        /// </summary>
        public Send Send { get; init; }
    }
}
