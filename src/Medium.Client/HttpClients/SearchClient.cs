using Medium.Client.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class SearchClient : ISearchClient
    {
        private readonly string _basePath = "search";
        private readonly BaseHttpClient _baseHttpClient;

        public SearchClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<IEnumerable<string>> GetArticlesByQueryAsync(string searchQuery)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/articles?query={searchQuery}", "articles");
            return result;
        }

        public async Task<IEnumerable<string>> GetListsByQueryAsync(string searchQuery)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/lists?query={searchQuery}", "lists");
            return result;
        }

        public async Task<IEnumerable<string>> GetPublicationsByQueryAsync(string searchQuery)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/publications?query={searchQuery}", "publications");
            return result;
        }

        public async Task<IEnumerable<string>> GetTagsByQueryAsync(string searchQuery)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/tags?query={searchQuery}", "tags");
            return result;
        }

        public async Task<IEnumerable<string>> GetUsersByQueryAsync(string searchQuery)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/users?query={searchQuery}", "users");
            return result;
        }
    }
}
