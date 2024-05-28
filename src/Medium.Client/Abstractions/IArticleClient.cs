using Medium.Domain.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to Articles.
    /// </summary>
    public interface IArticleClient
    {
        /// <summary>
        /// Gets the Article by Id.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<ArticleInfo> GetInfoByIdAsync(string articleId);

        /// <summary>
        /// Gets the Article content in Markdown format.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<string> GetDetailMarkdownByIdAsync(string articleId);

        /// <summary>
        /// Gets the Article content in HTML format.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<string> GetDetailHtmlByIdAsync(string articleId);

        /// <summary>
        /// Gets the Article content in plain text format.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<string> GetDetailTextByIdAsync(string articleId);

        /// <summary>
        /// Gets a list of responses identifiers for a given article.
        /// To get the response detail use the <see cref="GetDetailTextByIdAsync(string)"/>
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetResponsesAsync(string articleId);

        /// <summary>
        /// Gets a list of user identifiers of the people who clapped on the article.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetFansAsync(string articleId);

        /// <summary>
        /// Gets a list of 5 related posts.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetRelatedAsync(string articleId);

        /// <summary>
        /// Gets a list of URLs for the assets present in the article.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<ArticleAssets> GetAssetsAsync(string articleId);

        /// <summary>
        /// Gets a list of 10 articles as recommended by the Medium, for the given article.
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetRecommendedAsync(string articleId);
    }
}
