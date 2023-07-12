using Medium.Domain.List;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to Lists.
    /// </summary>
    public interface IListClient
    {
        /// <summary>
        /// Gets the list related information.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        Task<ListInfo> GetInfoByIdAsync(string listId);

        /// <summary>
        /// Gets a list of articles identifiers present in the given Medium List.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        Task<ListArticles> GetArticlesByListIdAsync(string listId);

        /// <summary>
        /// Gets a list of response identifiers of the comments on the given Medium List.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        Task<ListResponses> GetResponsesByListIdAsync(string listId);
    }
}
