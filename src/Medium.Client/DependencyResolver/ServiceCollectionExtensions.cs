using Medium.Client.Abstractions;
using Medium.Client.HttpClients;
using Medium.Client.MockClients;
using Medium.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Medium.Client.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediumClient(this IServiceCollection services, bool mockData = false)
        {
            services.AddSingleton<MediumOptions>();
            services.AddScoped<IMediumClient, MediumClient>();

            if (mockData)
                return services.AddMockClient();

            services.AddHttpClient();
            return services;
        }

        private static IServiceCollection AddHttpClient(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<MediumOptions>();

            // base configuration for HTTP requests
            services.AddHttpClient<BaseHttpClient>(c =>
            {
                c.BaseAddress = new Uri("https://medium2.p.rapidapi.com/");
                c.DefaultRequestHeaders.Add("X-RapidAPI-Key", options.Apikey);
                c.DefaultRequestHeaders.Add("X-RapidAPI-Host", "medium2.p.rapidapi.com");
                c.DefaultRequestHeaders.Add("User-Agent", "medium-api-dotnet-sdk");
            });

            services.AddScoped<IUserClient, UserClient>();
            services.AddScoped<IArticleClient, ArticleClient>();
            services.AddScoped<IPublicationClient, PublicationClient>();
            services.AddScoped<IListClient, ListClient>();
            services.AddScoped<IMiscClient, MiscClient>();
            services.AddScoped<ISearchClient, SearchClient>();

            return services;
        }

        private static IServiceCollection AddMockClient(this IServiceCollection services)
        {
            Console.WriteLine("Using the Mock client feature.");
            services.AddSingleton<Context>();
            services.AddScoped<IUserClient, MockUserClient>();
            return services;
        }
    }
}
