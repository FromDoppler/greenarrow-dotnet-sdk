using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.RestApi;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;

namespace GreenArrow.Engine.DKIMKeysApi
{
    /// <summary>
    /// DKIM Keys API client implementation
    /// </summary>
    public class DKIMKeysApiClient : IDKIMKeysApi
    {
        private readonly GreenArrowEngineSettings _settings;
        private readonly IHttpClientFactory _httpFactory;

        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of Green Arrow DKIM Keys API Client
        /// </summary>
        /// <param name="options">Green Arrow settings with API Url and Authorization Token</param>
        /// <param name="httpFactory">HttpClienFactory for create HttpClient objects</param>
        public DKIMKeysApiClient(
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
            var endpointUri = new Uri(baseUri, _settings.DKIMKeysAPIEndpoint);
            return endpointUri.ToString();
        }

        /// <inheritdoc />
        public async Task<IRestApiResponse<DKIMKeysResponse>> PostAsync(DKIMKeysRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var jsonContent = request.ToJson();

                var client = CreateHttpClient();

                var authenticationString = $"{request.Username}:{request.Password}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

                var httpContent = new StringContent(jsonContent, encoding: default, mediaType: "application/json");
                var httpResponse = await client.PostAsync(_endpoint, httpContent, cancellationToken);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                    var content = result.ToObject<DKIMKeysResponse>();
                    return new RestApiResponse<DKIMKeysResponse>(httpResponse.StatusCode, content);
                }

                return new RestApiResponse<DKIMKeysResponse>(httpResponse.StatusCode);

            }
            catch (Exception exception)
            {
                throw new RestApiException("Unexpected exception", exception);
            }
        }
    }
}
