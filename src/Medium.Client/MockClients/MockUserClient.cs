using Medium.Client.Abstractions;
using Medium.Domain.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.MockClients
{
    internal class MockUserClient : IUserClient
    {
        private readonly Context _context;

        public MockUserClient(Context context)
        {
            _context = context;
        }

        public Task<IEnumerable<string>> GetArticlesIdByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetArticlesIdByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFollowersByUserIdAsync(string userId, int? count = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFollowingByUserIdAsync(string userId, int? count = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetIdByUsernameAsync(string username)
        {
            return Task.FromResult(_context.User.Id);
        }

        public Task<UserInfo> GetInfoByIdAsync(string userId)
        {
            return Task.FromResult(_context.User);
        }

        public Task<UserInfo> GetInfoByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetInterestByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserLists> GetListsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserPublications> GetPublicationsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetTopArticlesIdByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetTopArticlesIdByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
