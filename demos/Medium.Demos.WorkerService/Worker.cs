using Medium.Client;
using Medium.Client.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Medium.Demos.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        // user id  = ae4e0c9bd233
        // username = martinstm
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IMediumClient mediumClient = scope.ServiceProvider.GetRequiredService<IMediumClient>();
                var userId = "ae4e0c9bd233";
                var user = await mediumClient.Users.GetInfoByIdAsync("ae4e0c9bd233");
                //var userInfo1 = await mediumClient.GetInterestByUserIdAsync("ae4e0c9bd233");
                //var userInfo2 = await mediumClient.GetListsByUserIdAsync("ae4e0c9bd233");
                //var userInfo3 = await mediumClient.GetPublicationsByUserIdAsync("ae4e0c9bd233");
                //var followers = await mediumClient.Users.GetFollowersByUserIdAsync(userId);
                //var followersCount = await mediumClient.Users.GetFollowersByUserIdAsync(userId, 30);

                //var following = await mediumClient.Users.GetFollowingByUserIdAsync(userId);
                //var followingCount = await mediumClient.Users.GetFollowingByUserIdAsync(userId, 50);

                //var pub = await mediumClient.Publications.GetPublicationIdAsync("towards-data-science");
                //var pub2 = await mediumClient.Publications.GetInfoByIdAsync(pub.Id);
                //var pub3 = await mediumClient.Publications.GetArticlesByPublicationIdAsync(pub.Id);
                //var pub4 = await mediumClient.Publications.GetNewsletterByPublicationIdAsync(pub.Id);

                //var list = await mediumClient.Lists.GetInfoByIdAsync("3d8f744f5370");
                //var list2 = await mediumClient.Lists.GetArticlesByListIdAsync(list.Id);
                //var list3 = await mediumClient.Lists.GetResponsesByListIdAsync(list.Id);

                //var test1 = await mediumClient.Miscellaneous.GetTopFeedsByTagAsync("azure", Domain.Enums.FeedMode.TOP_YEAR);
                //var test2 = await mediumClient.Miscellaneous.GetTagInfoAsync("azure");
                //var test3 = await mediumClient.Miscellaneous.GetLatestPostsByTopicAsync("azure");
                //var test4 = await mediumClient.Miscellaneous.GetRelatedTagsAsync("azure");
                //var test5 = await mediumClient.Miscellaneous.GetTopWritersByTopicAsync("azure");

                var searchQuery = "azure cloud";
                //var test1 = await mediumClient.Search.GetArticlesByQueryAsync(searchQuery);
                //var test2 = await mediumClient.Search.GetTagsByQueryAsync(searchQuery);
                //var test3 = await mediumClient.Search.GetPublicationsByQueryAsync(searchQuery);
                //var test4 = await mediumClient.Search.GetListsByQueryAsync(searchQuery);
                //var test5 = await mediumClient.Search.GetUsersByQueryAsync("data engineer");


                // TODO api problems? return error "invalid input"
                // GetListsByUserIdAsync
                // GetPublicationsByUserIdAsync 


                //var articleContent = await mediumClient.Articles.GetDetailTextByIdAsync("a6632693d3e1");
                //var userArticles = await mediumClient.Users.GetArticlesIdByUserId("ae4e0c9bd233");
                //var topUserArticles = await mediumClient.Users.GetTopArticlesIdByUserId("ae4e0c9bd233");

                //var article = await mediumClient.Articles.GetInfoByIdAsync("a6632693d3e1");

                //PostRequest postRequest = PostBuilder.New(title, content, ContentFormat.Markdown)
                //                                     .WithLicense(LicenseType.AllRightsReserved)
                //                                     .WithStatus(PublishStatus.Draft)
                //                                     .WithTags(new string[] { "test", "api-sdk" })
                //                                     .Build();

                //Post post = await mediumClient.Posts.Create(user.Id, postRequest);

                //_logger.LogInformation($"User '{user.Fullname}'.");
            }
        }
    }
}