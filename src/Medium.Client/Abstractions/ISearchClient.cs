using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to the API search engine.
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        /// Gets a list of user identifiers for the given search query results. (Max Length = 1000)
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetUsersByQueryAsync(string searchQuery);

        /// <summary>
        /// Gets the list of publication identifiers for the given search query results. (Max Length = 1000)
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPublicationsByQueryAsync(string searchQuery);

        /// <summary>
        /// Gets the list of articles identifiers for the given search query results. (Max Length = 1000)
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetArticlesByQueryAsync(string searchQuery);

        /// <summary>
        /// Gets a list of tags for the given search query results. (Max Length = 1000)
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetTagsByQueryAsync(string searchQuery);

        /// <summary>
        /// Gets an list of lists identifiers for the given search query results. (Max Length = 1000)
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetListsByQueryAsync(string searchQuery);
    }
}
