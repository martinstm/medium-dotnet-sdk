using Medium.Client;
using Medium.Client.DependencyResolver;
using Medium.Domain.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Medium.Demos.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddMediumClient(defaultRetryPolicy: true);
                })
                .Build();

            IMediumClient mediumClient = host.Services.GetRequiredService<IMediumClient>();

            UserInfo userInfo = await mediumClient.Users.GetInfoByUsernameAsync("martinstm");

            Console.WriteLine($"User {userInfo.Fullname} with {userInfo.FollowersCount} followers found!");
        }
    }
}