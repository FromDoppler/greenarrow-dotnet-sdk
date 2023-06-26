using GreenArrow.Engine.Extensions;
using GreenArrow.Engine.RestApi;
using Microsoft.Extensions.Options;
using Moq.Protected;
using System.Net;
using System.Net.Http.Json;

namespace GreenArrow.Engine.HttpSubmissionApi
{
    public class HttpSubmissionApiTest
    {
        private static readonly Fixture specimens = new();

        private static IHttpSubmissionApi CreateSut(
            GreenArrowEngineSettings? settings = null,
            IHttpClientFactory? httpClientFactory = null
            )
        {
            settings ??= new GreenArrowEngineSettings { ServerUri = $"https://localhost/" };

            return new HttpSubmissionApiClient(
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
            // Arrange
            var settings = new GreenArrowEngineSettings { ServerUri = $"https://localhost/", HTTPSubmissionAPIEndpoint = "/api/v1/send.json" };
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = specimens.Create<HttpStatusCode>(),
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(settings, httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<HttpSubmissionRequest>();

            // Act
            await sut.PostAsync(request, CancellationToken.None);
            await sut.PutAsync(request, CancellationToken.None);

            // Assert
            httpMessageHandlerMock.Protected().Verify(
               nameof(HttpClient.SendAsync),
               Times.Exactly(2),
               ItExpr.Is<HttpRequestMessage>(request => request.RequestUri.AbsolutePath.EndsWith(settings.HTTPSubmissionAPIEndpoint)),
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

            var request = specimens.Create<HttpSubmissionRequest>();

            // Act
            var result = await sut.PostAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(httpResponseMessage.StatusCode, result.HttpStatusCode);
        }

        [Fact]
        public async Task Put_should_return_http_status_code_on_sucessfull()
        {
            // Arrange
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = specimens.Create<HttpStatusCode>(),
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<HttpSubmissionRequest>();

            // Act
            var result = await sut.PutAsync(request, CancellationToken.None);

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

            var request = specimens.Create<HttpSubmissionRequest>();
            var cancellationToken = specimens.Create<CancellationToken>();

            // Act
            var result = await Assert.ThrowsAsync<RestApiException>(() => sut.PostAsync(request, cancellationToken));

            // Assert
            Assert.Equal(exception, result.InnerException);
        }

        [Fact]
        public async Task Put_should_throw_RestApiException_upon_an_exception_in_the_implementation()
        {
            // Arrange
            var exception = specimens.Create<Exception>();

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(exception);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<HttpSubmissionRequest>();
            var cancellationToken = specimens.Create<CancellationToken>();

            // Act
            var result = await Assert.ThrowsAsync<RestApiException>(() => sut.PutAsync(request, cancellationToken));

            // Assert
            Assert.Equal(exception, result.InnerException);
        }

        [Fact]
        public async Task Post_should_return_deserialized_response_content_on_sucessfull()
        {
            // Arrange
            var httpSubmissionResponse = specimens.Create<HttpSubmissionResponse>();
            var httpContent = new StringContent(httpSubmissionResponse.ToJson());

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = httpContent,
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<HttpSubmissionRequest>();

            // Act
            var result = await sut.PostAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(httpSubmissionResponse.Id, result.Content.Id);
        }

        [Fact]
        public async Task Put_should_return_deserialized_response_content_on_sucessfull()
        {
            // Arrange
            var httpSubmissionResponse = specimens.Create<HttpSubmissionResponse>();
            var httpContent = JsonContent.Create(httpSubmissionResponse);

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = httpContent,
            };

            var httpMessageHandlerMock = CreateHttpMessageHandlerMock(httpResponseMessage);
            var httpClientFactoryMock = CreateHttpClientFactoryMock(httpMessageHandlerMock.Object);
            var sut = CreateSut(httpClientFactory: httpClientFactoryMock.Object);

            var request = specimens.Create<HttpSubmissionRequest>();

            // Act
            var result = await sut.PutAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(httpSubmissionResponse.Id, result.Content.Id);
        }
    }
}
