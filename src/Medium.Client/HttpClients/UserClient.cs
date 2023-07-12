using Medium.Client.Abstractions;
using Medium.Client.Exceptions;
using Medium.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.HttpClients
{
    internal class UserClient : IUserClient
    {
        private readonly string _basePath = "user";
        private readonly BaseHttpClient _baseHttpClient;

        public UserClient(BaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }

        public async Task<string> GetIdByUsernameAsync(string username)
        {
            var result = await _baseHttpClient.GetAsync<string>($"{_basePath}/id_for/{username}", "id");
            return result;
        }

        public async Task<UserInfo> GetInfoByIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<UserInfo>($"{_basePath}/{userId}");
            return result;
        }

        public async Task<UserInfo> GetInfoByUsernameAsync(string username)
        {
            string userId = await GetIdByUsernameAsync(username);

            if (string.IsNullOrWhiteSpace(userId))
                return null;

            UserInfo userInfo = await GetInfoByIdAsync(userId);
            return userInfo;
        }

        public async Task<IEnumerable<string>> GetArticlesIdByUserIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{userId}/articles", "associated_articles");
            return result;
        }

        public async Task<IEnumerable<string>> GetTopArticlesIdByUserIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{userId}/top_articles", "top_articles");
            return result;
        }

        public async Task<IEnumerable<string>> GetInterestByUserIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{userId}/interests", "tags_followed");
            return result;
        }

        public async Task<UserLists> GetListsByUserIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<UserLists>($"{_basePath}/{userId}/lists");
            return result;
        }

        public async Task<UserPublications> GetPublicationsByUserIdAsync(string userId)
        {
            var result = await _baseHttpClient.GetAsync<UserPublications>($"{_basePath}/{userId}/publications");
            return result;
        }

        public async Task<IEnumerable<string>> GetFollowersByUserIdAsync(string userId, int? count = null)
        {
            if (count > 1500)
                throw new InvalidParameterException($"The parameter '{nameof(count)}' can't be greater than 1500.");

            var queryParam = string.Empty;
            if(count.HasValue)
                queryParam = $"?count={count}";

            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{userId}/followers{queryParam}", "followers");
            return result;
        }

        public async Task<IEnumerable<string>> GetFollowingByUserIdAsync(string userId, int? count = null)
        {
            if (count > 1500)
                throw new InvalidParameterException($"The parameter '{nameof(count)}' can't be greater than 1500.");

            var queryParam = string.Empty;
            if (count.HasValue)
                queryParam = $"?count={count}";

            var result = await _baseHttpClient.GetAsync<IEnumerable<string>>($"{_basePath}/{userId}/following{queryParam}", "following");
            return result;
        }
    }
}
