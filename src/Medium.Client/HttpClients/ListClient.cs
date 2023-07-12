using Medium.Client.Abstractions;
using Medium.Domain.List;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class ListClient : IListClient
    {
        private readonly string _basePath = "list";
        private readonly BaseHttpClient _baseHttpClient;

        public ListClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<ListInfo> GetInfoByIdAsync(string listId)
        {
            var result = await _baseHttpClient.GetAsync<ListInfo>($"{_basePath}/{listId}");
            return result;
        }

        public async Task<ListArticles> GetArticlesByListIdAsync(string listId)
        {
            var result = await _baseHttpClient.GetAsync<ListArticles>($"{_basePath}/{listId}/articles");
            return result;
        }

        public async Task<ListResponses> GetResponsesByListIdAsync(string listId)
        {
            var result = await _baseHttpClient.GetAsync<ListResponses>($"{_basePath}/{listId}/responses");
            return result;
        }
    }
}
