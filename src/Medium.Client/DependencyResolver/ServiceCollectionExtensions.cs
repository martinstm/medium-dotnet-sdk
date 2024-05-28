using Medium.Client.Abstractions;
using Medium.Client.HttpClients;
using Medium.Client.MockClients;
using Medium.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using System.Linq;

namespace Medium.Client.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        private static IHttpClientBuilder _httpClientBuilder;

        public static IServiceCollection AddMediumClient(this IServiceCollection services, bool mockData = false, bool defaultRetryPolicy = false)
        {
            services.AddSingleton<MediumOptions>();
            services.AddScoped<IMediumClient, MediumClient>();

            if (mockData)
                return services.AddMockClient();

            services.AddHttpClient(defaultRetryPolicy);
            return services;
        }

        public static IServiceCollection WithRetryPolicy(this IServiceCollection services, Func<HttpRequestMessage, IAsyncPolicy<HttpResponseMessage>> retryPolicy)
        {
            _httpClientBuilder.AddPolicyHandler(retryPolicy);
            return services;
        }

        private static IServiceCollection AddHttpClient(this IServiceCollection services, bool defaultRetryPolicy)
        {
            var options = services.BuildServiceProvider().GetRequiredService<MediumOptions>();

            // base configuration for HTTP requests
            _httpClientBuilder = services.AddHttpClient<BaseHttpClient>(c =>
            {
                c.BaseAddress = new Uri("https://medium2.p.rapidapi.com/");
                c.DefaultRequestHeaders.Add("X-RapidAPI-Key", options.Apikey);
                c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "medium2.p.rapidapi.com");
                c.DefaultRequestHeaders.Add("User-Agent", "medium-api-dotnet-sdk");
            });

            if (defaultRetryPolicy)
                _httpClientBuilder.AddPolicyHandler(GetDefaultRetryPolicy());

            services.AddScoped<IUserClient, UserClient>();
            services.AddScoped<IArticleClient, ArticleClient>();
            services.AddScoped<IPublicationClient, PublicationClient>();
            services.AddScoped<IListClient, ListClient>();
            services.AddScoped<IPlatformClient, PlatformClient>();
            services.AddScoped<ISearchClient, SearchClient>();

            return services;
        }

        private static IServiceCollection AddMockClient(this IServiceCollection services)
        {
            Console.WriteLine("Using the Mock client feature.");
            services.AddSingleton<MockContext>();
            services.AddScoped<IUserClient, MockUserClient>();
            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5);
            var extraErrors = new[] { HttpStatusCode.NotFound };

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => extraErrors.Contains(msg.StatusCode))
                .WaitAndRetryAsync(delay);
        }
    }
}
