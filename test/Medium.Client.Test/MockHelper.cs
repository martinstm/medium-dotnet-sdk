using Medium.Client.HttpClients;
using Medium.Client.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Medium.Client.Test
{
    public static class MockHelper
    {
        public static MediumOptions MockOptions()
        {
            var settings = new Dictionary<string, string>
            {
                {"Medium:IntegrationToken", "token"}
            };

            var configuration = new ConfigurationBuilder()
                                    .AddInMemoryCollection(settings)
                                    .Build();

            return new MediumOptions(configuration);
        }

        public static Mock<HttpMessageHandler> CreateHttpMessageHandler(HttpResponseMessage httpResponse)
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);
            return httpMessageHandlerMock;
        }

        public static BaseHttpClient CreateBaseHttpClient(Mock<HttpMessageHandler> mockHttpMessageHandler)
        {
            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };

            return new BaseHttpClient(httpClient);
        }
    }
}
