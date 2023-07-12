using Medium.Domain.Enums;
using Medium.Domain.Miscellaneous;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to miscellaneous informations.
    /// </summary>
    public interface IMiscClient
    {
        /// <summary>
        /// Gets a list of article identifiers for the given tag and mode.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="feedMode"></param>
        /// <param name="count">To limit the number of top feeds. (lower than 25)</param>
        /// <param name="after">To get the subsequent top feeds. (lower than 250)</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetTopFeedsByTagAsync(string tag, FeedMode feedMode, int count = 25, int after = 0);

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
    }
}
