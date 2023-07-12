using FluentAssertions;
using Medium.Client.HttpClients;
using Medium.Domain.List;
using Medium.Domain.Publication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class ListClientTest
    {
        [Fact]
        public async Task GetPublicationIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidListInfoResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ListClient listClient = new ListClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await listClient.GetInfoByIdAsync("list-id");

            result.Should().BeEquivalentTo(MockListResponse());
        }

        [Fact]
        public async Task GetArticlesByListIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidListArticlesResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ListClient listClient = new ListClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await listClient.GetArticlesByListIdAsync("list-id");

            result.Should().BeEquivalentTo(MockListArticlesResponse());
        }

        [Fact]
        public async Task GetResponsesByListIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidListResponsesResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ListClient listClient = new ListClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await listClient.GetResponsesByListIdAsync("list-id");

            result.Should().BeEquivalentTo(MockListResponsesResponse());
        }

        private ListInfo MockListResponse()
        {
            return new ListInfo
            {
                Id = "list-id",
                CreatorId = "user-id",
                Count = 10,
                ThumbnailUrl = "list-url",
                Description = "description",
                Name = "name_list",
                Claps = 40,
                CreationDate = new DateTime(2023, 3, 23),
                LastInsertionDate = new DateTime(2023, 7, 11),
                ResponsesCount = 10,
                Voters = 32
            };
        }

        private ListArticles MockListArticlesResponse()
        {
            return new ListArticles
            {
                Id = "list-id",
                Articles = new List<string> { "article-1", "article-2" }
            };
        }

        private ListResponses MockListResponsesResponse()
        {
            return new ListResponses
            {
                Id = "list-id",
                Responses = new List<string> { "response-1", "response-2" }
            };
        }


        private HttpContent MockValidListInfoResponse()
        {
            return JsonContent.Create(new
            {
                id = "list-id",
                author = "user-id",
                count = 10,
                thumbnail = "list-url",
                description = "description",
                name = "name_list",
                claps = 40,
                created_at = new DateTime(2023, 3, 23),
                last_item_inserted_at = new DateTime(2023, 7, 11),
                responses_count = 10,
                voters = 32
            });
        }

        private HttpContent MockValidListArticlesResponse()
        {
            return JsonContent.Create(new
            {
                id = "list-id",
                list_articles = new List<string> { "article-1", "article-2" }
            });
        }

        private HttpContent MockValidListResponsesResponse()
        {
            return JsonContent.Create(new
            {
                id = "list-id",
                responses = new List<string> { "response-1", "response-2" }
            });
        }
    }
}
