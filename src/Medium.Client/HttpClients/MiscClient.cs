using Medium.Client.Abstractions;
using Medium.Client.Exceptions;
using Medium.Domain.Enums;
using Medium.Domain.Extensions;
using Medium.Domain.Miscellaneous;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class MiscClient : IMiscClient
    {
        private readonly BaseHttpClient _baseHttpClient;

        public MiscClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<IEnumerable<string>> GetTopFeedsByTagAsync(string tag, FeedMode feedMode, int count = 25, int after = 0)
        {
            if (count > 25)
                throw new InvalidParameterException($"The parameter '{nameof(count)}' can't be greather than 25.");
            if (after > 250)
                throw new InvalidParameterException($"The parameter '{nameof(after)}' can't be greather than 250.");

            var queryParams = $"?count={count}&after={after}";

            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"topfeeds/{tag}/{feedMode.GetValue()}{queryParams}", "topfeeds");
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
    }
}
