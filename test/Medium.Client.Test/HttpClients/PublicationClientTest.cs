using FluentAssertions;
using Medium.Client.HttpClients;
using Medium.Domain.Publication;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Medium.Client.Test.HttpClients
{
    public class PublicationClientTest
    {
        [Fact]
        public async Task GetPublicationIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidPublicationIdResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PublicationClient publicationClient = new PublicationClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await publicationClient.GetPublicationIdAsync("slug_pub");

            result.Should().BeEquivalentTo(MockPublicationIdResponse());
        }

        [Fact]
        public async Task GetInfoByIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidPublicationResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PublicationClient publicationClient = new PublicationClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await publicationClient.GetInfoByIdAsync("pub-id");

            result.Should().BeEquivalentTo(MockPublicationResponse());
        }

        [Fact]
        public async Task GetArticlesByPublicationIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidArticlesResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PublicationClient publicationClient = new PublicationClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await publicationClient.GetArticlesByPublicationIdAsync("pub-id");

            result.Should().BeEquivalentTo(new List<string> { "article-1", "article-2" });
        }

        [Fact]
        public async Task GetNewsletterByPublicationIdAsync_SuccessAsync()
        {
            var httpResponse = new HttpResponseMessage
            {
                Content = MockValidNewsletterResponse()
            };

            var httpMessageHandlerMock = MockHelper.CreateHttpMessageHandler(httpResponse);
            PublicationClient publicationClient = new PublicationClient(MockHelper.CreateBaseHttpClient(httpMessageHandlerMock));

            var result = await publicationClient.GetNewsletterByPublicationIdAsync("pub-id");

            result.Should().BeEquivalentTo(MockPublicationNewsletterResponse());
        }

        private PublicationInfo MockPublicationResponse()
        {
            return new PublicationInfo
            {
                Id = "pub-id",
                CreatorId = "user-id",
                Followers = 10,
                Tags = new List<string>() { "tag1" },
                TagLine = "tag line text",
                Url = "pub-url",
                Description = "description",
                Editors = new List<string>() { "editor1", "editor2" },
                FacebookPageName = "fcb_username",
                InstagramUsername = "insta_username",
                TwitterUsername = "twt_username",
                Name = "name_pub",
                Slug = "slug_pub"
            };
        }

        private PublicationId MockPublicationIdResponse()
        {
            return new PublicationId
            {
                Id = "pub-id",
                Slug = "slug_pub"
            };
        }

        private PublicationNewsletter MockPublicationNewsletterResponse()
        {
            return new PublicationNewsletter
            {
                Id = "pub-id",
                CreatorId = "user-1",
                Subscribers  = 10,
                ImageUrl = "image_url",
                Description = "description",
                Name = "name_pub",
                Slug = "slug_pub"
            };
        }

        private HttpContent MockValidPublicationResponse()
        {
            return JsonContent.Create(new
            {
                id = "pub-id",
                creator = "user-id",
                followers = 10,
                tags = new List<string>() { "tag1" },
                tagline = "tag line text",
                url = "pub-url",
                description = "description",
                editors = new List<string>() { "editor1", "editor2" },
                facebook_pagename = "fcb_username",
                instagram_username = "insta_username",
                twitter_username = "twt_username",
                name = "name_pub",
                slug = "slug_pub"
            });
        }

        private HttpContent MockValidNewsletterResponse()
        {
            return JsonContent.Create(new
            {
                id = "pub-id",
                subscribers = 10,
                description = "description",
                name = "name_pub",
                slug = "slug_pub",
                creator_id = "user-1",
                image = "image_url"
            });
        }

        private HttpContent MockValidPublicationIdResponse()
        {
            return JsonContent.Create(new
            {
                publication_id = "pub-id",
                publication_slug = "slug_pub"
            });
        }

        private HttpContent MockValidArticlesResponse()
        {
            return JsonContent.Create(new
            {
                publication_articles = new List<string> { "article-1", "article-2" }
            });
        }
    }
}
