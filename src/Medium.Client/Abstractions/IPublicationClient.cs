using Medium.Domain.Publication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to Publications.
    /// </summary>
    public interface IPublicationClient
    {
        /// <summary>
        /// Gets the unique publication identifier for the given publication_slug.
        /// </summary>
        /// <param name="slug">It's a lowercased hyphen-separated unique string alloted to each Medium Publication.</param>
        /// <returns></returns>
        Task<PublicationId> GetPublicationIdAsync(string slug);

        /// <summary>
        /// Gets the publication related information.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PublicationInfo> GetInfoByIdAsync(string publicationId);

        /// <summary>
        /// Gets the list of articles identifiers, of the latest 25 articles, posted in that publication.
        /// </summary>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetArticlesByPublicationIdAsync(string publicationId);

        /// <summary>
        /// Gets the newsletter related information.
        /// </summary>
        /// <param name="publicationId"></param>
        /// <returns></returns>
        Task<PublicationNewsletter> GetNewsletterByPublicationIdAsync(string publicationId);
    }
}
