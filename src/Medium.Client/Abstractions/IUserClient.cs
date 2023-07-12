using Medium.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Client.Abstractions
{
    /// <summary>
    /// Provides access to Users.
    /// </summary>
    public interface IUserClient
    {
        /// <summary>
        /// Gets the User Id by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<string> GetIdByUsernameAsync(string username);

        /// <summary>
        /// Gets the User by Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserInfo> GetInfoByIdAsync(string userId);

        /// <summary>
        /// Gets the User by username. 
        /// This method calls 2 API endpoints.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserInfo> GetInfoByUsernameAsync(string username);

        /// <summary>
        /// Gets a list of article identifiers by User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetArticlesIdByUserIdAsync(string userId);

        /// <summary>
        /// Gets a list of top article identifiers by User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetTopArticlesIdByUserIdAsync(string userId);

        /// <summary>
        /// Gets a list of tags that the given user follows.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetInterestByUserIdAsync(string userId);

        /// <summary>
        /// Gets a list of list identifiers created by the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserLists> GetListsByUserIdAsync(string userId);

        /// <summary>
        /// Gets a list of publication identifiers where the user is the editor and/or creator.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserPublications> GetPublicationsByUserIdAsync(string userId);

        /// <summary>
        /// Gets a list of user identifiers of the followers for the given user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="count">Number of results. Max value 1500.</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetFollowersByUserIdAsync(string userId, int? count = null);

        /// <summary>
        /// Gets a list of user identifiers that the user is following.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="count">Number of results. Max value 1500.</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetFollowingByUserIdAsync(string userId, int? count = null);
    }
}
