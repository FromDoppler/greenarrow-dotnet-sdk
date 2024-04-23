using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.RestApi;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;

namespace GreenArrow.Engine.SendStatusApi
{
    /// <summary>
    /// Send Status API client implementation
    /// </summary>
    public class SendStatusApiClient : ISendStatusApi
    {
        private readonly GreenArrowEngineSettings _settings;
        private readonly IHttpClientFactory _httpFactory;

        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of Green Arrow Send Status API Client
        /// </summary>
        /// <param name="options">Green Arrow settings with API Url and Authorization Token</param>
        /// <param name="httpFactory">HttpClienFactory for create HttpClient objects</param>
        public SendStatusApiClient(
            IOptions<GreenArrowEngineSettings> options,
            IHttpClientFactory httpFactory)
        {
            _settings = options.Value;
            _httpFactory = httpFactory;
            _endpoint = GetEndPoint();
        }

        private HttpClient CreateHttpClient()
        {
            var client = _httpFactory.CreateClient();
            return client;
        }

        private string GetEndPoint()
        {
            var baseUri = new Uri(_settings.ServerUri);
            var endpointUri = new Uri(baseUri, _settings.SendStatusAPIEndpoint);
            return endpointUri.ToString();
        }

        /// <inheritdoc />
        public async Task<IRestApiResponse<SendStatusResponse>> PostAsync(SendStatusRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var jsonContent = new { send = new { status = request.Send.Status } }.ToJson();

                var client = CreateHttpClient();

                var authenticationString = $"{request.Username}:{request.Password}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

                var httpContent = new StringContent(jsonContent, encoding: default, mediaType: "application/json");
                var httpResponse = await client.PostAsync(string.Format(_endpoint, request.Send.Sendid), httpContent, cancellationToken);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                    var content = result.ToObject<SendStatusResponse>();
                    return new RestApiResponse<SendStatusResponse>(httpResponse.StatusCode, content);
                }

                return new RestApiResponse<SendStatusResponse>(httpResponse.StatusCode);

            }
            catch (Exception exception)
            {
                throw new RestApiException("Unexpected exception", exception);
            }
        }
    }
}
