using Medium.Domain.Enums;
using Medium.Domain.Platform;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to miscellaneous informations.
    /// </summary>
    public interface IPlatformClient
    {
        /// <summary>
        /// Gets a list of article identifiers for the given tag and mode.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="feedMode"></param>
        /// <returns></returns>
        Task<TopFeeds> GetTopFeedsByTagAsync(string tag, FeedMode feedMode);

        /// <summary>
        /// Gets a list of top writers identifiers for a particular topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="count">Number of results. 10 by default.</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetTopWritersByTopicAsync(string topic, int count = 10);

        /// <summary>
        /// Gets a list of latest posts identifiers for a topic.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetLatestPostsByTopicAsync(string topic);

        /// <summary>
        /// Gets tag-related information.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<TagInfo> GetTagInfoAsync(string tag);

        /// <summary>
        /// Gets a list of related tags for the given tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetRelatedTagsAsync(string tag);

        /// <summary>
        /// Gets a list of recommended articles for the given tag. 
        /// This feed is similar to Topfeeds Trending Articles.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="page">Page number of recommendations. Between 1 and 20.</param>
        /// <returns></returns>
        Task<RecommendedFeed> GetRecommendedFeedAsync(string tag, int page = 1);
    }
}
