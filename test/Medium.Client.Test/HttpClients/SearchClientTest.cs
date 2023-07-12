using FluentAssertions;
using Medium.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class SearchClientTest
    {
        [Fact]
        public async Task GetArticlesByQueryAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticlesResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            SearchClient searchClient = new SearchClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await searchClient.GetArticlesByQueryAsync("test-id");

            result.Should().BeEquivalentTo(new List<string> { "article-1", "article-2" });
        }

        [Fact]
        public async Task GetListsByQueryAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidListsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            SearchClient searchClient = new SearchClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await searchClient.GetListsByQueryAsync("test-id");

            result.Should().BeEquivalentTo(new List<string> { "list-1", "list-2" });
        }

        [Fact]
        public async Task GetPublicationsByQueryAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidPublicationsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            SearchClient searchClient = new SearchClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await searchClient.GetPublicationsByQueryAsync("test-id");

            result.Should().BeEquivalentTo(new List<string> { "pub-1", "pub-2" });
        }

        [Fact]
        public async Task GetTagsByQueryAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTagsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            SearchClient searchClient = new SearchClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await searchClient.GetTagsByQueryAsync("test-id");

            result.Should().BeEquivalentTo(new List<string> { "tag-1", "tag-2" });
        }

        [Fact]
        public async Task GetUsersByQueryAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUsersResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            SearchClient searchClient = new SearchClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await searchClient.GetUsersByQueryAsync("test-id");

            result.Should().BeEquivalentTo(new List<string> { "user-1", "user-2" });
        }

        private HttpContent MockValidArticlesResponse()
        {
            return JsonContent.Create(new
            {
                articles = new List<string> { "article-1", "article-2" }
            });
        }

        private HttpContent MockValidListsResponse()
        {
            return JsonContent.Create(new
            {
                lists = new List<string> { "list-1", "list-2" }
            });
        }

        private HttpContent MockValidPublicationsResponse()
        {
            return JsonContent.Create(new
            {
                publications = new List<string> { "pub-1", "pub-2" }
            });
        }

        private HttpContent MockValidTagsResponse()
        {
            return JsonContent.Create(new
            {
                tags = new List<string> { "tag-1", "tag-2" }
            });
        }

        private HttpContent MockValidUsersResponse()
        {
            return JsonContent.Create(new
            {
                users = new List<string> { "user-1", "user-2" }
            });
        }
    }
}
