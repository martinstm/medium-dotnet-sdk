using FluentAssertions;
using Medium.Client.Exceptions;
using Medium.Client.HttpClients;
using Medium.Domain.Enums;
using Medium.Domain.Platform;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class PlatformClientTest
    {
        [Fact]
        public async Task GetTopFeedsByTagAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopFeedsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetTopFeedsByTagAsync("test", FeedMode.NEW);

            result.Should().BeEquivalentTo(MockTopFeedsResponse());
        }

        [Fact]
        public async Task GetTopWritersByTopicAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopWritersResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetTopWritersByTopicAsync("test");

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
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetLatestPostsByTopicAsync("test");

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
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetTagInfoAsync("test");

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
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetRelatedTagsAsync("test");

            result.Should().BeEquivalentTo(new List<string>
            {
                "related-1", "related-2"
            });
        }

        [Fact]
        public async Task GetRecommendedFeedAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidRecommendedFeedResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await platformClient.GetRecommendedFeedAsync("test");

            result.Should().BeEquivalentTo(MockRecommendedFeedResponse());
        }

        [Fact]
        public async Task GetRecommendedFeedAsync_WithInvalidPage_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = null
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PlatformClient platformClient = new PlatformClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var action = async () => await platformClient.GetRecommendedFeedAsync("test", 50);
            await action.Should().ThrowAsync<InvalidParameterException>();
        }

        private HttpContent MockValidTopFeedsResponse()
        {
            return JsonContent.Create(new
            {
                topfeeds = new List<string> { "top-1", "top-2" },
                count = 1,
                tag = "test-tag",
                mode = "NEW"
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

        private TopFeeds MockTopFeedsResponse()
        {
            return new TopFeeds
            {
                Tag = "test-tag",
                Count = 1,
                Mode = FeedMode.NEW,
                Feeds = new List<string> { "top-1", "top-2" }
            };
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

        private RecommendedFeed MockRecommendedFeedResponse()
        {
            return new RecommendedFeed
            {
                Tag = "test",
                Count = 2,
                Page = 4,
                RecommendedArticles = new[] { "test-1", "test-2" }
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

        private HttpContent MockValidRecommendedFeedResponse()
        {
            return JsonContent.Create(new
            {
                recommended_feed = new[] {"test-1", "test-2"},
                count = 2,
                tag = "test",
                page = 4
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
