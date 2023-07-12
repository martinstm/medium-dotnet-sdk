using FluentAssertions;
using Medium.Client.Exceptions;
using Medium.Client.HttpClients;
using Medium.Domain.Enums;
using Medium.Domain.Extensions;
using Medium.Domain.Miscellaneous;
using Medium.Domain.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class MiscClientTest
    {
        [Fact]
        public async Task GetTopFeedsByTagAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopFeedsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await miscClient.GetTopFeedsByTagAsync("test", FeedMode.NEW);

            result.Should().BeEquivalentTo(new List<string>
            {
                "top-1", "top-2"
            });
        }

        [Fact]
        public async Task GetTopFeedsByTagAsync_WithInvalidCount_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopFeedsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var action = async() => await miscClient.GetTopFeedsByTagAsync("test", FeedMode.NEW, 30);
            await action.Should().ThrowAsync<InvalidParameterException>();
        }

        [Fact]
        public async Task GetTopFeedsByTagAsync_WithInvalidAfter_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopFeedsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var action = async() => await miscClient.GetTopFeedsByTagAsync("test", FeedMode.NEW, 20, 300);
            await action.Should().ThrowAsync<InvalidParameterException>();
        }

        [Fact]
        public async Task GetTopWritersByTopicAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopWritersResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await miscClient.GetTopWritersByTopicAsync("test");

            result.Should().BeEquivalentTo(new List<string>
            {
                "writer-1", "writer-2"
            });
        }

        [Fact]
        public async Task GetLatestPostsByTopicAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidLatestPostsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await miscClient.GetLatestPostsByTopicAsync("test");

            result.Should().BeEquivalentTo(new List<string>
            {
                "post-1", "post-2"
            });
        }

        [Fact]
        public async Task GetTagInfoAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTagInfoResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await miscClient.GetTagInfoAsync("test");

            result.Should().BeEquivalentTo(MockTagResponse());
        }

        [Fact]
        public async Task GetRelatedTagsAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidRelatedTagsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            MiscClient miscClient = new MiscClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await miscClient.GetRelatedTagsAsync("test");

            result.Should().BeEquivalentTo(new List<string>
            {
                "related-1", "related-2"
            });
        }

        private HttpContent MockValidTopFeedsResponse()
        {
            return JsonContent.Create(new
            {
                topfeeds = new List<string> { "top-1", "top-2" }
            });
        }

        private HttpContent MockValidTopWritersResponse()
        {
            return JsonContent.Create(new
            {
                top_writers = new List<string> { "writer-1", "writer-2" }
            });
        }

        private HttpContent MockValidLatestPostsResponse()
        {
            return JsonContent.Create(new
            {
                latestposts = new List<string> { "post-1", "post-2" }
            });
        }

        private TagInfo MockTagResponse()
        {
            return new TagInfo
            {
                ArticlesCount = 1,
                AuthorsCount = 2,
                Followers = 3,
                LatestArticlesCount = 4,
                LatestAuthorsCount = 5,
                Name = "test tag",
                Tag = "test"
            };
        }

        private HttpContent MockValidTagInfoResponse()
        {
            return JsonContent.Create(new
            {
                articles_count = 1,
                authors_count = 2,
                followers = 3,
                latest_articles_count = 4,
                latest_authors_count = 5,
                name = "test tag",
                tag = "test"
            });
        }

        private HttpContent MockValidRelatedTagsResponse()
        {
            return JsonContent.Create(new
            {
                related_tags = new List<string> { "related-1", "related-2" },
                given_tag = "test"
            });
        }
    }
}
