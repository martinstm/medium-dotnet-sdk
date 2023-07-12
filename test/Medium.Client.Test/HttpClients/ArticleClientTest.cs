using FluentAssertions;
using Medium.Client.HttpClients;
using Medium.Domain.Article;
using Medium.Domain.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class ArticleClientTest
    {
        [Fact]
        public async Task GetInfoByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetInfoByIdAsync("article-id");

            result.Should().BeEquivalentTo(MockArticleResponse());
        }

        [Fact]
        public async Task GetDetailMarkdownByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleMarkdownResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetDetailMarkdownByIdAsync("article-id");

            result.Should().BeEquivalentTo("## title in markdown");
        }

        [Fact]
        public async Task GetDetailHtmlByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleHtmlResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetDetailHtmlByIdAsync("article-id");

            result.Should().BeEquivalentTo("<p>title in HTML</p>");
        }

        [Fact]
        public async Task GetDetailTextByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleTextResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetDetailTextByIdAsync("article-id");

            result.Should().BeEquivalentTo("title in text");
        }

        [Fact]
        public async Task GetResponsesAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleResponsesIdResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetResponsesAsync("article-id");

            result.Should().BeEquivalentTo(new List<string>() { "response-id" });
        }

        [Fact]
        public async Task GetFansAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleFansResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetFansAsync("article-id");

            result.Should().BeEquivalentTo(new List<string>() { "user-id" });
        }

        [Fact]
        public async Task GetRelatedAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticleRelatedResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            ArticleClient articleClient = new ArticleClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await articleClient.GetRelatedAsync("article-id");

            result.Should().BeEquivalentTo(new List<string>() { "related-post-id" });
        }

        private ArticleInfo MockArticleResponse()
        {
            return new ArticleInfo
            {
                Id = "article-id",
                AuthorId = "user-id",
                Claps = 10,
                ImageUrl = "image_url_path",
                Language = "en",
                PublicationId = "pub-id",
                LastModifiedDate = new DateTime(2023, 5, 10),
                PublishedDate = new DateTime(2023, 5, 1),
                ReadingTime = 5.0,
                ResponsesCount = 2,
                Subtitle = "my article",
                Tags = new List<string>() { "tag1" },
                Title = "my title",
                Topics = new List<string>() { "topic1", "topic2" },
                Url = "article_url",
                Voters = 7,
                WordCount = 350
            };
        }

        private HttpContent MockValidArticleResponse()
        {
            return JsonContent.Create(new
            {
                id = "article-id",
                author = "user-id",
                claps = 10,
                image_url = "image_url_path",
                lang = "en",
                publication_id = "pub-id",
                last_modified_at = new DateTime(2023, 5, 10),
                published_at = new DateTime(2023, 5, 1),
                reading_time = 5.0,
                responses_count = 2,
                subtitle = "my article",
                tags = new List<string>() { "tag1" },
                title = "my title",
                topics = new List<string>() { "topic1", "topic2" },
                url = "article_url",
                voters = 7,
                word_count = 350
            });
        }

        private HttpContent MockValidArticleMarkdownResponse()
        {
            return JsonContent.Create(new
            {
                markdown = "## title in markdown"
            });
        }

        private HttpContent MockValidArticleHtmlResponse()
        {
            return JsonContent.Create(new
            {
                html = "<p>title in HTML</p>"
            });
        }

        private HttpContent MockValidArticleTextResponse()
        {
            return JsonContent.Create(new
            {
                content = "title in text"
            });
        }

        private HttpContent MockValidArticleResponsesIdResponse()
        {
            return JsonContent.Create(new
            {
                responses = new List<string>() { "response-id" }
            });
        }

        private HttpContent MockValidArticleFansResponse()
        {
            return JsonContent.Create(new
            {
                voters = new List<string>() { "user-id" }
            });
        }

        private HttpContent MockValidArticleRelatedResponse()
        {
            return JsonContent.Create(new
            {
                related_articles = new List<string>() { "related-post-id" }
            });
        }
    }
}
