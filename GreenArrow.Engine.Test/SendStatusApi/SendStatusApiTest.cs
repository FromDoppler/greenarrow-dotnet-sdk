using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.RestApi;
using GreenArrow.Engine.SendStatusApi;
using Microsoft.Extensions.Options;
using Moq.Protected;
using System.Net;

namespace GreenArrow.Engine.Test.SendStatusApi
{
    public class SendStatusApiTest
    {
        private static readonly Fixture specimens = new();

        private static ISendStatusApi CreateSut(
            GreenArrowEngineSettings? settings = null,
            IHttpClientFactory? httpClientFactory = null
            )
        {
            settings ??= new GreenArrowEngineSettings { ServerUri = $"https://localhost/" };

            return new SendStatusApiClient(
                options: Options.Create(settings),
                httpFactory: httpClientFactory ?? Mock.Of<IHttpClientFactory>()
                );
        }

        private static Mock<HttpMessageHandler> CreateHttpMessageHandlerMock(HttpResponseMessage httpResponseMessage)
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(nameof(HttpClient.SendAsync), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            return httpMessageHandlerMock;
        }

        private static Mock<HttpMessageHandler> CreateHttpMessageHandlerMock(Exception exception)
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(nameof(HttpClient.SendAsync), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(exception);

            return httpMessageHandlerMock;
        }

        private static Mock<IHttpClientFactory> CreateHttpClientFactoryMock(HttpMessageHandler httpMessageHandler)
        {
            var httpClient = new HttpClient(httpMessageHandler);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock
                .Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            return httpClientFactoryMock;
        }

        [Fact]
        public async Task Should_request_to_the_configured_endpoint_name()
        {
            var request = specimens.Create<SendStatusRequest>();

            // Arrange
            var settings = new GreenArrowEngineSettings { ServerUri = $"https://localhost/", SendStatusAPIEndpoint = string.Format("/ga/api/v3/eng/sends_by_sendid/{0}/status", request.Send.Sendid) };
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = specimens.Create<HttpStatusCode>(),
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(settings, httpClientFactory: httpClientFactoryMock.Object);

            // Act
            await sut.PostAsync(request, CancellationToken.None);

            // Assert
            httpMessageHandlerMock.Protected().Verify(
               nameof(HttpClient.SendAsync),
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(request => request.RequestUri.AbsolutePath.EndsWith(settings.SendStatusAPIEndpoint)),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task Post_should_return_http_status_code_on_sucessfull()
        {
            // Arrange
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = specimens.Create<HttpStatusCode>(),
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<SendStatusRequest>();

            // Act
            var result = await sut.PostAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(httpResponseMessage.StatusCode, result.HttpStatusCode);
        }

        [Fact]
        public async Task Post_should_throw_RestApiException_upon_an_exception_in_the_implementation()
        {
            // Arrange
            var exception = specimens.Create<Exception>();

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(exception);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<SendStatusRequest>();
            var cancellationToken = specimens.Create<CancellationToken>();

            // Act
            var result = await Assert.ThrowsAsync<RestApiException>(() => sut.PostAsync(request, cancellationToken));

            // Assert
            Assert.Equal(exception, result.InnerException);
        }

        [Fact]
        public async Task Post_should_return_deserialized_response_content_on_sucessfull()
        {
            // Arrange
            var SendStatusResponse = specimens.Create<SendStatusResponse>();
            var httpContent = new StringContent(SendStatusResponse.ToJson(true));

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = httpContent,
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<SendStatusRequest>();

            // Act
            var result = await sut.PostAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(SendStatusResponse.Success, result.Content.Success);
        }
    }
}
