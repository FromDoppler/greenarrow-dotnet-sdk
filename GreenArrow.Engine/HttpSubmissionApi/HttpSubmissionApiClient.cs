using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.RestApi;
using Microsoft.Extensions.Options;
using System.Net;

namespace GreenArrow.Engine.HttpSubmissionApi
{
    /// <summary>
    /// HTTP Submission API client implementation
    /// </summary>
    public class HttpSubmissionApiClient : IHttpSubmissionApi
    {
        private readonly GreenArrowEngineSettings _settings;
        private readonly IHttpClientFactory _httpFactory;

        private readonly string _endpoint;

        /// <summary>
        /// Initializes a new instance of Green Arrow Rest API Client
        /// </summary>
        /// <param name="options">Green Arrow settings with API Url and Authorization Token</param>
        /// <param name="httpFactory">HttpClienFactory for create HttpClient objects</param>
        public HttpSubmissionApiClient(
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
            var endpointUri = new Uri(baseUri, _settings.HTTPSubmissionAPIEndpoint);
            return endpointUri.ToString();
        }

        /// <inheritdoc />
        public async Task<IRestApiResponse<HttpSubmissionResponse>> PostAsync(HttpSubmissionRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var jsonContent = request.ToJson();

                var client = CreateHttpClient();
                var httpContent = new StringContent(jsonContent, encoding: default, mediaType: "application/json");
                var httpResponse = await client.PostAsync(_endpoint, httpContent, cancellationToken);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                    var content = result.ToObject<HttpSubmissionResponse>();
                    return new RestApiResponse<HttpSubmissionResponse>(httpResponse.StatusCode, content);
                }

                return new RestApiResponse<HttpSubmissionResponse>(httpResponse.StatusCode);

            }
            catch (Exception exception)
            {
                throw new RestApiException("Unexpected exception", exception);
            }
        }

        /// <inheritdoc />
        public async Task<IRestApiResponse<HttpSubmissionResponse>> PutAsync(HttpSubmissionRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var jsonContent = request.ToJson();

                var client = CreateHttpClient();
                var httpContent = new StringContent(jsonContent, encoding: default, mediaType: "application/json");
                var httpResponse = await client.PutAsync(_endpoint, httpContent, cancellationToken);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                    var content = result.ToObject<HttpSubmissionResponse>();
                    return new RestApiResponse<HttpSubmissionResponse>(httpResponse.StatusCode, content);
                }

                return new RestApiResponse<HttpSubmissionResponse>(httpResponse.StatusCode);

            }
            catch (Exception exception)
            {
                throw new RestApiException("Unexpected exception", exception);
            }
        }
    }
}
