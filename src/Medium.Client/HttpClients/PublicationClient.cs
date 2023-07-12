using Medium.Client.Abstractions;
using Medium.Domain.Publication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class PublicationClient : IPublicationClient
    {
        private readonly string _basePath = "publication";
        private readonly BaseHttpClient _baseHttpClient;

        public PublicationClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }
        public async Task<PublicationId> GetPublicationIdAsync(string slug)
        {
            var result = await _baseHttpClient.GetAsync<PublicationId>($"{_basePath}/id_for/{slug}");
            return result;
        }

        public async Task<PublicationInfo> GetInfoByIdAsync(string publicationId)
        {
            var result = await _baseHttpClient.GetAsync<PublicationInfo>($"{_basePath}/{publicationId}");
            return result;
        }

        public async Task<IEnumerable<string>> GetArticlesByPublicationIdAsync(string publicationId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{publicationId}/articles", "publication_articles");
            return result;
        }

        public async Task<PublicationNewsletter> GetNewsletterByPublicationIdAsync(string publicationId)
        {
            var result = await _baseHttpClient.GetAsync<PublicationNewsletter>($"{_basePath}/{publicationId}/newsletter");
            return result;
        }
    }
}
