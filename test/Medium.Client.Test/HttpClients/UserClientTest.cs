using FluentAssertions;
using Medium.Client.Exceptions;
using Medium.Client.HttpClients;
using Medium.Domain.User;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class UserClientTest
    {
        [Fact]
        public async Task GetInfoByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetInfoByIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserResponse());
        }

        [Fact]
        public async Task GetInfoByIdAsync_ReturnsNullAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = null
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetInfoByIdAsync("test-id");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetInfoByIdAsync_WithoutSuccessStatusCode_ThrowsExceptionAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = null,
                StatusCode = HttpStatusCode.NotFound
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));
            var action = async () => await usersClient.GetInfoByIdAsync("test-id");

            await action.Should().ThrowAsync<MediumClientException>();
        }

        [Fact]
        public async Task GetIdByUsernameAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetIdByUsernameAsync("usertest");

            result.Should().Be("test-id");
        }

        [Fact]
        public async Task GetInfoByUsernameAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetInfoByUsernameAsync("usertest");

            result.Should().BeEquivalentTo(MockUserResponse());
        }

        [Fact]
        public async Task GetArticlesIdByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticlesIdResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetArticlesIdByUserIdAsync("test-id");

            result.Should().Equal(MockArticleIdResponse());
        }

        [Fact]
        public async Task GetTopArticlesIdByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidTopArticlesIdResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetTopArticlesIdByUserIdAsync("test-id");

            result.Should().Equal(MockArticleIdResponse());
        }

        [Fact]
        public async Task GetInterestByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidInterestsIdResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetInterestByUserIdAsync("test-id");

            result.Should().Equal(MockInterestsResponse());
        }

        [Fact]
        public async Task GetListsByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserListsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetListsByUserIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserListsResponse());
        }

        [Fact]
        public async Task GetListsByUserIdAsync_WithEmptyObjectFromApi_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserListsWithEmptyObjectResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetListsByUserIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserListsWithEmptyListsResponse());
        }

        [Fact]
        public async Task GetPublicationsByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserPublicationsResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetPublicationsByUserIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserPublicationsResponse());
        }

        [Fact]
        public async Task GetFollowersByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowersResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetFollowersByUserIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserFollowersResponse());
        }

        [Fact]
        public async Task GetFollowersByUserIdAsync_WithCount_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowers_WithOneElement_Response()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetFollowersByUserIdAsync("test-id", 1);

            result.Should().BeEquivalentTo(MockUserFollowersResponse());
        }

        [Fact]
        public async Task GetFollowersByUserIdAsync_WithInvalidCount_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowers_WithOneElement_Response()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var action = async () => await usersClient.GetFollowersByUserIdAsync("test-id", 1700);
            await action.Should().ThrowAsync<InvalidParameterException>();
        }

        [Fact]
        public async Task GetFollowersByUserIdAsync_WithAllQueryParameters_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowers_WithOneElement_Response()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetFollowersByUserIdAsync("test-id", 20, "after-page-id");
            result.Should().BeEquivalentTo(MockUserFollowersResponse());
        }

        [Fact]
        public async Task GetFollowingByUserIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowingResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetFollowingByUserIdAsync("test-id");

            result.Should().BeEquivalentTo(MockUserIdsResponse());
        }

        [Fact]
        public async Task GetFollowingByUserIdAsync_WithCount_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowing_WithOneElement_Response()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await usersClient.GetFollowingByUserIdAsync("test-id", 1);

            result.Should().BeEquivalentTo(MockUserIdsResponse());
        }

        [Fact]
        public async Task GetFollowingByUserIdAsync_WithInvalidCount_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidUserFollowing_WithOneElement_Response()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            UserClient usersClient = new UserClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var action = async () => await usersClient.GetFollowingByUserIdAsync("test-id", 1800);
            await action.Should().ThrowAsync<InvalidParameterException>();
        }

        private UserInfo MockUserResponse()
        {
            return new UserInfo
            {
                Id = "test-id",
                Fullname = "User Test",
                Username = "usertest",
                AllowNotes = true,
                Bio = "bio test",
                FollowersCount = 1,
                FollowingCount = 1,
                IsSuspended = false,
                ImageUrl = "path_image_url.com",
                TopWriterIn = new List<string> { "id-1", "id-2" },
                IsWriterProgramEnrolled = false,
                MemberCreationDate = new DateTime(2023, 5, 10),
                TwitterUsername = "test-twitter",
                IsBookAuthor = false,
                HasList = true,
                PublicationFollowingCount = 27
            };
        }

        private HttpContent MockValidUserResponse()
        {
            return JsonContent.Create(new
            {
                id = "test-id",
                fullname = "User Test",
                username = "usertest",
                allow_notes = true,
                bio = "bio test",
                followers_count = 1,
                following_count = 1,
                is_suspended = false,
                image_url = "path_image_url.com",
                top_writer_in = new List<string> { "id-1", "id-2" },
                is_writer_program_enrolled = false,
                medium_member_at = new DateTime(2023, 5, 10),
                twitter_username = "test-twitter",
                is_book_author = false,
                has_list = true,
                publication_following_count = 27
            });
        }

        private HttpContent MockValidArticlesIdResponse()
        {
            return JsonContent.Create(new
            {
                associated_articles = new List<string> { "article-id-1", "article-id-2" }
            });
        }

        private HttpContent MockValidTopArticlesIdResponse()
        {
            return JsonContent.Create(new
            {
                top_articles = new List<string> { "article-id-1", "article-id-2" }
            });
        }

        private HttpContent MockValidInterestsIdResponse()
        {
            return JsonContent.Create(new
            {
                tags_followed = new List<string> { "programming", "tech" }
            });
        }

        private HttpContent MockValidUserListsResponse()
        {
            return JsonContent.Create(new
            {
                user_id = "test-id",
                lists = new List<string> { "my-list-1", "my-list-2" }
            });
        }

        private HttpContent MockValidUserListsWithEmptyObjectResponse()
        {
            return JsonContent.Create(new
            {
                user_id = "test-id",
                lists = new JObject()
            });
        }

        private HttpContent MockValidUserPublicationsResponse()
        {
            return JsonContent.Create(new
            {
                id = "test-id",
                publications = new
                { 
                    admin_in = new List<string> { "my-publication-1", "my-publication-2" },
                    writer_in = new List<string> { "publication-1", "publication-2" }
                }
            });
        }

        private HttpContent MockValidUserFollowersResponse()
        {
            return JsonContent.Create(new
            {
                followers = new List<string> { "user-1", "user-2" },
                id = "user_id",
                count = 10,
                next = "next_page_id",
                total_followers = 150
            });
        }

        private HttpContent MockValidUserFollowingResponse()
        {
            return JsonContent.Create(new
            {
                following = new List<string> { "user-1", "user-2" }
            });
        }

        private HttpContent MockValidUserFollowers_WithOneElement_Response()
        {
            return JsonContent.Create(new
            {
                followers = new List<string> { "user-1", "user-2" },
                id = "user_id",
                count = 10,
                next = "next_page_id",
                total_followers = 150
            });
        }

        private HttpContent MockValidUserFollowing_WithOneElement_Response()
        {
            return JsonContent.Create(new
            {
                following = new List<string> { "user-1", "user-2" }
            });
        }

        private List<string> MockArticleIdResponse()
        {
            return new List<string> { "article-id-1", "article-id-2" };
        }

        private List<string> MockInterestsResponse()
        {
            return new List<string> { "programming", "tech" };
        }

        private UserLists MockUserListsResponse()
        {
            return new UserLists
            {
                UserId = "test-id",
                Lists = new List<string> { "my-list-1", "my-list-2" }
            };
        }

        private UserLists MockUserListsWithEmptyListsResponse()
        {
            return new UserLists
            {
                UserId = "test-id",
                Lists = new List<string>()
            };
        }

        private UserPublications MockUserPublicationsResponse()
        {
            return new UserPublications
            {
                UserId = "test-id",
                Publications = new Publications
                {
                    AdminIn = new List<string> { "my-publication-1", "my-publication-2" },
                    WriteIn = new List<string> { "publication-1", "publication-2" }
                }
            };
        }
        
        private List<string> MockUserIdsResponse()
        {
            return new List<string>
            {
                "user-1", "user-2"
            };
        }

        private UserFollowers MockUserFollowersResponse()
        {
            return new UserFollowers
            {
                Followers = new List<string>
                {
                    "user-1", "user-2"
                },
                UserId = "user_id",
                Count = 10,
                NextPage = "next_page_id",
                TotalFollowers = 150
            };
        }
    }
}