using Medium.Client.Abstractions;
using Medium.Client.Exceptions;
using Medium.Domain.Enums;
using Medium.Domain.Extensions;
using Medium.Domain.Platform;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class PlatformClient : IPlatformClient
    {
        private readonly BaseHttpClient _baseHttpClient;

        public PlatformClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<TopFeeds> GetTopFeedsByTagAsync(string tag, FeedMode feedMode)
        {
            var result = await _baseHttpClient.GetAsync<TopFeeds>($"topfeeds/{tag}/{feedMode.GetValue()}");
            return result;
        }

        public async Task<IEnumerable<string>> GetTopWritersByTopicAsync(string topic, int count = 10)
        {
            var queryParams = $"?count={count}";

            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"top_writers/{topic}{queryParams}", "top_writers");
            return result;
        }

        public async Task<IEnumerable<string>> GetLatestPostsByTopicAsync(string topic)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"latestposts/{topic}", "latestposts");
            return result;
        }

        public async Task<TagInfo> GetTagInfoAsync(string tag)
        {
            var result = await _baseHttpClient.GetAsync<TagInfo>($"tag/{tag}");
            return result;
        }

        public async Task<IEnumerable<string>> GetRelatedTagsAsync(string tag)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"related_tags/{tag}", "related_tags");
            return result;
        }

        public async Task<RecommendedFeed> GetRecommendedFeedAsync(string tag, int page = 1)
        {
            if (page < 0 || page > 20)
                throw new InvalidParameterException($"The parameter '{nameof(page)}' must be between 1 and 20.");

            var queryParams = $"?page={page}";

            var result = await _baseHttpClient.GetAsync<RecommendedFeed>($"recommended_feed/{tag}{queryParams}");
            return result;
        }
    }
}
