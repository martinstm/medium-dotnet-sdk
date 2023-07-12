using Medium.Client.Abstractions;
using Medium.Domain.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class ArticleClient : IArticleClient
    {
        private readonly string _basePath = "article";
        private readonly BaseHttpClient _baseHttpClient;

        public ArticleClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<ArticleInfo> GetInfoByIdAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<ArticleInfo>($"{_basePath}/{articleId}");
            return result;
        }

        public async Task<string> GetDetailMarkdownByIdAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<string>($"{_basePath}/{articleId}/markdown", "markdown");
            return result;
        }

        public async Task<string> GetDetailHtmlByIdAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<string>($"{_basePath}/{articleId}/html", "html");
            return result;
        }

        public async Task<string> GetDetailTextByIdAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<string>($"{_basePath}/{articleId}/content", "content");
            return result;
        }

        public async Task<IEnumerable<string>> GetResponsesAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{articleId}/responses", "responses");
            return result;
        }

        public async Task<IEnumerable<string>> GetFansAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{articleId}/fans", "voters");
            return result;
        }

        public async Task<IEnumerable<string>> GetRelatedAsync(string articleId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{articleId}/related", "related_articles");
            return result;
        }
    }
}
